using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Diagnostics;
using MQTTnet.Exceptions;
using System.Text;
using ZebraIoTConnector.Client.MQTT.Console.Model;

namespace ZebraIoTConnector.Client.MQTT.Console.Services
{
    public sealed class MQTTClientService : IMQTTClientService
    {
        //readonly List<Action<InspectMqttPacketEventArgs>> _messageInspectors = new();
        readonly MqttNetEventLogger _mqttNetEventLogger = new();

        IMqttClient? _mqttClient;

        public MQTTClientService()
        {
            _mqttNetEventLogger.LogMessagePublished += OnLogMessagePublished;
        }

        public event Func<SubscriptionEventReceived, Task> ApplicationMessageReceived;

        public event EventHandler? Disconnected;

        public event Action<string>? LogMessagePublished;

        public bool IsConnected => _mqttClient?.IsConnected == true;

        public async Task<bool> Connect(string server)
        {
            if (_mqttClient != null)
            {
                await _mqttClient.DisconnectAsync();
                _mqttClient.Dispose();
            }

            _mqttClient = new MqttFactory(_mqttNetEventLogger).CreateMqttClient();

            var clientOptionsBuilder = new MqttClientOptionsBuilder()
                .WithTcpServer(server)
                .WithKeepAlivePeriod(TimeSpan.FromSeconds(60));

            _mqttClient.ApplicationMessageReceivedAsync += OnApplicationMessageReceived;
            //_mqttClient.InspectPackage += OnInspectPackage;
            _mqttClient.DisconnectedAsync += OnDisconnected;

            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(120));
            try
            {
                var result = await _mqttClient.ConnectAsync(clientOptionsBuilder.Build(), timeout.Token);
                return result.ResultCode == MqttClientConnectResultCode.Success;
            }
            catch (OperationCanceledException)
            {
                if (timeout.IsCancellationRequested)
                {
                    throw new MqttCommunicationTimedOutException();
                }

                throw;
            }
        }

        public Task Disconnect()
        {
            ThrowIfNotConnected();

            return _mqttClient.DisconnectAsync();
        }

        public async Task<bool> Publish(string topic, string payload)
        {
            ThrowIfNotConnected();

            var applicationMessageBuilder = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload);

            var result = await _mqttClient!.PublishAsync(applicationMessageBuilder.Build());
            return true;
        }

        //public void RegisterMessageInspectorHandler(Action<InspectMqttPacketEventArgs> handler)
        //{
        //    if (handler == null)
        //    {
        //        throw new ArgumentNullException(nameof(handler));
        //    }

        //    _messageInspectors.Add(handler);
        //}

        public async Task<bool> Subscribe(string topic)
        {
            ThrowIfNotConnected();

            var topicFilter = new MqttTopicFilterBuilder()
                .WithTopic(topic)
                .Build();

            var subscribeOptionsBuilder = new MqttClientSubscribeOptionsBuilder().WithTopicFilter(topicFilter);

            var subscribeOptions = subscribeOptionsBuilder.Build();

            var subscribeResult = await _mqttClient.SubscribeAsync(subscribeOptions).ConfigureAwait(false);

            return true;
        }

        public async Task<bool> Unsubscribe(string topic)
        {
            ThrowIfNotConnected();

            var unsubscribeResult = await _mqttClient.UnsubscribeAsync(topic);

            return true;
        }

        Task OnApplicationMessageReceived(MqttApplicationMessageReceivedEventArgs eventArgs)
        {

            return ApplicationMessageReceived.Invoke(new SubscriptionEventReceived(eventArgs.ApplicationMessage.Topic, Encoding.UTF8.GetString(eventArgs.ApplicationMessage.Payload)));
        }

        Task OnDisconnected(MqttClientDisconnectedEventArgs eventArgs)
        {
            Disconnected?.Invoke(this, eventArgs);

            return Task.CompletedTask;
        }

        //Task OnInspectPackage(InspectMqttPacketEventArgs eventArgs)
        //{
        //    foreach (var messageInspector in _messageInspectors)
        //    {
        //        messageInspector.Invoke(eventArgs);
        //    }

        //    return Task.CompletedTask;
        //}

        void OnLogMessagePublished(object? sender, MqttNetLogMessagePublishedEventArgs e)
        {
            LogMessagePublished?.Invoke(e.LogMessage.Message);
        }

        void ThrowIfNotConnected()
        {
            if (_mqttClient == null || !_mqttClient.IsConnected)
            {
                throw new InvalidOperationException("The MQTT client is not connected.");
            }
        }
    }
}
