using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Management
{

    /// <summary>
    /// antenna connection status
    /// </summary>
    [DataContract]
    public class HeartbeatRadioControlAntennas
    {
        /// <summary>
        /// Antenna 1 connection status
        /// </summary>
        /// <value>Antenna 1 connection status</value>
        [DataMember(Name = "1", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "1")]
        public string _1 { get; set; }

        /// <summary>
        /// Antenna 2 connection status
        /// </summary>
        /// <value>Antenna 2 connection status</value>
        [DataMember(Name = "2", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "2")]
        public string _2 { get; set; }

        /// <summary>
        /// Antenna 3 connection status
        /// </summary>
        /// <value>Antenna 3 connection status</value>
        [DataMember(Name = "3", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "3")]
        public string _3 { get; set; }

        /// <summary>
        /// Antenna 4 connection status
        /// </summary>
        /// <value>Antenna 4 connection status</value>
        [DataMember(Name = "4", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "4")]
        public string _4 { get; set; }

        /// <summary>
        /// Antenna 5 connection status
        /// </summary>
        /// <value>Antenna 5 connection status</value>
        [DataMember(Name = "5", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "5")]
        public string _5 { get; set; }

        /// <summary>
        /// Antenna 6 connection status
        /// </summary>
        /// <value>Antenna 6 connection status</value>
        [DataMember(Name = "6", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "6")]
        public string _6 { get; set; }

        /// <summary>
        /// Antenna 7 connection status
        /// </summary>
        /// <value>Antenna 7 connection status</value>
        [DataMember(Name = "7", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "7")]
        public string _7 { get; set; }

        /// <summary>
        /// Antenna 8 connection status
        /// </summary>
        /// <value>Antenna 8 connection status</value>
        [DataMember(Name = "8", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "8")]
        public string _8 { get; set; }

        /// <summary>
        /// Antenna 9 connection status (only applicable to ATR7000)
        /// </summary>
        /// <value>Antenna 9 connection status (only applicable to ATR7000)</value>
        [DataMember(Name = "9", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "9")]
        public string _9 { get; set; }

        /// <summary>
        /// Antenna 10 connection status (only applicable to ATR7000)
        /// </summary>
        /// <value>Antenna 10 connection status (only applicable to ATR7000)</value>
        [DataMember(Name = "10", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "10")]
        public string _10 { get; set; }

        /// <summary>
        /// Antenna 11 connection status (only applicable to ATR7000)
        /// </summary>
        /// <value>Antenna 11 connection status (only applicable to ATR7000)</value>
        [DataMember(Name = "11", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "11")]
        public string _11 { get; set; }

        /// <summary>
        /// Antenna 12 connection status (only applicable to ATR7000)
        /// </summary>
        /// <value>Antenna 12 connection status (only applicable to ATR7000)</value>
        [DataMember(Name = "12", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "12")]
        public string _12 { get; set; }

        /// <summary>
        /// Antenna 13 connection status (only applicable to ATR7000)
        /// </summary>
        /// <value>Antenna 13 connection status (only applicable to ATR7000)</value>
        [DataMember(Name = "13", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "13")]
        public string _13 { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HeartbeatRadioControlAntennas {\n");
            sb.Append("  _1: ").Append(_1).Append("\n");
            sb.Append("  _2: ").Append(_2).Append("\n");
            sb.Append("  _3: ").Append(_3).Append("\n");
            sb.Append("  _4: ").Append(_4).Append("\n");
            sb.Append("  _5: ").Append(_5).Append("\n");
            sb.Append("  _6: ").Append(_6).Append("\n");
            sb.Append("  _7: ").Append(_7).Append("\n");
            sb.Append("  _8: ").Append(_8).Append("\n");
            sb.Append("  _9: ").Append(_9).Append("\n");
            sb.Append("  _10: ").Append(_10).Append("\n");
            sb.Append("  _11: ").Append(_11).Append("\n");
            sb.Append("  _12: ").Append(_12).Append("\n");
            sb.Append("  _13: ").Append(_13).Append("\n");
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
