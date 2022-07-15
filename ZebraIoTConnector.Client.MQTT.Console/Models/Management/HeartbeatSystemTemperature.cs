using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Management
{

    /// <summary>
    /// Reader temperature sensor readings
    /// </summary>
    [DataContract]
    public class HeartbeatSystemTemperature
    {
        /// <summary>
        /// Reader ambient temperature
        /// </summary>
        /// <value>Reader ambient temperature</value>
        [DataMember(Name = "ambient", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ambient")]
        public decimal? Ambient { get; set; }

        /// <summary>
        /// Reader PA temperature
        /// </summary>
        /// <value>Reader PA temperature</value>
        [DataMember(Name = "pa", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "pa")]
        public decimal? Pa { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HeartbeatSystemTemperature {\n");
            sb.Append("  Ambient: ").Append(Ambient).Append("\n");
            sb.Append("  Pa: ").Append(Pa).Append("\n");
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
