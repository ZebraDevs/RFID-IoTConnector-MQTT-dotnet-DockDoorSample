using Microsoft.Extensions.Logging;
using ZebraIoTConnector.Client.MQTT.Console.Model;
using ZebraIoTConnector.Client.MQTT.Console.Services;

namespace ZebraIoTConnector.Client.MQTT.Console.Subscriptions
{
    public class SubscriptionManager : ISubscriptionManager
    {
        private readonly ILogger<SubscriptionManager> logger;
        private readonly ISubscriptionEventParser subscriptionEventParser;
        private readonly IMQTTClientService mqttClientService;

        public SubscriptionManager(ILogger<SubscriptionManager> logger, ISubscriptionEventParser subscriptionEventParser, IMQTTClientService mqttClientService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.subscriptionEventParser = subscriptionEventParser ?? throw new ArgumentNullException(nameof(subscriptionEventParser));
            this.mqttClientService = mqttClientService ?? throw new ArgumentNullException(nameof(mqttClientService));
        }

        private void CheckIfConnected()
        {
            if (!mqttClientService.IsConnected)
            {
                // Connect to MQTT broker
                mqttClientService.Connect("mosquitto").Wait();
                mqttClientService.LogMessagePublished += arg => logger.LogDebug(arg);
                logger.LogInformation("Connected!");
            }
        }

        public void Subscribe(string topic)
        {
            CheckIfConnected();
            // Subscribe to all topics under zebra/#
            mqttClientService.Subscribe(topic).Wait();

            logger.LogInformation($"Successfully subscribed to {topic}");

            // Subscribe to events
            mqttClientService.ApplicationMessageReceived += async args =>
            {
                try
                {
                    await SubscriptionEventReceived(args);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"Unable to manage subscription");
                }
            };

        }

        public Task SubscriptionEventReceived(SubscriptionEventReceived args)
        {
            // Default config:
            // zebra/{myreader}/{topic}
            // e.g.
            // zebra/FX000000/data
            // zebra/FX000000/events
            // zebra/FX000000/ctrl/res

            switch (args.Topic.Split('/').Last())
            {
                case "data":
                    subscriptionEventParser.TagDataEventParser(args);
                    break;
                case "events":
                    subscriptionEventParser.ManagementEventParser(args);
                    break;
                case "res":
                    subscriptionEventParser.AllTopicsResponseParser(args);
                    break;
                default:
                    break;
            }

            return Task.CompletedTask;
        }

    }
}
