﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Azure.Management.DataLake.Store.Models;
using Microsoft.Rest.Azure.Authentication;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Linq;
using Quartz;

namespace WhoKnowWho.Models
{

    /// <summary>
    /// Helpper class for launching the scheduled in memory cache refresh.
    /// </summary>
    public class ContactMapRefreshJob : IJob
    {
        /// <summary>
        /// Callback for scheduled execution.
        /// </summary>
        /// <param name="context">The execution context</param>
        public void Execute(IJobExecutionContext context)
        {
            ContactMap.Refresh();
        }
    }

    /// <summary>
    /// A sington in memory table for ContactMap entries.
    /// This is for demomistration purpose only.  New implementaiton should use a Azure Job
    /// to populate a database.
    /// </summary>
    public class ContactMap
    {
        // The internal cache reference
        static private Dictionary<string, List<UserScore>> theWkwScoreMap = null;

        // Search samples
        static private IEnumerable<string> samples = null;

        // When the cache was last populated
        static private DateTimeOffset lastLoadTime = DateTimeOffset.MinValue;

        // Lock to protect consistency of the data
        static private SemaphoreSlim myLock = new SemaphoreSlim(1, 1);

        // Parameters for establishing a ADLS connection
        static private readonly string clientId = ConfigurationManager.AppSettings["adls:ClientId"];
        static private readonly string clientSecret = ConfigurationManager.AppSettings["adls:ClientSecret"];
        static private readonly string tenantId = ConfigurationManager.AppSettings["adls:TenantId"];
        static private readonly string accountName = ConfigurationManager.AppSettings["adls:AccountName"];

        // Path to the actual data
        static private readonly string msgPath = ConfigurationManager.AppSettings["adls:Path"];

        // Schedule definition
        static private readonly int startHour = int.Parse(ConfigurationManager.AppSettings["cache:RefreshHourOfDayUtc"]);
        static private readonly int interval = int.Parse(ConfigurationManager.AppSettings["cache:RefreshIntervalHours"]);

