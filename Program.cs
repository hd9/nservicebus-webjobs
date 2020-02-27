// **********************************************
// Fore more information, visit: 
// https://blog.hildenco.com/2020/02/migrating-nservicebus-backends-to-azure.html
// **********************************************

// Related docs:
//   - NSB WebJobs:   https://docs.particular.net/samples/azure/webjob-host/
//   - Azure WebJobs: https://docs.microsoft.com/en-us/azure/app-service/webjobs-sdk-get-started

// Example class to show how to run NServiceBus endpoints as Azure WebJobs
public class Program
{
    static void Main()
    {
        try
        {
            var ec = new EndpointConfiguration("MyApp.NServiceBus.Backend");
            new EndpointConfig().Customize(ec);
            Task.Run(async () => await StartAsync(ec)).Wait();
        }
        catch (AggregateException e)
        {
            Console.Error.WriteLine(e);
        }
    }

    private static async Task StartAsync(EndpointConfiguration ec)
    {
        IEndpointInstance endpoint = null;
        endpoint = await Endpoint.Start(ec).ConfigureAwait(false);

        #if DEBUG
        Console.ReadLine();
        #else
        var cs = ConfigurationManager.ConnectionStrings["MyApp.NServiceBus.Backend.ConnectionString"].ConnectionString;
        var builder = new HostBuilder();
        var host = builder.Build();
        using (host)
        {
            host.Run();
        };
        #endif

        // shuts down NSB to properly release all acquired resources
        await endpoint.Stop().ConfigureAwait(false);
    }
}
