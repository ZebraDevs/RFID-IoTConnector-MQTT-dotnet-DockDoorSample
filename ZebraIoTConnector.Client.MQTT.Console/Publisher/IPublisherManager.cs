using ZebraIoTConnector.Client.MQTT.Console.Model.Control;

namespace ZebraIoTConnector.Client.MQTT.Console.Publisher
{
    public interface IPublisherManager
    {
        void Publish(string topic, string command, object payload);
    }
}