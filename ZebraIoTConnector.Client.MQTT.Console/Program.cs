// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZebraIoTConnector.Client.MQTT.Console;
using ZebraIoTConnector.Client.MQTT.Console.Services;
using ZebraIoTConnector.Client.MQTT.Console.Subscriptions;
using ZebraIoTConnector.Persistence;

Console.WriteLine("Hello, World!");


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) => DependencyRegistrar.BuildServiceCollection(services));

// Regist services
using IHost host = CreateHostBuilder(args).Build();

// Execute migration scripts
using (var scope = host.Services.CreateScope())
{
    using (var context = scope.ServiceProvider.GetService<ZebraDbContext>())
    {
        context.Database.Migrate();
    }
}

// Connect to MQTT broker
var mqttClientService = new MQTTClientService();
mqttClientService.Connect("mosquitto").Wait();

Console.WriteLine("Connected!");

// Subscribe to all topics under zebra/#
mqttClientService.Subscribe($"zebra/#").Wait();

Console.WriteLine("Successfully subscribed to zebra/#");

mqttClientService.LogMessagePublished += log => Console.WriteLine(log);

// Subscribe to events
mqttClientService.ApplicationMessageReceived += async args =>
{
    try
    {
        await host.Services.GetService<ISubscriptionManager>().SubscriptionEventReceived(args);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"ERROR: Unable to manage subscription: {ex.Message}");
    }
};

Console.ReadLine();

