// **********************************************
// Fore more information, visit: 
// https://blog.hildenco.com/2020/02/migrating-nservicebus-backends-to-azure.html
// **********************************************
using NLog.Config;
using NLog.Targets;
using NServiceBus;
using NServiceBus.DataBus;
using NServiceBus.Encryption.MessageProperty;
using NServiceBus.Features;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ATIS.Services
{
    public class EndpointConfig
    {
		// Sample initialization method
        public void Customize(EndpointConfiguration configuration)
        {
            // example initialization code
            configuration.UseSerialization<NewtonsoftSerializer>();
            configuration.EnableFeature<TimeoutManager>();
            configuration.UsePersistence<AzureStoragePersistence, StorageType.Sagas>().AssumeSecondaryIndicesExist();
            var transport = configuration.UseTransport<AzureStorageQueueTransport>();
            transport.ConnectionString(ConfigurationManager.ConnectionStrings["MyApp.Transport.ConnectionString"].ConnectionString);

            // other stuff
            // ...
        }
    }
}
