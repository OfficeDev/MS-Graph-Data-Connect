# Running samples

The samples here are for showcasing how to ingest data from Office365.

The instructions below help you experiment with these samples using [Azure ARM template](https://github.com/Azure/azure-quickstart-templates).
For any sample, you can take a look at the `.\*-sample\azuredeploy.json` file to understand what azure resources we are deploying.

> **NOTE:** The samples here are not full managed app. When a customer decides to install your managed app from Azure marketplace, your app during installation, will perform steps similar to the below steps to provision resources in customer's azure subscription. For a full managed app take a look at `ManagedApp` at root of this repo.

## Deployment instructions

#### Step 1
Fire below command in shell of your choice and follow the instructions to login to your azure subscription.

```powershell
Login-AzureRmAccount
```

----------

#### Step 2
Fill in all the parameters in `.\*-sample\azuredeploy.parameters.json`.

Use the `ManagedApp\Scripts\GetAppInstallationParameters.ps1` to get values for following parameters. You can reuse same values for other samples as well.

- `destinationServicePrincipalId` is the Application Id of your service principal.
- `destinationServicePrincipalKey` is the Authentication Key you generated for your service principal.
- `destinationServicePrincipalAadId` is the `Object Id` (bash)/`Id` (powershell) you receieve when you run the following command:

#### Step 3

Finally, deploy the ARM template and create the ADF pipeline by running the deployment script.

```shell
.\Deploy-AzureResourceGroup.ps1 -ResourceGroupLocation "eastus2" -ArtifactStagingDirectory *-sample
```
