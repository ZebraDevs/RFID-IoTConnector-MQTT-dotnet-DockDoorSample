// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZebraIoTConnector.Client.MQTT.Console;
using ZebraIoTConnector.Client.MQTT.Console.Configuration;
using ZebraIoTConnector.Client.MQTT.Console.Subscriptions;
using ZebraIoTConnector.Persistence;

Console.WriteLine("Hello, World!");


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) => DependencyRegistrar.BuildServiceCollection(services));

// Regist services
using IHost host = CreateHostBuilder(args).Build();

ISubscriptionManager subscriptionManager;
IConfigurationManager configurationManager;
using (var scope = host.Services.CreateScope())
{
    // Execute migration scripts
    using (var context = scope.ServiceProvider.GetService<ZebraDbContext>())
    {
        context.Database.Migrate();
    }
}
using (var scope = host.Services.CreateScope())
{
    subscriptionManager = scope.ServiceProvider.GetService<ISubscriptionManager>() ?? throw new ArgumentNullException();
    configurationManager = scope.ServiceProvider.GetService<IConfigurationManager>() ?? throw new ArgumentNullException();

    // Download config & operation mode to reader registered as Equipments
    configurationManager.ConfigureReaders();
    // Subscribe to all Zebra topics
    subscriptionManager.Subscribe("zebra/#");

    Console.ReadLine();
}


