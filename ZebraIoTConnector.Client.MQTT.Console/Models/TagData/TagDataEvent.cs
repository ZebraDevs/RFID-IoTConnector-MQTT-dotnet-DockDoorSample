using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.TagData
{
    [DataContract]
    public class TagDataEvent
    {
        [DataMember(Name = "data", EmitDefaultValue = false)]
        [JsonProperty("data")]
        public Data Data { get; set; }

        [DataMember(Name = "timestamp", EmitDefaultValue = false)]
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        [JsonProperty("type")]
        public string Type { get; set; }
    }

}
