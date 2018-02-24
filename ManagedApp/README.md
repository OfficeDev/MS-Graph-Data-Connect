# Running your first euclid sample app in under 10 mins

The instructions below will help you to -
	1. Publish the sample managed app definition 
	2. Get the app installation parameters
	3. Install the managed application
	4. Kickstart an ADF pipeline

#### Step 1

##### Publish the sample managed app definition

The DeployManagedApp.ps1 script can be used for uploading the ARM templates into an azure blob storage account. 
It creates a new resource group, storage account, container and uploads the app.zip if an existing resource group or storage name wasn't specified as a parameter.
It then publishes the managed application for you.

Eg: .\DeployManagedApp.ps1 -ArtifactStagingDirectory "E:\share" -ResourceGroupLocation "West Central US" -StorageAccountName "samplestorageaccount" -ResourceGroupName "sampleResourceGroup"

If the artifacts were already uploaded then you can just specify the PackageFileUrl and run the script.
It publishes the managed application for you.

Eg: .\DeployManagedApp.ps1 -ResourceGroupLocation "West Central US" -PackageFileUri "https://samplestorageaccount.blob.core.windows.net/appcontainer/app.zip"

#### Step 2

##### Get the app installation parameters

Run the GetAppInstallationParameters script.
It will output the app installation parameter values.

Eg: .\GetAppInstallationParameters.ps1

You can specify the subscription id and application display name as parameters tot he above script.
If nothing is specified it uses the default values.

Eg: .\GetAppInstallationParameters.ps1 -SubscriptionId <azure subscription id> -ApplicationDisplayName "WhoKnowsWhom" 

#### Step 3

##### Install the managed application

Login to the Azure Portal.
Go to Managed Applications.
Click on Add. You will be able to see the sample app that we published in Step 1 listed in the "Create service catalog managed application" window.
Choose the app and click on Create.
In the "Basics" tab, specify the resource group where you want the app to be installed and click on "OK"
In the "Web App Settings" tab, copy paste the "Website name" value that you got when you ran the script in Step 2 and click on "OK"
In the "Data Factory Settings" tab, copy paste the corresponding values that you got whenyou ran the script in Step 2 and click on "OK".
In the "Summary" tab, once the validation passes, click on "OK".
You will be able to see the application getting deployed on the dashboard.

#### Step 4

##### Kickstart an ADF pipeline

Once the deployment completes, you can click on the app and on the overview tab, click on the "Managed Resource Group".
Click on the "Data Factory" that has been created under the managed resource group.
In the Data Factory window that opens up, click on "Author & Monitor" under Quick Links section.
In the new tab that opens up for the data factory, click on the "Author" icon on the top left.
Choose the "O365ToADLSPipeline" under the "Pipelines" section, in the pipeline window that appears, click on "Trigger" and choose "Trigger Now" option.
In the "Pipeline Run" window that appears click on finish.

You can use the following powershell cmdlet to kickstart the pipeline

Invoke-AzureRmDataFactoryV2Pipeline -ResourceGroupName <resource group name> -DataFactory <data factory name> -PipelineName <pipeline name>

You can click on the "Monitor" icon on the top left and monitor the pipeline.
