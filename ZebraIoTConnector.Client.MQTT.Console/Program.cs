// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ZebraIoTConnector.Client.MQTT.Console;
using ZebraIoTConnector.Client.MQTT.Console.Configuration;
using ZebraIoTConnector.Client.MQTT.Console.Subscriptions;
using ZebraIoTConnector.Persistence;

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) => DependencyRegistrar.BuildServiceCollection(services));

// Regist services
var builder = CreateHostBuilder(args);
using IHost host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    // Execute migration scripts
    using (var context = scope.ServiceProvider.GetService<ZebraDbContext>())
    {
        context.Database.Migrate();
    }
}

ISubscriptionManager subscriptionManager;
IConfigurationManager configurationManager;
ILogger<Program> logger;
using (var scope = host.Services.CreateScope())
{
    logger = scope.ServiceProvider.GetService<ILogger<Program>>() ?? throw new ArgumentNullException();

    try
    {
        subscriptionManager = scope.ServiceProvider.GetService<ISubscriptionManager>() ?? throw new ArgumentNullException();
        configurationManager = scope.ServiceProvider.GetService<IConfigurationManager>() ?? throw new ArgumentNullException();

        // Subscribe to all Zebra topics
        subscriptionManager.Subscribe("zebra/#");
        // Download config & operation mode to reader registered as Equipments
        configurationManager.ConfigureReaders();

        Console.ReadLine();
    }
    catch(Exception ex)
    {
        logger.LogError(ex, "Unexpected error occurred");
    }
}


