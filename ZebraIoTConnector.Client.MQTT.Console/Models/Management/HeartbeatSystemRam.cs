using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Management
{

    /// <summary>
    /// Total RAM utilization
    /// </summary>
    [DataContract]
    public class HeartbeatSystemRam
    {
        /// <summary>
        /// Used memory (In Bytes)
        /// </summary>
        /// <value>Used memory (In Bytes)</value>
        [DataMember(Name = "used", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "used")]
        public decimal? Used { get; set; }

        /// <summary>
        /// Free memory (In Bytes)
        /// </summary>
        /// <value>Free memory (In Bytes)</value>
        [DataMember(Name = "free", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "free")]
        public decimal? Free { get; set; }

        /// <summary>
        /// Total memory (In Bytes)
        /// </summary>
        /// <value>Total memory (In Bytes)</value>
        [DataMember(Name = "total", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "total")]
        public decimal? Total { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HeartbeatSystemRam {\n");
            sb.Append("  Used: ").Append(Used).Append("\n");
            sb.Append("  Free: ").Append(Free).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
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
