using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.TagData
{
    [DataContract]
    public class Data
    {
        [DataMember(Name = "eventNum", EmitDefaultValue = false)]
        [JsonPropertyName("eventNum")]
        public int EventNum;

        [DataMember(Name = "format", EmitDefaultValue = false)]
        [JsonPropertyName("format")]
        public string Format;

        [DataMember(Name = "idHex", EmitDefaultValue = false)]
        [JsonPropertyName("idHex")]
        public string IdHex;
    }
}
