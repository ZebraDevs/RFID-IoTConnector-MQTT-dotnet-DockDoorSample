using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZebraIoTConnector.Client.MQTT.Console.Model
{
    public class SubscriptionEventReceived
    {
        public SubscriptionEventReceived(string topic, string v)
        {
            Topic = topic;
            Payload = v;
        }

        public string ClientId { get { return this.Topic.Split('/')[1]; } } // TODO: modify according to topic structure
        public string Topic { get; }
        public string Payload { get; }
    }
}
