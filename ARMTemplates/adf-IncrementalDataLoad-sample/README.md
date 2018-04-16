This sample covers:
 1. Incrementally load data using watermark stored in a DB.
 2. Incrementally load data using tumbling window trigger.

# Overview of Watermark Approach:

Watermarksample.json consists of 3 activities, 

#### LookUp Activity

https://docs.microsoft.com/en-us/azure/data-factory/control-flow-lookup-activity

This activity is used to get the watermark from the DB.

#### Copy Activity

https://docs.microsoft.com/en-us/azure/data-factory/copy-activity-overview

This activity is used to get the data greater than the current watermark till the current time.

#### SqlServerStoredProcedure Activity

https://docs.microsoft.com/en-us/azure/data-factory/transform-data-using-stored-procedure


This is used to update the watermark and set it to the current timestamp once the copy activity succeeds.

It makes use of TumblingWindowTrigger to schedule the pipeline to run consistently

https://docs.microsoft.com/en-us/azure/data-factory/how-to-create-tumbling-window-trigger

> **NOTE:** The connectionString property under waterMarkLinkedService in ARM template needs to be substituted with the db connection string. (You can find a samplewatermarkdb bacpac for reference)

# Overview of Tumbling Window Approach:

TumblingWindowSample.json makes use of TumblingWindowTrigger to schedule the pipeline to run consistently

https://docs.microsoft.com/en-us/azure/data-factory/how-to-create-tumbling-window-trigger

Based on the backfillDays parameter value, the trigger windowStart time is calculated.
If the trigger windowStart is older than the triggerStartTime parameter value, then it means that we need to backfill the data.
So the first pipeline that gets kicked off by the trigger will do a backfill and then the subsequent pipelines that get triggered will fetch data incrementally with a frequency of 24 hours.

In this example we have set the retry policy for the trigger pipeline run to be 2 and max concurrency to be 10. These values can be configured as per the need.

https://docs.microsoft.com/en-us/azure/data-factory/concepts-pipeline-execution-triggers#trigger-type-comparison

> **NOTE:** If the pipeline fails even after 2 retries, the window moves forward to the next day and this might result in holes in data.