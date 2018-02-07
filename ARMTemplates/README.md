# Running your first ADF pipeline
Azure Managed App on Office365 can be broken down to 3 components:

 1. Data ingestion from Euclid/Office365
 2. Data processing/analytics to produce intelligent data
 3. UX to surface the intelligent data

This sample covers all three components:

 1. We use Azure Data Factory (ADF) with copy activity to move data from euclid (currently mocked by "source" Azure Data Lake Store a.k.a adls) to your "target" adls.
 2. We then have an azure web app that reads the data at "target" adls and output intelligent data

The instructions below help you deploy the above mentioned azure resources using [Azure ARM template](https://github.com/Azure/azure-quickstart-templates).
You can take a look at `adf-v1-sample/azuredeploy.json` files to understand what azure resources we are deploying. Choose your version based on following info:

> **NOTE:** This sample here is not a managed app. When a customer decides to install your managed app from Azure marketplace, your app during installation, will perform steps similar to the below steps to provision resources in customer's azure subscription.

## Deployment instructions

----------

#### Step 0

Bash

Before you start on the instructions below, please ensure that you have [node and npm](https://docs.npmjs.com/getting-started/installing-node), [jq](https://stedolan.github.io/jq/download/) and [azure-cli](https://docs.microsoft.com/en-us/azure/cli-install-nodejs) installed.

Powershell

Before you start on the instructions below, please ensure that you have [Azure Powershell](https://docs.microsoft.com/en-us/powershell/azure/install-azurerm-ps?view=azurermps-4.4.0) installed.

----------

#### Step 1
After installing the above pre-requisites fire below command in shell of your choice and follow the instructions to login to your azure subscription.

Bash
```bash
azure login
```

Powershell
```bash
Login-AzureRmAccount
```

----------

#### Step 2
Create Azure AD service principal to grant access to the "target" ADLS following these [instructions](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal).
You need to follow sections titled "Create an Azure Active Directory application" and "Get application ID and authentication key".
> **Note:** the sign-on url should be https://**webSiteName**.azurewebsites.net.
> **webSiteName** will be required in Step 3 and can be anything you want, just ensure that you think of something that will be unique around the globe.

----------

#### Step 3
Fill in the ARM template parameters in `.\adf-v1-sample\azuredeploy.parameters.json`.

##### dataFactoryParameters

- `destinationServicePrincipalId` is the Application Id of your service principal.
- `destinationServicePrincipalKey` is the Authentication Key you generated for your service principal.
- `destinationServicePrincipalAadId` is the `Object Id` (bash)/`Id` (powershell) you receieve when you run the following command:

> **Note:** Do not use the object id that you see on azure portal

Bash
```bash
azure ad sp show -c [service principal friendly name]
```

Powershell
```bash
Get-AzureRmADServicePrincipal -SearchString [service principal friendly name]
```

- You will receieve a separate communication from us detailing `source*` parameters.

##### webAppParameters

- Set `webSiteName` to the same value you set for the sign-on url.

----------

#### Step 4

Finally, deploy the ARM template and create the ADF pipeline by running the deployment script.

Bash
```bash
./azure-group-deploy.sh -l eastus2 -a adf-v*-sample
```

Powershell
```bash
.\Deploy-AzureResourceGroup.ps1 -ResourceGroupLocation eastus2  -ArtifactStagingDirectory adf-v*-sample
```

----------

#### Step 6 (If you chose adf-v1-sample)

Starting the pipeline to run on a schedule:

Powershell
```bash
Start-AzureRmDataFactoryV2Trigger -ResourceGroupName "adf-v1-sample" -DataFactoryName [adfName] -Name "pipelineTrigger"
```

At the time of writing this application, azure portal for adf-v1 wasn't very functional. A failed pipeline doesn't say anything about why it failed.
But if you see that your pipeline is failing, you can manually trigger the pipeline and see which activity is failing and why it's failing.

Powershell
```bash
.\runmonitor.ps1 -resourceGroupName "adf-v1-sample" -DataFactoryName [adfName] -PipelineName "E2E"
```

