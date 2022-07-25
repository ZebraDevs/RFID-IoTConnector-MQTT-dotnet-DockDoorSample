using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ZebraIoTConnector.Client.MQTT.Console.Model.Control;
using ZebraIoTConnector.Client.MQTT.Console.Publisher;
using ZebraIoTConnector.FXReaderInterface;

namespace ZebraIoTConnector.Client.MQTT.Console.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly ILogger<ConfigurationManager> logger;
        private readonly IFXReaderManager fXReaderManager;
        private readonly IPublisherManager publisherManager;

        public ConfigurationManager(ILogger<ConfigurationManager> logger, IFXReaderManager fXReaderManager, IPublisherManager publisherManager)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.fXReaderManager = fXReaderManager ?? throw new ArgumentNullException(nameof(fXReaderManager));
            this.publisherManager = publisherManager ?? throw new ArgumentNullException(nameof(publisherManager));
        }

        public void ConfigureReaders()
        {
            var readers = fXReaderManager.GetReaderNames();

            foreach (var reader in readers)
            {
                // Set Config
                publisherManager.Publish($"zebra/{reader}/ctrl/cmd", new RAWMQTTCommand()
                {
                    Command = "set_config",
                    CommandId = DateTime.Now.Ticks.ToString(),
                    Payload = JsonConvert.DeserializeObject(FXReaderManager.GetConfiguration())
                });
                logger.LogInformation($"set_config sent to reader {reader}");
                // Set Mode
                publisherManager.Publish($"zebra/{reader}/ctrl/cmd", new RAWMQTTCommand()
                {
                    Command = "set_mode",
                    CommandId = DateTime.Now.Ticks.ToString(),
                    Payload = JsonConvert.DeserializeObject(FXReaderManager.GetOperationMode())
                });
                logger.LogInformation($"set_mode sent to reader {reader}");

                // Send stop and start to restart the reading
                publisherManager.Publish($"zebra/{reader}/ctrl/cmd", new RAWMQTTCommand()
                {
                    Command = "stop",
                    CommandId = DateTime.Now.Ticks.ToString(),
                    Payload = new object()
                });
                publisherManager.Publish($"zebra/{reader}/ctrl/cmd", new RAWMQTTCommand()
                {
                    Command = "start",
                    CommandId = DateTime.Now.Ticks.ToString(),
                    Payload = new object()
                });
                logger.LogInformation($"Reading Tag restarted for reader {reader}");
            }
        }
    }
}
