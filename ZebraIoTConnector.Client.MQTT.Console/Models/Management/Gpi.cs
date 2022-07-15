using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Management
{

    /// <summary>
    /// GPI Event
    /// </summary>
    [DataContract]
    public class Gpi
    {
        /// <summary>
        /// GPI pin number
        /// </summary>
        /// <value>GPI pin number</value>
        [DataMember(Name = "pin", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "pin")]
        public decimal? Pin { get; set; }

        /// <summary>
        /// GPI pin state
        /// </summary>
        /// <value>GPI pin state</value>
        [DataMember(Name = "state", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Gpi {\n");
            sb.Append("  Pin: ").Append(Pin).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
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
