# Running samples

The samples here are for showcasing how to ingest data from Office365.

The instructions below help you experiment with these samples using [Azure ARM template](https://github.com/Azure/azure-quickstart-templates).
For any sample, you can take a look at the `.\*-sample\azuredeploy.json` file to understand what azure resources we are deploying.

> **NOTE:** The samples here are not full managed app. When a customer decides to install your managed app from Azure marketplace, your app during installation, will perform steps similar to the below steps to provision resources in customer's azure subscription. For a full managed app take a look at `ManagedApp` at root of this repo.

## Deployment instructions

----------

#### Step 0

Bash

Before you start on the instructions below, please ensure that you have [node and npm](https://docs.npmjs.com/getting-started/installing-node), [jq](https://stedolan.github.io/jq/download/) and [azure-cli](https://docs.microsoft.com/en-us/azure/cli-install-nodejs) installed.

Powershell

Before you start on the instructions below, please ensure that you have [Azure Powershell](https://docs.microsoft.com/en-us/powershell/azure/install-azurerm-ps?view=azurermps-4.4.0) installed.

----------

#### Step 1
Fire below command in shell of your choice and follow the instructions to login to your azure subscription.

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
Fill in all the parameters in `.\*-sample\azuredeploy.parameters.json`.

Use the `ManagedApp\Scripts\GetAppInstallationParameters.ps1` to get values for following parameters. You can reuse same values for other samples as well.

- `destinationServicePrincipalId` is the Application Id of your service principal.
- `destinationServicePrincipalKey` is the Authentication Key you generated for your service principal.
- `destinationServicePrincipalAadId` is the `Object Id` (bash)/`Id` (powershell) you receieve when you run the following command:

----------

#### Step 3

Finally, deploy the ARM template and create the ADF pipeline by running the deployment script.

Bash
```bash
./azure-group-deploy.sh -l eastus2 -a *-sample
```

Powershell
```bash
.\Deploy-AzureResourceGroup.ps1 -ResourceGroupLocation eastus2  -ArtifactStagingDirectory *-sample
```