        /// <summary>
        /// Initialize the cache by performing the initial data population and setting up the scheduler.
        /// </summary>
        public static void Initialize()
        {
            if (startHour < 0 || startHour > 23)
            {
                throw new ConfigurationErrorsException("cache:RefreshHourOfDay must be between 0 and 23.");
            }

            if (interval < 1)
            {
                throw new ConfigurationErrorsException("cache:RefreshIntervalHours must be greater than 1.");
            }

            // Performs initial data population
            ContactMap.Refresh();

            // Setting up the scheduler
            IScheduler scheduler = Quartz.Impl.StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<ContactMapRefreshJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                     s.WithIntervalInHours(interval)
                    .OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(startHour, 0))
                  )
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }

        /// <summary>
        /// Refresh the cache.
        /// </summary>
        public static void Refresh()
        {
            List<Message> messagesList = new List<Message>();

            // The new data
            Dictionary<string, int> userComboPlusScore = new Dictionary<string, int>();
            Dictionary<string, List<UserScore>> wkwScores = new Dictionary<string, List<UserScore>>();

            messagesList = ContactMap.GetMessages();
            userComboPlusScore = ContactMap.ComputeUserComboScore(messagesList);
            wkwScores = ContactMap.WhoKnowsWhoScoreMap(userComboPlusScore);

            if (wkwScores.Count() == 0)
            {
                // don't update if there is nothing
                return;
            }

            // Commit the new data as the official copy.
            myLock.Wait();

            try
            {
                theWkwScoreMap = wkwScores;
                samples = wkwScores.Keys.ToList();
                lastLoadTime = DateTimeOffset.UtcNow;
            }
            finally
            {
                myLock.Release();
            }
        }

        /// <summary>
        /// Getting a reference to the cache
        /// </summary>
        /// <returns>Reference to the cache</returns>
        public static async Task<Dictionary<string, List<UserScore>>> GetMap()
        {
            Dictionary<string, List<UserScore>> map;

            await myLock.WaitAsync();

            try
            {
                map = theWkwScoreMap;
            }
            finally
            {
                myLock.Release();
            }

            return map;
        }

        /// <summary>
        /// Getting the last cache refresh time.
        /// </summary>
        /// <returns>Last cache refresh time</returns>
        public static async Task<DateTimeOffset> GetLastRefreshTime()
        {
            DateTimeOffset time = DateTimeOffset.MinValue;

            await myLock.WaitAsync();

            try
            {
                time = lastLoadTime;
            }
            finally
            {
                myLock.Release();
            }

            return time;
        }

        /// <summary>
        /// Getting the last smaple email addresses.
        /// </summary>
        /// <returns>Last cache refresh time</returns>
        public static async Task<IEnumerable<string>> GetSampleUsers()
        {
            IEnumerable<string> samples;

            await myLock.WaitAsync();

            try
            {
                samples = ContactMap.samples;
            }
            finally
            {
                myLock.Release();
            }

            return samples;
        }

        private static Dictionary<string, List<UserScore>> WhoKnowsWhoScoreMap(Dictionary<string, int> newUserComboPlusScore)
        {
            Dictionary<string, List<UserScore>> newWkwScores = new Dictionary<string, List<UserScore>>();

            foreach (var combo in newUserComboPlusScore)
            {
                string[] substrings = combo.Key.Split('_');
                UserScore userScore = new UserScore()
                {
                    User = substrings[1],
                    Score = combo.Value
                };

                if (!newWkwScores.ContainsKey(substrings[0]))
                {
                    newWkwScores.Add(substrings[0], null);
                }

                List<UserScore> wkwScore = newWkwScores[substrings[0]];

                if (wkwScore == null || wkwScore.Any() == false)
                {
                    wkwScore = new List<UserScore>();
                }

                wkwScore.Add(userScore);
                newWkwScores[substrings[0]] = wkwScore;
            }

            return newWkwScores;
        }

        private static Dictionary<string, int> ComputeUserComboScore(List<Message> messagesList)
        {
            Dictionary<string, int> newUserComboPlusScore = new Dictionary<string, int>();

            foreach (Message msg in messagesList)
            {
                List<string> recipientList = new List<string>();

                if (msg.ToRecipients != null)
                {
                    recipientList.AddRange(msg.ToRecipients);
                }

                if (msg.CcRecipients != null)
                {
                    recipientList.AddRange(msg.CcRecipients);
                }

                if (msg.BccRecipients != null)
                {
                    recipientList.AddRange(msg.BccRecipients);
                }

                recipientList = recipientList.Distinct().ToList();

                foreach (string recipient in recipientList)
                {
                    if (String.Equals(recipient, msg.Sender, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    string key = string.Format("{0}_{1}", msg.Sender, recipient);
                    if (newUserComboPlusScore.ContainsKey(key))
                    {
                        newUserComboPlusScore[key] += 1;
                    }
                    else
                    {
                        newUserComboPlusScore.Add(key, 1);
                    }

                    key = string.Format("{0}_{1}", recipient, msg.Sender);
                    if (newUserComboPlusScore.ContainsKey(key))
                    {
                        newUserComboPlusScore[key] += 2;
                    }
                    else
                    {
                        newUserComboPlusScore.Add(key, 2);
                    }
                }
            }

            return newUserComboPlusScore;
        }

        private static void GetFullFilePath(DataLakeStoreFileSystemManagementClient client, FileStatusProperties fileStatusProperties, List<string> finalFilePathList, string path)
        {
            string fullPath = String.Format("{0}/{1}", path, fileStatusProperties.PathSuffix);

            if (fileStatusProperties.Type == FileType.DIRECTORY)
            {
                FileStatusesResult fileStatusesResult = client.FileSystem.ListFileStatus(accountName, fullPath);

                foreach (FileStatusProperties fsProp in fileStatusesResult.FileStatuses.FileStatus)
                {
                    GetFullFilePath(client, fsProp, finalFilePathList, fullPath);
                }
            }

            if (fileStatusProperties.Type == FileType.FILE)
            {
                if (finalFilePathList == null)
                {
                    finalFilePathList = new List<string>();
                }

                finalFilePathList.Add(fullPath);
            }
        }

        private static List<Message> GetMessages()
        {
            List<Message> messagesList = new List<Message>();
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

            ServiceClientCredentials creds = ApplicationTokenProvider.LoginSilentAsync(tenantId, clientId, clientSecret).Result;

            DataLakeStoreFileSystemManagementClient client = new DataLakeStoreFileSystemManagementClient(creds);
            FileStatusesResult fileStatusesResult = client.FileSystem.ListFileStatus(accountName, msgPath);

            List<string> finalFilePathList = new List<string>();

            foreach (FileStatusProperties fileStatusProperties in fileStatusesResult.FileStatuses.FileStatus)
            {
                GetFullFilePath(client, fileStatusProperties, finalFilePathList, msgPath);
            }

            foreach (string filePath in finalFilePathList)
            {
                using (var stream = client.FileSystem.Open(accountName, filePath))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            Message message = new Message();

                            message.ToRecipients = new List<string>();
                            message.CcRecipients = new List<string>();
                            message.BccRecipients = new List<string>();

                            JObject obj = JObject.Parse(line);

                            string sender = obj.SelectToken("Sender.EmailAddress.Address")?.ToString();

                            message.Sender = obj.SelectToken("Sender.EmailAddress.Address") == null ? obj.SelectToken("From.EmailAddress.Address")?.ToString() : sender;

                            IEnumerable<JToken> val = obj.SelectTokens("ToRecipients");
                            foreach (JObject child in val.Children())
                            {
                                message.ToRecipients.Add(child.SelectToken("EmailAddress.Address")?.ToString());
                            }

                            val = obj.SelectTokens("CcRecipients");
                            foreach (JObject child in val.Children())
                            {
                                message.CcRecipients.Add(child.SelectToken("EmailAddress.Address")?.ToString());
                            }

                            val = obj.SelectTokens("BccRecipients");
                            foreach (JObject child in val.Children())
                            {
                                message.BccRecipients.Add(child.SelectToken("EmailAddress.Address")?.ToString());
                            }

                            if (sender != null)
                            {
                                messagesList.Add(message);
                            }
                        }
                    }
                }
            }

            return messagesList;
        }
    }
}