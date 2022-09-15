using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using ZebraIoTConnector.Client.MQTT.Console.Model.Control;
using ZebraIoTConnector.Client.MQTT.Console.Models.Control;
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

        [Obsolete]
        public void ConfigureReaders()
        {
            var readers = fXReaderManager.GetReaderNames();

            readers.AsParallel().ForAll(reader =>
            {
                try
                {
                    // Set Config
                    publisherManager.Publish($"zebra/{reader}/ctrl/cmd", "set_config", JsonConvert.DeserializeObject(fXReaderManager.GetDefaultConfiguration()));
                    logger.LogInformation($"set_config sent to reader {reader}");
                    // Set Mode
                    publisherManager.Publish($"zebra/{reader}/ctrl/cmd", "set_mode", JsonConvert.DeserializeObject(fXReaderManager.GetDefaultOperationMode()));
                    logger.LogInformation($"set_mode sent to reader {reader}");

                    // Send stop and start to restart the reading
                    publisherManager.Publish($"zebra/{reader}/ctrl/cmd", "stop", new object());

                    // Make amber led flashing for few seconds, config successfully applied
                    publisherManager.Publish($"zebra/{reader}/ctrl/cmd", "set_appled",
                        new SetAppledCommand()
                        {
                            Color = SetAppledCommand.ColorEnum.AmberEnum,
                            Seconds = 2,
                            Flash = true
                        });

                    // Flash a bit before to start the reading
                    Thread.Sleep(2000);

                    // Start cloud
                    publisherManager.Publish($"zebra/{reader}/ctrl/cmd", "get_stauts", new object());

                    logger.LogInformation($"Reading Tag restarted for reader {reader}");
                }
                catch (Exception ex)
                {
                    // Error on startup => keep the led red
                    publisherManager.Publish($"zebra/{reader}/ctrl/cmd", "set_appled",
                        new SetAppledCommand()
                        {
                            Color = SetAppledCommand.ColorEnum.RedEnum,
                            Seconds = int.MaxValue,
                            Flash = true
                        });
                    throw;
                }
            });
        }

        public void ConfigureReader(string readerName)
        {
            var isReaderConfigured = fXReaderManager.IsReaderConfigured(readerName);

            try
            { 
                // Download configuration only the first time.
                if (!isReaderConfigured)
                {
                    // Set Config
                    publisherManager.Publish($"zebra/{readerName}/ctrl/cmd", "set_config", JsonConvert.DeserializeObject(fXReaderManager.GetDefaultConfiguration()));
                    logger.LogInformation($"set_config sent to reader {readerName}");
                    // Set Mode
                    publisherManager.Publish($"zebra/{readerName}/ctrl/cmd", "set_mode", JsonConvert.DeserializeObject(fXReaderManager.GetDefaultOperationMode()));
                    logger.LogInformation($"set_mode sent to reader {readerName}");

                    // Make amber led flashing for few seconds, config successfully applied
                    publisherManager.Publish($"zebra/{readerName}/ctrl/cmd", "set_appled",
                        new SetAppledCommand()
                        {
                            Color = SetAppledCommand.ColorEnum.AmberEnum,
                            Seconds = 5,
                            Flash = true
                        });

                    // Update reader info on db
                    fXReaderManager.SetReaderConfigured(readerName);

                    // Flash a bit before to start the reading
                    Thread.Sleep(2000);
                }

                // Send stop and start to restart the cloud reading
                publisherManager.Publish($"zebra/{readerName}/ctrl/cmd", "stop", new object());
                publisherManager.Publish($"zebra/{readerName}/ctrl/cmd", "start", new object());

                logger.LogInformation($"Reading Tag restarted for reader {readerName}");
            }
            catch (Exception ex)
            {
                // Error on startup => keep the led red
                publisherManager.Publish($"zebra/{readerName}/ctrl/cmd", "set_appled",
                    new SetAppledCommand()
                    {
                        Color = SetAppledCommand.ColorEnum.RedEnum,
                        Seconds = int.MaxValue,
                        Flash = true
                    });
                throw;
            }

        }
    }
}
