using Microsoft.Extensions.DependencyInjection;
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
            services.AddDbContext<ZebraDbContext>();
            services.AddScoped<IEquipmentRegistryService, EquipmentRegistryService>();
            services.AddScoped<IMaterialMovementService, MaterialMovementService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IFXReaderManager, FXReaderManager>();

            services.AddScoped<ISubscriptionEventParser, SubscriptionEventParser>();
            services.AddScoped<ISubscriptionManager, SubscriptionManager>();

            services.AddScoped<IFXReaderManager, FXReaderManager>();
        }
    }
}
