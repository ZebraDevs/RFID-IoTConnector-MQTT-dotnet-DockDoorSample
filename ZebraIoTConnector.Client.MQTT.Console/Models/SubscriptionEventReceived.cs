using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZebraIoTConnector.Client.MQTT.Console.Model
{
    public class SubscriptionEventReceived
    {
        public SubscriptionEventReceived(string clientId, string topic, string v)
        {
            ClientId = clientId;
            Topic = topic;
            Payload = v;
        }

        public string ClientId { get; }
        public string Topic { get; }
        public string Payload { get; }
    }
}
