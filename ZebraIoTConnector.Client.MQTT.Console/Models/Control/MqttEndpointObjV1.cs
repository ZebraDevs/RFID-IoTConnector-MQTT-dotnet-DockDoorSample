/*
 * RAW MQTT Payloads
 *
 *  
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{ 
    /// <summary>
    /// Configuration of MQTT Endpoint
    /// </summary>
    [DataContract]
    public partial class MqttEndpointObjV1 : IEquatable<MqttEndpointObjV1>
    { 
        /// <summary>
        /// Host name of the MQTT Connection
        /// </summary>
        /// <value>Host name of the MQTT Connection</value>
        [Required]

        [DataMember(Name="hostName")]
        public string HostName { get; set; }

        /// <summary>
        /// Port Number of the MQTT Connection
        /// </summary>
        /// <value>Port Number of the MQTT Connection</value>
        [Required]

        [DataMember(Name="port")]
        public int? Port { get; set; }

        /// <summary>
        /// type of protocol to be used. If not provided tcp or ssl determined from enableSecurity flag.
        /// </summary>
        /// <value>type of protocol to be used. If not provided tcp or ssl determined from enableSecurity flag.</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ProtocolEnum
        {
            /// <summary>
            /// Enum TcpEnum for tcp
            /// </summary>
            [EnumMember(Value = "tcp")]
            TcpEnum = 0,
            /// <summary>
            /// Enum SslEnum for ssl
            /// </summary>
            [EnumMember(Value = "ssl")]
            SslEnum = 1,
            /// <summary>
            /// Enum WsEnum for ws
            /// </summary>
            [EnumMember(Value = "ws")]
            WsEnum = 2,
            /// <summary>
            /// Enum WssEnum for wss
            /// </summary>
            [EnumMember(Value = "wss")]
            WssEnum = 3        }

        /// <summary>
        /// type of protocol to be used. If not provided tcp or ssl determined from enableSecurity flag.
        /// </summary>
        /// <value>type of protocol to be used. If not provided tcp or ssl determined from enableSecurity flag.</value>

        [DataMember(Name="protocol")]
        public ProtocolEnum? Protocol { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MqttEndpointObjV1 {\n");
            sb.Append("  HostName: ").Append(HostName).Append("\n");
            sb.Append("  Port: ").Append(Port).Append("\n");
            sb.Append("  Protocol: ").Append(Protocol).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((MqttEndpointObjV1)obj);
        }

        /// <summary>
        /// Returns true if MqttEndpointObjV1 instances are equal
        /// </summary>
        /// <param name="other">Instance of MqttEndpointObjV1 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MqttEndpointObjV1 other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    HostName == other.HostName ||
                    HostName != null &&
                    HostName.Equals(other.HostName)
                ) && 
                (
                    Port == other.Port ||
                    Port != null &&
                    Port.Equals(other.Port)
                ) && 
                (
                    Protocol == other.Protocol ||
                    Protocol != null &&
                    Protocol.Equals(other.Protocol)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (HostName != null)
                    hashCode = hashCode * 59 + HostName.GetHashCode();
                    if (Port != null)
                    hashCode = hashCode * 59 + Port.GetHashCode();
                    if (Protocol != null)
                    hashCode = hashCode * 59 + Protocol.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(MqttEndpointObjV1 left, MqttEndpointObjV1 right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MqttEndpointObjV1 left, MqttEndpointObjV1 right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}