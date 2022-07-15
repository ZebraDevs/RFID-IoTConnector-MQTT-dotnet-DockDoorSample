using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Management
{

    /// <summary>
    /// NTP synchronous status
    /// </summary>
    [DataContract]
    public class HeartbeatSystemNtp
    {
        /// <summary>
        /// current NTP offset in ms
        /// </summary>
        /// <value>current NTP offset in ms</value>
        [DataMember(Name = "offset", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "offset")]
        public decimal? Offset { get; set; }

        /// <summary>
        /// last 8 NTP sync status
        /// </summary>
        /// <value>last 8 NTP sync status</value>
        [DataMember(Name = "reach", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reach")]
        public decimal? Reach { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HeartbeatSystemNtp {\n");
            sb.Append("  Offset: ").Append(Offset).Append("\n");
            sb.Append("  Reach: ").Append(Reach).Append("\n");
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
