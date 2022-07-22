using ZebraIoTConnector.Client.MQTT.Console.Model;
using ZebraIoTConnector.Client.MQTT.Console.Services;

namespace ZebraIoTConnector.Client.MQTT.Console.Subscriptions
{
    public class SubscriptionManager : ISubscriptionManager
    {
        private readonly ISubscriptionEventParser subscriptionEventParser;
        private readonly IMQTTClientService mqttClientService;

        public SubscriptionManager(ISubscriptionEventParser subscriptionEventParser, IMQTTClientService mqttClientService)
        {
            this.subscriptionEventParser = subscriptionEventParser ?? throw new ArgumentNullException(nameof(subscriptionEventParser));
            this.mqttClientService = mqttClientService ?? throw new ArgumentNullException(nameof(mqttClientService));
        }

        private void CheckIfConnected()
        {
            if (!mqttClientService.IsConnected)
            {
                // Connect to MQTT broker
                mqttClientService.Connect("mosquitto").Wait();
                System.Console.WriteLine("Connected!");
            }
        }

        public void Subscribe(string topic)
        {
            CheckIfConnected();
            // Subscribe to all topics under zebra/#
            mqttClientService.Subscribe(topic).Wait();

            System.Console.WriteLine($"Successfully subscribed to {topic}");

            // Subscribe to events
            mqttClientService.ApplicationMessageReceived += async args =>
            {
                try
                {
                    await SubscriptionEventReceived(args);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"ERROR: Unable to manage subscription: {ex.Message}");
                }
            };

        }

        public Task SubscriptionEventReceived(SubscriptionEventReceived args)
        {
            // Default config:
            // zebra/{myreader}/{interface}
            // e.g.
            // zebra/FX000000/controlCommand
            // zebra/FX000000/controlResponse

            switch (args.Topic.Split('/').Last())
            {
                case "TagDataEvents":
                    subscriptionEventParser.TagDataEventParser(args);
                    break;
                case "ManagementEvents":
                    subscriptionEventParser.ManagementEventParser(args);
                    break;
                case "ControlResponse":
                    break;
                default:
                    break;
            }

            return Task.CompletedTask;
        }

    }
}
