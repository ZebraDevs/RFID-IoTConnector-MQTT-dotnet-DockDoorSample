using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.Client.MQTT.Console.Model.Control;
using ZebraIoTConnector.Client.MQTT.Console.Services;

namespace ZebraIoTConnector.Client.MQTT.Console.Publisher
{
    public class PublisherManager : IPublisherManager
    {
        private readonly IMQTTClientService mqttClientService;

        public PublisherManager(IMQTTClientService mqttClientService)
        {
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

        public void Publish(string topic, RAWMQTTCommand command)
        {
            CheckIfConnected();

            mqttClientService.Publish(topic, command.ToJson());

            System.Console.WriteLine($"Message Successfully published to {topic}");
        }
    }
}
