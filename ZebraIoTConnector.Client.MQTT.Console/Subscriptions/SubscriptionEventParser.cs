using IO.Swagger.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ZebraIoTConnector.Client.MQTT.Console.Model;
using ZebraIoTConnector.Client.MQTT.Console.Model.Control;
using ZebraIoTConnector.Client.MQTT.Console.Models.Control;
using ZebraIoTConnector.Client.MQTT.Console.Models.Management;
using ZebraIoTConnector.Client.MQTT.Console.Models.TagData;
using ZebraIoTConnector.Client.MQTT.Console.Publisher;
using ZebraIoTConnector.DomainModel.Reader;
using ZebraIoTConnector.FXReaderInterface;

namespace ZebraIoTConnector.Client.MQTT.Console.Subscriptions
{
    public class SubscriptionEventParser : ISubscriptionEventParser
    {
        private readonly IFXReaderManager fXReaderManager;
        private readonly IPublisherManager publisherManager;

        public SubscriptionEventParser(IFXReaderManager fXReaderManager, IPublisherManager publisherManager)
        {
            this.fXReaderManager = fXReaderManager ?? throw new ArgumentNullException(nameof(fXReaderManager));
            this.publisherManager = publisherManager ?? throw new ArgumentNullException(nameof(publisherManager));
        }
        public void TagDataEventParser(SubscriptionEventReceived args)
        {
            var token = JToken.Parse(args.Payload);
            List<TagDataEvent> result = new List<TagDataEvent>();
            if (token is JArray)
                result = JsonConvert.DeserializeObject<List<TagDataEvent>>(args.Payload);
            else
                result = new List<TagDataEvent>() { JsonConvert.DeserializeObject<TagDataEvent>(args.Payload) };

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

        public void AllTopicsResponseParser(SubscriptionEventReceived args)
        {
            var result = JsonConvert.DeserializeObject<RAWMQTTResponses>(args.Payload);

            if (result.Response.HasValue && result.Response.Value == RAWMQTTResponses.ResponseEnum.FailureEnum)
            {
                // Ignore set_appled to avoid loops
                // Ignore start/stop. At the startup both command are issued to read again everything
                // -> In this case, one of these will go in error as the reading might be stopped or started already.
                if (result.Command == "set_appled" || result.Command == "start" || result.Command == "stop")
                    return;

                // Flash the red light for few seconds to highlight that something went wrong
                publisherManager.Publish($"zebra/{args.ClientId}/ctrl/cmd", "set_appled",
                    new SetAppledCommand()
                    {
                        Color = SetAppledCommand.ColorEnum.RedEnum,
                        Seconds = 10,
                        Flash = true
                    });
            }
        }
    }
}
