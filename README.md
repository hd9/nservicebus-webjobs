# NServiceBus Webjobs
Repo to describe how to run [NServiceBus](https://particular.net/nservicebus) backends as 
[Azure WebJobs](https://docs.microsoft.com/en-us/azure/app-service/webjobs-create).

## Complete Information
The complete use case is described on my blog at: [Migrating NServiceBus
backends to Azure WebJobs](https://blog.hildenco.com/2020/02/migrating-nservicebus-backends-to-azure.html).

## Source Code
I added an example on how to intialize the enpoint asynchronously at
`Program.cs`. 

Why name the class `Program.cs`? Because a WebJob can be essentially a simple console
application. Keeping the standard name for .NET console applications just made
sense.

## Deployment
Deployment is also addressed on the post. However, if you're using
[NuGet](https://nuget.org) and bundling your deployment in a NuGet package by
using `Nuspec` files, a simplified version using can be found at `app.nuspec` file.

## Thanks
Thanks and don't forget to visit my blog at
[blog.hildenco.com](https://blog.hildenco.com)

## License
MIT


