using ZebraIoTConnector.Client.MQTT.Console.Model;

namespace ZebraIoTConnector.Client.MQTT.Console.Services
{
    public interface IMQTTClientService
    {
        bool IsConnected { get; }

        event Func<SubscriptionEventReceived, Task> ApplicationMessageReceived;
        event EventHandler? Disconnected;
        event Action<string>? LogMessagePublished;

        Task<bool> Connect(string server);
        Task Disconnect();
        Task<bool> Publish(string topic, string payload);
        Task<bool> Subscribe(string topic);
        Task<bool> Unsubscribe(string topic);
    }
}