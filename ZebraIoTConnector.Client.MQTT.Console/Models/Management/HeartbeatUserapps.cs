using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Management
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class HeartbeatUserapps
    {
        /// <summary>
        /// userapp unique name
        /// </summary>
        /// <value>userapp unique name</value>
        [DataMember(Name = "appname", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "appname")]
        public string Appname { get; set; }

        /// <summary>
        /// user Application running status
        /// </summary>
        /// <value>user Application running status</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// user application CPU utilization
        /// </summary>
        /// <value>user application CPU utilization</value>
        [DataMember(Name = "cpu", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "cpu")]
        public decimal? Cpu { get; set; }

        /// <summary>
        /// user application RAM utilization
        /// </summary>
        /// <value>user application RAM utilization</value>
        [DataMember(Name = "ram", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "ram")]
        public decimal? Ram { get; set; }

        /// <summary>
        /// user Application uptime (days:hours:min)
        /// </summary>
        /// <value>user Application uptime (days:hours:min)</value>
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
        /// Data Events sent to Reader Gateway
        /// </summary>
        /// <value>Data Events sent to Reader Gateway</value>
        [DataMember(Name = "numDataMessagesTxed", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "numDataMessagesTxed")]
        public decimal? NumDataMessagesTxed { get; set; }

        /// <summary>
        /// Percentage of Buffer tobe Read
        /// </summary>
        /// <value>Percentage of Buffer tobe Read</value>
        [DataMember(Name = "incomingDataBufferPercentageRemaining", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "incomingDataBufferPercentageRemaining")]
        public decimal? IncomingDataBufferPercentageRemaining { get; set; }

        /// <summary>
        /// Percentage of Buffer tobe Sent
        /// </summary>
        /// <value>Percentage of Buffer tobe Sent</value>
        [DataMember(Name = "outgoingDataBufferPercentageRemaining", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "outgoingDataBufferPercentageRemaining")]
        public decimal? OutgoingDataBufferPercentageRemaining { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HeartbeatUserapps {\n");
            sb.Append("  Appname: ").Append(Appname).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Cpu: ").Append(Cpu).Append("\n");
            sb.Append("  Ram: ").Append(Ram).Append("\n");
            sb.Append("  Uptime: ").Append(Uptime).Append("\n");
            sb.Append("  NumDataMessagesRxed: ").Append(NumDataMessagesRxed).Append("\n");
            sb.Append("  NumDataMessagesTxed: ").Append(NumDataMessagesTxed).Append("\n");
            sb.Append("  IncomingDataBufferPercentageRemaining: ").Append(IncomingDataBufferPercentageRemaining).Append("\n");
            sb.Append("  OutgoingDataBufferPercentageRemaining: ").Append(OutgoingDataBufferPercentageRemaining).Append("\n");
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
