﻿Introduction:
The WhoKnowsWho App reads an user interaction statistics file produced by
the MARS analytics from ADSL and store the content in a memory cache.
It uses the data to serve interactive user queries of who in your company
has the most interactions with a particular outside party.

In order to get WKW runs locally:
	1. Create a service principal on the target subscription.
		a. Azure Dashboard->Azure Active Drectory->App registrations->Create
		b. Create a Key for the service principal.  This is the client secret.
	2. Grant the service principal access right to:
		a. Azure Directory of the target subscription.
		b. Azure Data Lake store you try to access
		
	3. Customize WhoKnowsWho\Web.config with service principal created:
	    <add key="Domain" value="[Domain name for the users of your company.  Example: microsoft.com]" />
		<add key="ida:ClientId" value="[client id of the service principal created]" />
	    <add key="ida:AADInstance" value="[your aad instance.  Example: https://login.microsoftonline.com/]" />
	    <add key="ida:TenantId" value="[Your tenant ID]" />
	    <add key="ida:PostLogoutRedirectUri" value="Your post logout redirect URI" />
	    <add key="adsl:ClientId" value="[client id of the service principal created]" />
	    <add key="adsl:ClientSecret" value="[client secret of the service principal created]" />
	    <add key="adsl:TenantId" value="[Your tenant ID]" />
	    <add key="adsl:AccountName" value="[the name of the ADSL account where the activity file is in]" />
	    <add key="adsl:Path" value="[agreed upon path for the activity file.]" />
	4. Build the App.
	5. If you see package reference errors, try to customize NuGet path.
		a. https://docs.microsoft.com/en-us/nuget/schema/nuget-config-file

To deploy to Azure:
	1. The easiest way is to publish through Visual Studio.
		a. Right client WhoKnowsWho project under SolutionExplorer and select publish.
		b. In Profile tab, select Microsoft Azure App Service.
		c. Select your Subscription.  Use an existing or make a new WebApp
        d. Make sure you enable SSL for the WebApp.