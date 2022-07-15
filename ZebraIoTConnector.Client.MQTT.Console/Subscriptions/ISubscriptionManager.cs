using ZebraIoTConnector.Client.MQTT.Console.Model;

namespace ZebraIoTConnector.Client.MQTT.Console.Subscriptions
{
    public interface ISubscriptionManager
    {
        Task SubscriptionEventReceived(SubscriptionEventReceived args);
    }
}