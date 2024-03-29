using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Management
{

    /// <summary>
    /// Reader Gateway Heartbeat Fields
    /// </summary>
    [DataContract]
    public class HeartbeatReaderGateway
    {
        /// <summary>
        /// Reader Gateway application CPU utilization
        /// </summary>
        /// <value>Reader Gateway application CPU utilization</value>
        [DataMember(Name = "cpu", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "cpu")]
        public decimal? Cpu { get; set; }

        /// <summary>
        /// Reader Gateway application RAM utilization
        /// </summary>
        /// <value>Reader Gateway application RAM utilization</value>
        [DataMember(Name = "ram", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ram")]
        public decimal? Ram { get; set; }

        /// <summary>
        /// Reader Gateway Application uptime (days:hours:min)
        /// </summary>
        /// <value>Reader Gateway Application uptime (days:hours:min)</value>
        [DataMember(Name = "uptime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "uptime")]
        public string Uptime { get; set; }

        /// <summary>
        /// Data Events Received
        /// </summary>
        /// <value>Data Events Received</value>
        [DataMember(Name = "numDataMessagesRxed", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "numDataMessagesRxed")]
        public decimal? NumDataMessagesRxed { get; set; }

        /// <summary>
        /// Data Events sent to cloud
        /// </summary>
        /// <value>Data Events sent to cloud</value>
        [DataMember(Name = "numDataMessagesTxed", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "numDataMessagesTxed")]
        public decimal? NumDataMessagesTxed { get; set; }

        /// <summary>
        /// Total Data Events Retained
        /// </summary>
        /// <value>Total Data Events Retained</value>
        [DataMember(Name = "numDataMessagesRetained", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "numDataMessagesRetained")]
        public decimal? NumDataMessagesRetained { get; set; }

        /// <summary>
        /// Total Data Events Dropped
        /// </summary>
        /// <value>Total Data Events Dropped</value>
        [DataMember(Name = "numDataMessagesDropped", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "numDataMessagesDropped")]
        public decimal? NumDataMessagesDropped { get; set; }

        /// <summary>
        /// Management Events Sent to Cloud
        /// </summary>
        /// <value>Management Events Sent to Cloud</value>
        [DataMember(Name = "numManagementEventsTxed", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "numManagementEventsTxed")]
        public decimal? NumManagementEventsTxed { get; set; }

        /// <summary>
        /// number of Errors generated by Reader Gateway
        /// </summary>
        /// <value>number of Errors generated by Reader Gateway</value>
        [DataMember(Name = "numErrors", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "numErrors")]
        public decimal? NumErrors { get; set; }

        /// <summary>
        /// number of Warnings generated by Reader Gateway
        /// </summary>
        /// <value>number of Warnings generated by Reader Gateway</value>
        [DataMember(Name = "numWarnings", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "numWarnings")]
        public decimal? NumWarnings { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HeartbeatReaderGateway {\n");
            sb.Append("  Cpu: ").Append(Cpu).Append("\n");
            sb.Append("  Ram: ").Append(Ram).Append("\n");
            sb.Append("  Uptime: ").Append(Uptime).Append("\n");
            sb.Append("  NumDataMessagesRxed: ").Append(NumDataMessagesRxed).Append("\n");
            sb.Append("  NumDataMessagesTxed: ").Append(NumDataMessagesTxed).Append("\n");
            sb.Append("  NumDataMessagesRetained: ").Append(NumDataMessagesRetained).Append("\n");
            sb.Append("  NumDataMessagesDropped: ").Append(NumDataMessagesDropped).Append("\n");
            sb.Append("  NumManagementEventsTxed: ").Append(NumManagementEventsTxed).Append("\n");
            sb.Append("  NumErrors: ").Append(NumErrors).Append("\n");
            sb.Append("  NumWarnings: ").Append(NumWarnings).Append("\n");
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
