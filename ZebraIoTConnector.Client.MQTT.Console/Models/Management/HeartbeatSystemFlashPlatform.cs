using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Management
{

    /// <summary>
    /// Platform Flash usage
    /// </summary>
    [DataContract]
    public class HeartbeatSystemFlashPlatform
    {
        /// <summary>
        /// Used space (In Bytes)
        /// </summary>
        /// <value>Used space (In Bytes)</value>
        [DataMember(Name = "used", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "used")]
        public decimal? Used { get; set; }

        /// <summary>
        /// Free space (In Bytes)
        /// </summary>
        /// <value>Free space (In Bytes)</value>
        [DataMember(Name = "free", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "free")]
        public decimal? Free { get; set; }

        /// <summary>
        /// Total space (In Bytes)
        /// </summary>
        /// <value>Total space (In Bytes)</value>
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
            sb.Append("class HeartbeatSystemFlashPlatform {\n");
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
