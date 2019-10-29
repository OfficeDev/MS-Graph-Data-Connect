# Including Office 365 data in the Common Data Model 

The [Common Data Model](https://docs.microsoft.com/en-us/common-data-model/) simplifies data management and app development by unifying data into a known form and applying structural and semantic consistency across multiple apps and deployments. In other words, if your data is in the model, you can extract powerful insights and create intelligent applications to accelerate your digital transformation. This walkthrough describes how you can include data from your Office 365 organization in the Common Data Modelto be utilized alongside other data sources using Microsoft Graph data connect. 
Microsoft Graph data connect traditionally provides Office 365 data to your Azure storage in JSON lines but the Common Data Model flattens the data and makes it available as entity tables, which are represented as CSVs. In this walkthrough you will:
* Provision required resources in your Azure environment to store and process your Office 365 data 
* Use an Azure Data Factory template to move your Office 365 data through Microsoft Graph data connect into Azure Data Lake Gen2 storage in your environment in JSON lines
* Use Azure HDInsight to run a PySpark script to convert the Office 365 data from JSON lines into CDM entities that can be joined 
## Pre-requistes
To utilize this walkthrough, you must have Microsoft Graph data connect enabled in your Office 365 organization and have an Azure subscription under the same Azure Active Directory tenant as your Office 365 subscription. Use the steps in [Exercise 1](https://github.com/microsoftgraph/msgraph-training-dataconnect/blob/master/Lab.md) of our Microsoft Graph data connect training module to enable and configure Microsoft Graph data connect in your environment alongside an Azure subscription.  
## Provision required resources 
To complete the conversion, a few resources must be created in your Azure environment, specifically:
* An app registration to enable Microsoft Graph data connect to extract your Office 365 data into your Azure storage. Follow the steps under "Create an Azure AD Application" in Exercise 2 of our training module to provision the resource. Note down the application ID, tenant ID, and application key as they will be used later in the walkthrough. Ensure the app registration has Storage Blob Data Contributor access to the Azure Data Lake Storage Gen2 account to be created next.
* An Azure Data Lake Storage Gen2 (ADLSg2) account to store the JSON lines outputted from Microsoft Graph data connect, the PySpark script to convert the JSON lines into CDM format and to store the resulting CDM entity files. Follow the [ADLSg2 account creation steps](https://docs.microsoft.com/en-us/azure/storage/blobs/data-lake-storage-quickstart-create-account) to create an account. Ensure the storage account has three file systems within it:
  - A file system to store the Office 365 data outputted by Microsoft Graph data connect in JSON format (called json)
  - A file system to store the outputted CDM entities after the conversion is complete (called cdm)
  - A file system to store the PySpark script and other required resources (called jsontocdm)
* An Azure HDInsight cluster (HDI cluster) to execute the PySpark converstion script on your Office 365 data. Follow the [Use Azure Data Lake Storage Gen2 with Azure HDInsight clusters](https://docs.microsoft.com/en-us/azure/hdinsight/hdinsight-hadoop-use-data-lake-storage-gen2) steps to create the cluster. Note the username and password for the admin user, as it will be needed later in the walkthrough.
* An Azure Data Factory resource to facilitate the movement of Office 365 data into the Common Data Model. Create an Azure Data Factory by navigating to the [Azure portal](https://portal.azure.com/) and search for Data Factories. 

## Use our Azure Data Factory template to convert Office 365 data into the Common Data Model format
We have made available an Azure Data Factory template which streamlines the transformation of Office 365 data into the Common Data Model using Microsoft Graph data connect. To do so, navigate to the [Azure Data Factory experience](https://datafactoryv2.azure.com/) and select the factory you created. On the resulting screen, create a new Pipeline from template and search for "Open Data Initiative." Select the resulting template from the search: 
![Azure Data Factory template](https://github.com/OfficeDev/MS-Graph-Data-Connect/blob/master/Common-Data-Model/images/template.PNG)
Within the template, you'll need to create a few linked service entities using the Azure resources provisioned earlier. 

### Create the ADLSg2 linked service
To create the linked service to access the ADLSg2 account, select the drop down under AzureDataLakeStorageGen2 and create a new linked service. In the resulting blade, ensure you have set the Authentication Method to Service Principal and the Account Selection method as from an Azure subscription. Select the Azure subscription and account created earlier, as well as use the application ID and key noted earlier that has access to the account then click create. This linked service will be used later on in the HDI cluster linked configuration as well.
![ADLSg2 linked service configuration](https://github.com/OfficeDev/MS-Graph-Data-Connect/blob/master/Common-Data-Model/images/ADLSg2LS.PNG)

### Create the Office 365 data linked service
To create the linked service to allow Microsoft Graph data connect to move data into your Azure storage account, select any of the drop downs under the Office 365 tables and create a new linked service. In the resulting blade, provide the application ID and key noted earlier and select create. This linked service will automatically be used for all of the other Office 365 tables as well. 
![Office 365 linked service configuration](https://github.com/OfficeDev/MS-Graph-Data-Connect/blob/master/Common-Data-Model/images/O365LS.PNG)

### Create the HDI cluster linked service
To create the linked service connected to your HDI cluster, select the drop down under HDInsightCluster and create a new linked service. In the resulting blade, ensure Account Selection is From Azure Subscription and select the subscription containing your HDI cluster and ADLSg2 account. Select the HDI cluster you created and select ADLS Gen 2 for Azure Storage linked service. Ensure the ADLSg2 linked service created previously is selected and for file system use the file system which contains the PySpark script (jsontocdm). Enter the admin credentials to access the HDI cluster and click create
![HDI cluster linked service configuration](https://github.com/OfficeDev/MS-Graph-Data-Connect/blob/master/Common-Data-Model/images/HDILS.PNG) 

