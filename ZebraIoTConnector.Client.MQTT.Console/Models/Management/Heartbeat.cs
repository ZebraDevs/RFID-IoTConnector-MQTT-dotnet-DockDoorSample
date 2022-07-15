using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Management
{

    /// <summary>
    /// Heartbeat Event
    /// </summary>
    [DataContract]
    public class Heartbeat
    {
        /// <summary>
        /// Gets or Sets RadioControl
        /// </summary>
        [DataMember(Name = "radio_control", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "radio_control")]
        public HeartbeatRadioControl RadioControl { get; set; }

        /// <summary>
        /// Gets or Sets ReaderGateway
        /// </summary>
        [DataMember(Name = "reader_gateway", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reader_gateway")]
        public HeartbeatReaderGateway ReaderGateway { get; set; }

        /// <summary>
        /// Gets or Sets System
        /// </summary>
        [DataMember(Name = "system", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "system")]
        public HeartbeatSystem System { get; set; }

        /// <summary>
        /// userapp Heartbeat Fields
        /// </summary>
        /// <value>userapp Heartbeat Fields</value>
        [DataMember(Name = "userapps", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "userapps")]
        public List<HeartbeatUserapps> Userapps { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Heartbeat {\n");
            sb.Append("  RadioControl: ").Append(RadioControl).Append("\n");
            sb.Append("  ReaderGateway: ").Append(ReaderGateway).Append("\n");
            sb.Append("  System: ").Append(System).Append("\n");
            sb.Append("  Userapps: ").Append(Userapps).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
