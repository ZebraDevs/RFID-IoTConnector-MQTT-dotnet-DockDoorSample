using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.Client.MQTT.Console.Model;
using ZebraIoTConnector.Client.MQTT.Console.Models.Management;
using ZebraIoTConnector.Client.MQTT.Console.Models.TagData;
using ZebraIoTConnector.Client.MQTT.Console.Services;
using ZebraIoTConnector.DomainModel.Reader;
using ZebraIoTConnector.FXReaderInterface;

namespace ZebraIoTConnector.Client.MQTT.Console.Subscriptions
{
    public class SubscriptionManager : ISubscriptionManager
    {
        private readonly ISubscriptionEventParser subscriptionEventParser;

        public SubscriptionManager(ISubscriptionEventParser subscriptionEventParser)
        {
            this.subscriptionEventParser = subscriptionEventParser ?? throw new ArgumentNullException(nameof(subscriptionEventParser));
        }
        public Task SubscriptionEventReceived(SubscriptionEventReceived args)
        {
            // Default config:
            // zebra/{myreader}/{interface}
            // e.g.
            // zebra/FX000000/controlCommand
            // zebra/FX000000/controlResponse

            switch (args.Topic.Split('/').Last())
            {
                case "tagDataEvents":
                    subscriptionEventParser.TagDataEventParser(args);
                    break;
                case "managementEvents":
                    subscriptionEventParser.ManagementEventParser(args);
                    break;
                case "controlResponse":
                    break;
                default:
                    break;
            }

            return Task.CompletedTask;
        }

    }
}
