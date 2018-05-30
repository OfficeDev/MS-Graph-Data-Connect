# Azure Managed Applications

## Overview

The Azure Managed App on Office 365 can be broken down into 3 components:

- Data Ingestion from Euclid/Office365
- Data processing/analytics to produce intelligent data
- UX to surface the intelligent data

We will work through a sample that covers all three components:

1. We use Azure Data Factory (ADF) with copy activity to move data from O365 to your target adls.
2. We then have an azure web app that reads the data at target adls and outputs intelligent data.

Before we begin exploring the sample application, here are a few resources to get you started with the involved technologies:

- [Azure Data Factory](https://docs.microsoft.com/en-us/azure/data-factory/)
- [Azure Data Lake Analytics](https://docs.microsoft.com/en-us/azure/data-lake-analytics/)
- [Azure ARM Templates](https://azure.microsoft.com/en-us/resources/templates/)
- [Azure ARM Template Samples](https://github.com/Azure/azure-quickstart-templates)
- [Azure Managed App](https://docs.microsoft.com/en-us/azure/managed-applications/)
- [Azure Managed App Samples](https://github.com/Azure/azure-managedapp-samples/tree/master/samples)

## Prerequisites

- Visual Studio 2017
- Office 365 tenant with Azure subscription - The tenant should have users with data in their mailboxes.
- [Azure AD Powershell](https://docs.microsoft.com/en-us/powershell/azure/active-directory/install-adv2?view=azureadps-2.0)
- [Azure Powershell](https://docs.microsoft.com/en-us/powershell/azure/install-azurerm-ps)

## Create and publish an O365-powered Azure managed application:

The instructions below will help you create and publish an Azure managed application internally.
For reference: [Publish a managed application for internal consumption](https://docs.microsoft.com/en-us/azure/managed-applications/publish-service-catalog-app).

### Step 1: Package the web application

Open the **./src/WhoKnowsWho.sln** solution in Visual Studio 2017. This solution contains the web application which will consume and process the data in the Azure Data Lake Store created by Project Euclid.

#### Create the package

1. Right-click the **WhoKnowsWho** solution in **Solution Explorer** and choose **Restore NuGet Packages**.
2. Select the **WhoKnowsWho** project in **Solution Explorer**. Select the **Build** menu, then **Publish WhoKnowsWho**.
3. Select the **WebPackage** publishing profile and select **Publish**.

This should generate a **WhoKnowsWho.zip** file in the `ManagedApp` directory, unless you specified a different output directory in the publishing profile.

#### Upload the package to blob storage

In this step we'll create a storage account and upload the **WhoKnowsWho.zip** file as a blob. This will allow us to include the web application as part of the Azure managed application we'll create later.

1. Follow the steps in [Create a storage account](https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=portal) to create a storage account.

2. Follow the steps in the [Create a container](https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-portal#create-a-container) section and the [Upload a block blob](https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-portal#upload-a-block-blob) section of [Quickstart: Upload, download, and list blobs using the Azure portal](https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-portal) to upload **WhoKnowsWho.zip**.

   > **Note:** Be sure to select **Blob (anonymous read access for blobs only)** in the **Public access level** dropdown when creating the container.

3. Take a note of the **WhoKnowsWho.zip** blob **URL** value.

### Step 2: Create an Application in your tenant

For Office365 LinkedService you need to provide an AAD application in your company's tenant (azure marketplace app publisher tenant). This application is different from the destination service principal. The destination service principal belongs to the customer tenant where the resources are being deployed and it's provided to your app via parameters by the customer during installation. Although, if you are deploying a service catalog app or an ARM template directly (for e.g. sample [ARMTemplates](../ARMTemplates)), your company tenant and installer tenants are same and you can technically use the same service principal for Office365 LinkedService as well as ADLS account & LinkedService.

1. Follow these [instructions](to https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#create-an-azure-active-directory-application) to create an app registration in your tenant.

   > **NOTE:** While creating credentials set the expiry to "Never Expire". Otherwise all installed instances of your azure marketplace application will fail once the creds expire.

2. Add yourself as the owner of the application.

   ![](../docs/images/managedapp-appowners.png)

3. Take note of AppId, Secret Key and your TenantId.

### Step 3: Create the app template

Create a template that defines the resources to deploy with the managed application (refer to [mainTemplate.json](mainTemplate.json)).

If you look at the **mainTemplate.json**, it consists of three main sections:

#### Parameters

Contains the list of parameters whose values will be provided by the user.

| Parameter name | Description |
|----------------|-------------|
| `WebSiteName` | The website name, used as the prefix in the url of the published web app. For example: `<websitename>.azurewebsites.net` |
| `DestinationServicePrincipalAadId` | The Azure Active Directory ID of the service principal to be granted access to the destination Data Lake store |
| `DestinationServicePrincipalId` | The app ID of the service principal that has access to the destination Data Lake store |
| `DestinationServicePrincipalKey` | The app secret of the service principal that has access to the destination Data Lake store |
| `UserId` | The Office 365 user that want to deploy this app |
| `TriggerStartTime` | UTC date in `YYYY-MM-ddT00:00:00Z` format |


#### Variables 

Contains the list of variables. Please go through all the variables. You should update all the fields marked below unless marked as *(Optional)*.

| Variable name | Description |
|----------------|-------------|
| `sourceLinkedServicePrincipalId` | The App Id for the SPN created in Step 2 |
| `sourceLinkedServicePrincipalKey` | The Secret for the SPN created in Step 2 |
| `sourceLinkedServicePrincipalTenantId` | The TenantId for the SPN created in Step 2 |
| `office365DataDiscoveryServiceUrl` *(Optional)* | Use the  value corresponding to the environment you want to target. **PPE** is the pre-production environment and will be the first to have the latest set of changes. **PROD** is updated weekly, but will tend to be more stable.  <br><br> **PPE** *(Default)*: `https://104.43.241.84/DiscoveryService/`<br> **PROD**: `https://104.43.245.57/DiscoveryService/` <br><br>*Note: These are the only valid values, if you are pointing to a different endpoint, it could be stale.*|


#### Resources

Contains the list of resources that will be deployed as a part of the managed app creation.

Below are few of the resources that will be deployed as a part of the **mainTemplate.json** explained briefly.

| Resource name | Description |
|---------------|-------------|
| `O365DataPlan` | This resource enables compliance monitoring for your app and is **mandatory** for managed apps. You shouldn't add it to ARM templates that you deploy directly without managed app. For e.g. sample ARM templates at [`/ARMTemplates`](../ARMTemplates) |
| `AuditStorageAccount` | Storage account to store all audit logs |
| `DestinationAdlsAccount` | Creates the destination Data Lake store in the customer's subscription used in the ADF pipeline for the data output. The account also creates `diagnosticSettings` with `AuditStorageAccount` as the store to collect `audit` and `requests` logs. |
| `DataFactory` | Creates the ADF pipeline that copies data from O365 to the newly created destination ADLS (`DestinationAdlsAccount` that was created above) |
| `WebApp` | Creates the web app that uses data stored in the newly created destination ADLS. Sample: [web app](https://github.com/Azure/azure-managedapp-samples/tree/master/samples/201-managed-web-app)|

The data factory has couple of interesting resources of it's own.

| Resource name | Description |
|---------------|-------------|
| `IntegrationRuntime` | Runtime ADF will use to execute copy activities |
| `SourceLinkedService` | Creates the link to O365 which is used as the source of the data extraction. Using service principal supplied by the source ADLS owner. |
| `DestinationLinkedService` | Creates the link to the newly created destination ADLS, using service principal supplied by the customer deploying this template. |
| `*InputDataset` | You should change the structure in this resource to match the table and columns that you would like to extract. In this template we are trying to extract messages and events. For contacts and users refer [basic-sample](../ARMTemplates/basic-sample)|
| `*OutputDataset` | Corresponds to the `DestinationAdlsAccount` where we wanted the data to be copied to. |
| `Pipeline` | The Copy activity pipeline that copies the data from source O365 to the destination ADLS. Sample [copy activity](https://docs.microsoft.com/en-us/azure/data-factory/load-azure-data-lake-store)|
| `PipelineTriggers` | Contains settings to ensure the copy pipeline can be scheduled to run periodically. Sample: [tumbling window trigger](https://docs.microsoft.com/en-us/azure/data-factory/how-to-create-tumbling-window-trigger)|


### Step 4: Create the UI definition

Define the user interface elements for the portal when deploying the managed application (refer to [createUiDefinition.json](ManagedApp/createUiDefinition.json)). The Azure portal uses the **createUiDefinition.json** file to generate the user interface for users who create the managed application. You define how users provide input for each parameter. You can use options like a drop-down list, text box, password box, and other input tools. To learn how to create a UI definition file for a managed application, see [Get started with CreateUiDefinition](https://docs.microsoft.com/en-us/azure/managed-applications/create-uidefinition-overview).

The values of the parameters defined in **mainTemplate.json** are supplied through the UI generated by **createUiDefinition.json** when the managed application is being created.

### Step 5: Deploy managed app

1. Open the **./ManagedApp/mainTemplate.json** file.
2. Locate the `webAppRemote` value. Change this value to the URL of the **WhoKnowsWho.zip** blob you created above.
3. Save the file.
4. Create a new ZIP file named **app.zip** that contains **./ManagedApp/mainTemplate.json** and **./ManagedApp/createUiDefinition.json**.

Use `scripts/DeployManagedApp.ps1` to deploy the managed app

```shell
.\Scripts\DeployManagedApp.ps1 -ResourceGroupLocation "eastus2"
```

The script automates the following steps:

#### Upload the app.zip

More details under the section [Packages the Files](https://docs.microsoft.com/en-us/azure/managed-applications/publish-service-catalog-app#package-the-files) in [Publish a managed application for internal consumption](https://docs.microsoft.com/en-us/azure/managed-applications/publish-service-catalog-app) for packaging the template files and uploading them to a blob storage.

#### Assign a user group or application

Create a user group or application for managing the resources on behalf of a customer by following the steps under the section [Create the managed application definition](https://docs.microsoft.com/en-us/azure/managed-applications/publish-service-catalog-app#create-the-managed-application-definition) in [Publish a managed application for internal consumption](https://docs.microsoft.com/en-us/azure/managed-applications/publish-service-catalog-app)

Get the role definition ID by following the steps in [Get the role definition ID](https://docs.microsoft.com/en-us/azure/managed-applications/publish-service-catalog-app#get-the-role-definition-id).

#### Create the managed application definition

Create the managed application definition using [`New-AzureRmManagedApplicationDefinition`](https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/new-azurermmanagedapplicationdefinition?view=azurermps-6.0.0)

> **NOTE:** Step 5 is going to deploy managed app for internal users. This step will differ when you are [publishing your official app to azure marketplace](https://docs.microsoft.com/en-us/azure/managed-applications/publish-marketplace-app).

### Step 6: Install the managed application

You can create the managed application by following the steps listed below.

1. Run the `Scripts\GetAppInstallationParameters.ps1` script with no parameters. Save these values to use during the installation of the managed app.

   > **NOTE:** The script automates [creation of an Azure Active Directory application](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#create-an-azure-active-directory-application) and [gets application id and authentication key](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal#get-application-id-and-authentication-key).

1. Go to Azure Portal and choose **Managed Applications** from **All Services**.

1. Click on **Add** and you will see the Managed Application definition that we created above.

1. Select the Managed App definition that you want to create and click on **Create**.

1. On the **Basics** screen, select your subscription and either create a new resource group or use an existing one, then select **OK**.
   > **NOTE:** Please make sure that the location selected is "East US 2", since we are currently not available worldwide.

1. On the **Web App Settings** screen, enter the **Website name** value generated by the **GetAppInstallationParameters.ps1** script, then select **OK**.

1. On the **Data Factory Settings** screen enter the corresponding values from the output of the **GetAppInstallationParameters.ps1** script, then select **OK**.

1. On the **Summary** screen, wait for the validation to complete and select **OK**.

The deployment of the app starts and once it completes you will be able to see it in the dashboard.

### Step 7: Try it out

Click on the app and in the overview section you will see two resource groups. Click on the managed resource group.

You will notice that all the resources mentioned in the ARM template have been created successfully.

#### Running the ADF Pipeline

Execute the following commands in your shell to kick off the ADF pipeline.

1. Create variable for resource group name, data factory name, and pipeline name

    ```Powershell
    $resourceGroupName = <name of the managed resource group which contains the data factory>
    $dataFactoryName = <data factory name>
    $pipelineName = <pipeline name that was specified in the ARM template under variables section>
    ```
1. Start the pipeline:

    ```powershell
    Invoke-AzureRmDataFactoryV2Pipeline -ResourceGroupName $resourceGroupName -DataFactory $dataFactoryName -PipelineName $pipelineName
    ```


#### Schedule the pipeline

Execute the following commands in your shell to run the pipeline on a scheduled basis.

##### Powershell

1. Create variable for resource group name, data factory name, and trigger name

    ```Powershell
    $resourceGroupName = <managed resource group name>
    $dataFactoryName = <data factory name>
    $triggerName = <trigger name>
    ```
1. Start trigger:

    ```Powershell
    Start-AzureRmDataFactoryV2Trigger -ResourceGroupName $resourceGroupName -DataFactoryName $dataFactoryName -TriggerName $triggerName
    ```
1. Get status of the trigger:

    ```Powershell
    Get-AzureRmDataFactoryV2Trigger -ResourceGroupName $resourceGroupName -DataFactoryName $dataFactoryName -Name $triggerName
    ```

You should see a response similar to the following.

```
TriggerName : MarsEuclidTestTrigger
ResourceGroupName : MarsEuclid1\_ResourceGroup
DataFactoryName : MarsEuclid2DataFactory
Properties :
    Microsoft.Azure.Management.DataFactory.Models.ScheduleTrigger
RuntimeState : Started
```

If you need to stop the trigger, use the following command.

```Powershell
Stop-AzureRmDataFactoryV2Trigger -ResourceGroupName $resourceGroupName -DataFactoryName $dataFactoryName -TriggerName $triggerName
```

#### Monitor the Pipeline

1. In the [Azure Portal](https://portal.azure.com), go to your data factory.

2. Click on the **Author & Monitor** quick link tile.

3. In the Azure Data Factory page that opens, click on the monitor icon. You will be able to see the ADF pipelines and their status.

> **NOTE:** You can find more info on these commands [here](https://docs.microsoft.com/en-us/powershell/module/azurerm.datafactoryv2/?view=azurermps-5.7.0)

#### Approving Data Access Request

1. Open Microsoft Exchange Online PowerShell module
2. Login with an account that's part of the approver group you created when you enabled Tenant Lockbox:

   ```powershell
   Connect-EXOPSSession
   ```

3. Find all pending requests

   ```powershell
   Get-ElevatedAccessRequest | ?{$_.RequestStatus -eq 'Pending'}
   ```

4. Take a closer look at the **context** field of the request you are interested in
   >**NOTE:** Context field has most of the interesting fields of the data access request

   ```powershell
   (Get-ElevatedAccessRequest -RequestId $requestId).Context | ConvertFrom-Json
   ```

   You'll get a response like:

   ```powershell
   Key                          Value
   ---                          -----
   ApplicationName
   ComplianceStatus             [{"Timestamp":"2018-05-02T18:29:21.5705664Z","RequirementName":"adlsEncryption","PolicyComplianceState":"Compliant","Violations":0},{"Timestamp":"2018-05-02T...
   ApplicationMarketPlaceUri
   OutputUri                    adl://myadlserumvrroyspmq.azuredatalakestore.net/targetFolder/Event
   ApplicationPrivacyPolicyUri  http://www.wkw.com/privacy
   ApplicationTermsOfServiceUri http://www.wkw.com/tos
   InstallerIdentity            a89885c3-4b0e-499e-86ed-14d7ed9147c2@942229f8-4656-4fb0-828b-e938dad4019a
   SourceTenantId               942229f8-4656-4fb0-828b-e938dad4019a
   UserScopeQuery               tenant in (942229f8-4656-4fb0-828b-e938dad4019a)
   ApplicationId
   DataTable                    Calendar Events
   DestinationTenantId          942229f8-4656-4fb0-828b-e938dad4019a
   Columns                      Subject:string, HasAttachments:bool, End:DateTime, Start:DateTime, ResponseStatus:string, Organizer:Object, Attendees:string, Importance:string, Sensitivity:...
   ```

5. Approve/Deny the request

   ```powershell
   Approve-ElevatedAccessRequest -RequestId $requestId -Comment "Yay!!"
   Deny-ElevatedAccessRequest -RequestId $requestId -Comment "Nay!!"
   ```

## Using the sample web app

1. Open your browser and browse to `https://<websitename>.azurewebsites.net`, where `<websitename>` is the value of **Website name** you provided during the installation of the managed application.

2. If prompted to login, use an account from your test tenant.

3. Accept the prompt advising that the app would like to sign you in and read your profile.

4. At the bottom of the page, enter one of your user's email address and click the search button.

### Web App Sample UX

![](../docs/images/web-app-sample-ux.png)
