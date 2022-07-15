using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Management
{

    /// <summary>
    /// Asynchronous Management Events
    /// </summary>
    [DataContract]
    public class AsyncEvents<T>
    {
        /// <summary>
        /// Event type
        /// </summary>
        /// <value>Event type</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Event timestamp
        /// </summary>
        /// <value>Event timestamp</value>
        [DataMember(Name = "timestamp", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Event source
        /// </summary>
        /// <value>Event source</value>
        [DataMember(Name = "component", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "component")]
        public string Component { get; set; }

        /// <summary>
        /// Event Number
        /// </summary>
        /// <value>Event Number</value>
        [DataMember(Name = "eventNum", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "eventNum")]
        public decimal? EventNum { get; set; }

        /// <summary>
        /// Event Data
        /// </summary>
        /// <value>Event Data</value>
        [DataMember(Name = "data", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }



        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AsyncEvents {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Component: ").Append(Component).Append("\n");
            sb.Append("  EventNum: ").Append(EventNum).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
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
