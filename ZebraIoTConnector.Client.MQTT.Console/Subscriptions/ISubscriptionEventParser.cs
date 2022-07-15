using ZebraIoTConnector.Client.MQTT.Console.Model;

namespace ZebraIoTConnector.Client.MQTT.Console.Subscriptions
{
    public interface ISubscriptionEventParser
    {
        void ManagementEventParser(SubscriptionEventReceived args);
        void TagDataEventParser(SubscriptionEventReceived args);
    }
}