using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.Client.MQTT.Console.Model.Control;
using ZebraIoTConnector.Client.MQTT.Console.Services;
using ZebraIoTConnector.FXReaderInterface;

namespace ZebraIoTConnector.Client.MQTT.Console.Publisher
{
    public class PublisherManager : IPublisherManager
    {
        private readonly ILogger<PublisherManager> logger;
        private readonly IMQTTClientService mqttClientService;

        public PublisherManager(ILogger<PublisherManager> logger, IMQTTClientService mqttClientService)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
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

        public void Publish(string topic, string command, object payload)
        {
            CheckIfConnected();

            var rawCommand = new RAWMQTTCommand()
            {
                Command = command,
                CommandId = DateTime.Now.Ticks.ToString(),
                Payload = payload
            };

            mqttClientService.Publish(topic, rawCommand.ToJson());

            logger.LogInformation($"Message Successfully published to {topic}");
        }
    }
}
