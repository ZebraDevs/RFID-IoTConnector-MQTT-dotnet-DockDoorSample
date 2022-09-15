namespace ZebraIoTConnector.Client.MQTT.Console.Configuration
{
    public interface IConfigurationManager
    {
        [Obsolete]
        void ConfigureReaders();
        void ConfigureReader(string clientId);
    }
}