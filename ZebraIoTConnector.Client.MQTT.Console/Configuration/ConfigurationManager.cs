using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.Client.MQTT.Console.Model.Control;
using ZebraIoTConnector.Client.MQTT.Console.Publisher;
using ZebraIoTConnector.FXReaderInterface;

namespace ZebraIoTConnector.Client.MQTT.Console.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IFXReaderManager fXReaderManager;
        private readonly IPublisherManager publisherManager;

        public ConfigurationManager(IFXReaderManager fXReaderManager, IPublisherManager publisherManager)
        {
            this.fXReaderManager = fXReaderManager ?? throw new ArgumentNullException(nameof(fXReaderManager));
            this.publisherManager = publisherManager ?? throw new ArgumentNullException(nameof(publisherManager));
        }

        public void ConfigureReaders()
        {
            var readers = fXReaderManager.GetReaderNames();

            foreach (var reader in readers)
            {
                // Set Config
                publisherManager.Publish($"zebra/{reader}/ControlCommand", new RAWMQTTCommand()
                {
                    Command = "set_config",
                    CommandId = DateTime.Now.Ticks.ToString(),
                    Payload = JsonConvert.DeserializeObject(FXReaderManager.GetConfiguration())
                });
                System.Console.WriteLine($"set_config sent to reader {reader}");
                // Set Mode
                publisherManager.Publish($"zebra/{reader}/ControlCommand", new RAWMQTTCommand()
                {
                    Command = "set_mode",
                    CommandId = DateTime.Now.Ticks.ToString(),
                    Payload = JsonConvert.DeserializeObject(FXReaderManager.GetOperationMode())
                });
                System.Console.WriteLine($"set_mode sent to reader {reader}");
            }
        }
    }
}
