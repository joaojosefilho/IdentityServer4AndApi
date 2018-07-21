## Create the development environment

IDE: Visual Studio 2017  
Community https://visualstudio.microsoft.com/pt-br/downloads/?rr=https%3A%2F%2Fwww.google.com.br%2F

.NetCore Version: 2.0.9  
https://github.com/dotnet/core/blob/master/release-notes/download-archives/2.0.9-download.md

Npm:
https://nodejs.org/en/download/current/

Npm Version Control on Windows:  
https://github.com/felixrieseberg/npm-windows-upgrade

Generator for ASP.NET Core projects(Don't need)  
https://github.com/OmniSharp/generator-aspnet

## Technology Version
IdentityServer4: 2.2.0  
IdentityServer4.AccessTokenValidation: 2.6.0  
Microsoft.NETCore.App: 2.0.0  
Microsoft.AspNetCore.All: 2.0.9  

## Run the project
	
The solution has two projects: IdentityServer4.API and IdentityServer4.IDP

You must run both projects at the same time.  
https://msdn.microsoft.com/en-us/library/ms165413.aspx
 
Order of Execution:  
1 - IdentityServer4.API  
2 - IdentityServer4.IDP  
 
Run the projects with the IIS plugin. When the project is run by IIS, the Visual Studio requests permission to create a certificate. Click Yes
 
If you do not want to use the IIS plugin, you can use the Kestrel  
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-2.1&tabs=aspnetcore2x
 
IdentityServer4.idp was configured for java script clients
	
Example of client Vuejs:  
https://github.com/joaojosefilho/vuejsOidcClient
	
## Documentation
IdentityServer4:  
http://docs.identityserver.io/en/release/