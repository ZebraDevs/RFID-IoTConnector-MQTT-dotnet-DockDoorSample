using ZebraIoTConnector.Client.MQTT.Console.Model;

namespace ZebraIoTConnector.Client.MQTT.Console.Subscriptions
{
    public interface ISubscriptionManager
    {
        void Subscribe(string topic);
        Task SubscriptionEventReceived(SubscriptionEventReceived args);
    }
}