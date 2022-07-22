using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.Client.MQTT.Console.Model;
using ZebraIoTConnector.Client.MQTT.Console.Models.Management;
using ZebraIoTConnector.Client.MQTT.Console.Models.TagData;
using ZebraIoTConnector.DomainModel.Reader;
using ZebraIoTConnector.FXReaderInterface;

namespace ZebraIoTConnector.Client.MQTT.Console.Subscriptions
{
    public class SubscriptionEventParser : ISubscriptionEventParser
    {
        private readonly IFXReaderManager fXReaderManager;

        public SubscriptionEventParser(IFXReaderManager fXReaderManager)
        {
            this.fXReaderManager = fXReaderManager ?? throw new ArgumentNullException(nameof(fXReaderManager));
        }
        public void TagDataEventParser(SubscriptionEventReceived args)
        {
            string payload = args.Payload;
            // WORK AROUND IOT CONNECTOR BUG: Aggregated events come as array
            // while the single event comes as object
            if (!payload.StartsWith('['))
            {
                payload = "[" + args.Payload + "]";
            }

            var token = JToken.Parse(payload);
            List<TagDataEvent> result = new List<TagDataEvent>();
            if (token is JArray)
                result = JsonConvert.DeserializeObject<List<TagDataEvent>>(payload);
            else
                result = new List<TagDataEvent>() { JsonConvert.DeserializeObject<TagDataEvent>(payload) };

            if (result == null)
                return;

            var tagDataEventModel = result.Select(x => x.Data).Select(x => new TagReadEvent()
            {
                Format = x.Format,
                IdHex = x.IdHex
            }).ToList();

            fXReaderManager.TagDataEventReceived(args.ClientId, tagDataEventModel);
        }


        public void ManagementEventParser(SubscriptionEventReceived args)
        {
            AsyncEvents<dynamic>? result = JsonConvert.DeserializeObject<AsyncEvents<dynamic>>(args.Payload);

            if (result == null)
                return;

            switch (result.Type)
            {
                case "heartbeat":
                    // This sample app does not require any particular data from the heatbeat, just the client id.
                    //var message = JsonConvert.DeserializeObject<AsyncEvents<Heartbeat>>(args.Payload).Data;

                    var heatBeat = new HeartBeatEvent() { ClientId = args.ClientId };
                    fXReaderManager.HearthBeatEventReceived(heatBeat);
                    break;
                default:
                    break;
            }
        }
    }
}
