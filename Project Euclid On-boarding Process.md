**Project Euclid: Private Preview On-boarding Overview**

The following document provides an overview of the Project Euclid
on-boarding process.

Quick Overview of Euclid On-boarding Process

<img src="media/image1.png" width="624" height="353" />

Learning about Euclid

**Introduction Document**

An "Intro to Euclid" document will be provided after the first Euclid
overview meeting. This document will provide a description of Euclid,
benefits of Euclid, O365 data, app development experience and customer
marketplace experience.

**Prerequisites **

The following tools and resources are required to develop your
application:

-   Azure Subscription & O365 Test Tenant: For private preview, ISVs
    will be provisioned an Azure Subscription and O365 Test Tenant by
    MSFT

-   Bash or Azure PowerShell:

    -   Bash: ISVs should ensure they have installed: [node and
        npm](https://docs.npmjs.com/getting-started/installing-node),
        [Jq](https://stedolan.github.io/jq/download/) and
        [azure-cli](https://docs.microsoft.com/en-us/azure/cli-install-nodejs)

    -   Azure PowerShell ISVs should ensure they have installed: [Azure
        PowerShell](https://docs.microsoft.com/en-us/powershell/azure/install-azurerm-ps?view=azurermps-4.4.0)

    -   Azure: ISVs should have foundational knowledge around Azure
        > Applications Development

| **Azure Tools**                                                                                    |
|----------------------------------------------------------------------------------------------------|
| [**Azure Data Factory**](https://docs.microsoft.com/en-us/azure/data-factory/)                     |
| [**Azure Data Lake Analytics **](https://docs.microsoft.com/en-us/azure/data-lake-analytics/)** ** |
| [**Azure Data Lake Analytics **](https://docs.microsoft.com/en-us/azure/data-lake-analytics/)** ** |
| [**Azure Data Lake Store **](https://docs.microsoft.com/en-us/azure/data-lake-store/)** **         |

Get Set up

**Subscriptions and Access**

MSFT will provide all ISVs an Office 365 test tenant and an Azure
subscription for private preview. ISVs can request a test tenant and an
Azure subscription from MSFT: Project Euclid Team. MSFT will send admin
credentials to the ISV Developer. Next, the ISV can request access to
the [Project Euclid GitHub
Repo](https://github.com/OfficeDev/EuclidSampleAppExternal). If an ISV
doesn't have a GitHub Repo Account, they can sign-up here at
[GitHub](https://github.com/). ISVs can send GitHub account username and
email to be added as a read only, collaborator to the GitHub Repo. MSFT
will grant read only access to the GitHub Repo. In the GitHub Repo
additional resources such as Azure template samples and Azure sample
managed app can be found.

Start Coding

**Sample Managed Application**

Once an ISV has a MSFT- Project Euclid provisioned O365 test tenant,
Azure subscription and can access the [Project Euclid Git Hub
Repo](https://github.com/OfficeDev/EuclidSampleAppExternal), they will
be ready to start following the steps to run the sample Application, by
logging into their GitHub Account and navigating to the Euclid GitHub
Repo. The ISV developer can get started with the "ISV Dev Doc" followed
by working through the step by step instructions to run the sample
managed application from end-to-end. The three primary steps of the
managed application are Data Ingestion from Euclid/Office365, Data
processing and analytics to produce intelligent data and UX to surface
the intelligent data.

**Build Application **

Once an ISV understands the sample managed application flow, they are
ready to start building their own application. ISV developers will
develop an application with test data:

1.  Clone Git repository of a demo Managed Application that has Data
    Factory

2.  Replace Application VM with your business logic

3.  Create a Solutions Template

4.  Deploy and test

5.  Publish to AppSource

Publishing Application

**Ensure Application Meets AppSource Guidelines**

Once application development is complete, ISV will navigate to
[AppSource](https://appsource.microsoft.com/en-us/partners/list-an-app)
and begin the list on AppSource process. ISV will validate that their
application meets listing
[AppSource](https://smp-cdn-prod.azureedge.net/documents/AppsourceGuidelines/Microsoft%20AppSource%20app%20review%20guidelines.pdf)[
Guidelines](https://smp-cdn-prod.azureedge.net/documents/AppsourceGuidelines/Microsoft%20AppSource%20app%20review%20guidelines.pdf).
If ISV is a partner, they must ensure app meets [AppSource Partner
Listing Guidelines
](https://smp-cdn-prod.azureedge.net/documents/Microsoft%20AppSource%20Partner%20Listing%20Guidelines.pdf).

**Submit Application**

ISV will submit application info to be published on AppSource, once the
application has been reviewed the AppSource team will reach out to the
ISV for next steps.

**AppSource On-boarding **

MSFT AppSource team will work with the ISV during the on-boarding of the
app, which includes staging, testing, and help create page to promote
app and their partners:

-   Use the Managed Applications publish interface

-   Select the policies to be enforced

-   Create SKU options and choose the support price.

Once AppSource onboarding is complete, application will be published to
AppSource.
