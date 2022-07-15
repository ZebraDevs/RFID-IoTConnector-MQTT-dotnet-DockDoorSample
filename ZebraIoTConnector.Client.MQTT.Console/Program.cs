// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZebraIoTConnector.Client.MQTT.Console;
using ZebraIoTConnector.Client.MQTT.Console.Services;
using ZebraIoTConnector.Client.MQTT.Console.Subscriptions;

Console.WriteLine("Hello, World!");


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) => DependencyRegistrar.BuildServiceCollection(services));

using IHost host = CreateHostBuilder(args).Build();

var mqttClientService = new MQTTClientService();
mqttClientService.Connect("localhost").Wait();

Console.WriteLine("Connected!");

mqttClientService.Subscribe($"zebra/#").Wait();

Console.WriteLine("Successfully subscribed to zebra/#");

mqttClientService.LogMessagePublished += log => Console.WriteLine(log);
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

Console.ReadKey();

