using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.TagData
{
    [DataContract]
    public class Data
    {
        [DataMember(Name = "CRC", EmitDefaultValue = false)]
        [JsonPropertyName("CRC")]
        public string CRC { get; set; }

        [DataMember(Name = "PC", EmitDefaultValue = false)]
        [JsonPropertyName("PC")]
        public string PC { get; set; }

        [DataMember(Name = "antenna", EmitDefaultValue = false)]
        [JsonPropertyName("antenna")]
        public int Antenna { get; set; }

        [DataMember(Name = "channel", EmitDefaultValue = false)]
        [JsonPropertyName("channel")]
        public double Channel { get; set; }

        [DataMember(Name = "eventNum", EmitDefaultValue = false)]
        [JsonPropertyName("eventNum")]
        public int EventNum { get; set; }

        [DataMember(Name = "format", EmitDefaultValue = false)]
        [JsonPropertyName("format")]
        public string Format { get; set; }

        [DataMember(Name = "idHex", EmitDefaultValue = false)]
        [JsonPropertyName("idHex")]
        public string IdHex { get; set; }
        
        [DataMember(Name = "peakRssi", EmitDefaultValue = false)]
        [JsonPropertyName("peakRssi")]
        public int PeakRssi { get; set; }

        [DataMember(Name = "phase", EmitDefaultValue = false)]
        [JsonPropertyName("phase")]
        public double Phase { get; set; }

        [DataMember(Name = "reads", EmitDefaultValue = false)]
        [JsonPropertyName("reads")]
        public int Reads { get; set; }
    }
}
