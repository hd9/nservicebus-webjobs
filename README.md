# NServiceBus Webjobs
Repo to describe how to run [NServiceBus](https://particular.net/nservicebus) backends as 
[Azure WebJobs](https://docs.microsoft.com/en-us/azure/app-service/webjobs-create).

## Complete Information
The complete use case is described on my blog at: [Migrating NServiceBus
backends to Azure WebJobs](https://blog.hildenco.com/2020/02/migrating-nservicebus-backends-to-azure.html).

However, the changes can be summarized in:
1. Transform your Class Library into a Console Application
2. Introduce a `Program.cs` file (shown in this example)
3. Make certain modifications to your `EndpointConfig.cs` (also shown in this example)

## Source Code
There are two files in this repo that deserve attention:
* `Program.cs`: shows how to intialize the enpoint asynchronously from a console application
* `EndpointConfig.cs`: a dummy example on how to initialize a simple NSB endpoint.

Why name the class `Program.cs`? Because a WebJob can be essentially a simple console
application. Keeping the standard name for .NET console applications just made
sense.

## Deployment
Deployment is also addressed on the post and can be summarized in:
1. Using PowerShell
2. Using Post-build events
3. Using Nuget packages
4. Poor's man deployment 😢

If you're using [NuGet](https://nuget.org) and bundling your deployment in a
NuGet package by using `Nuspec` files, a simplified version using can be found
at `app.nuspec` file.

## Thanks
Thanks and don't forget to visit my blog at
[blog.hildenco.com](https://blog.hildenco.com)

# License
MIT

