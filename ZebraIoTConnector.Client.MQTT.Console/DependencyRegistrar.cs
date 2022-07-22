using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using ZebraIoTConnector.Client.MQTT.Console.Configuration;
using ZebraIoTConnector.Client.MQTT.Console.Publisher;
using ZebraIoTConnector.Client.MQTT.Console.Services;
using ZebraIoTConnector.Client.MQTT.Console.Subscriptions;
using ZebraIoTConnector.FXReaderInterface;
using ZebraIoTConnector.Persistence;
using ZebraIoTConnector.Services;
namespace ZebraIoTConnector.Client.MQTT.Console
{
    public class DependencyRegistrar
    {
        // TODO: implement registration upon containers
        public static void BuildServiceCollection(IServiceCollection services)
        {
            services.AddLogging((logBuilder) => logBuilder.SetMinimumLevel(LogLevel.Trace).AddConsole());
            // DAL
            services.AddDbContext<ZebraDbContext>();
            services.AddScoped<IEquipmentRegistryService, EquipmentRegistryService>();
            services.AddScoped<IMaterialMovementService, MaterialMovementService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Managers
            services.AddScoped<IConfigurationManager, ConfigurationManager>();
            services.AddScoped<IPublisherManager, PublisherManager>();
            services.AddScoped<ISubscriptionManager, SubscriptionManager>();
            services.AddScoped<ISubscriptionEventParser, SubscriptionEventParser>();

            // Reader interface
            services.AddScoped<IFXReaderManager, FXReaderManager>();

            // MQTT Client Service
            services.AddSingleton<IMQTTClientService, MQTTClientService>();
        }
    }
}
