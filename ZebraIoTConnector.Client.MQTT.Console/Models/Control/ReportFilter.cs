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
    /// Controls when and how often a tag is reported  NOTE: This cannot be set while in \&quot;INVENTORY\&quot; mode. Setting the modeSpecificSetting for interval must be used in \&quot;INVENTORY\&quot; mode.
    /// </summary>
    [DataContract]
    public partial class ReportFilter : IEquatable<ReportFilter>
    { 
        /// <summary>
        /// Duration (in seconds) to wait to report a tag again once it has already been reported It should be noted that the way the filter works is that as long as the tag is being read by the reader, it will not report unless the time since the previous report of this tag on this antenna meets the type and duration. 
        /// </summary>
        /// <value>Duration (in seconds) to wait to report a tag again once it has already been reported It should be noted that the way the filter works is that as long as the tag is being read by the reader, it will not report unless the time since the previous report of this tag on this antenna meets the type and duration. </value>
        [Required]

        [DataMember(Name="duration")]
        public int? Duration { get; set; }

        /// <summary>
        /// Configures the timeout (in seconds) by antenna or for entire radio  
        /// </summary>
        /// <value>Configures the timeout (in seconds) by antenna or for entire radio  </value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum RADIOWIDEEnum for RADIO_WIDE
            /// </summary>
            [EnumMember(Value = "RADIO_WIDE")]
            RADIOWIDEEnum = 0,
            /// <summary>
            /// Enum PERANTENNAEnum for PER_ANTENNA
            /// </summary>
            [EnumMember(Value = "PER_ANTENNA")]
            PERANTENNAEnum = 1        }

        /// <summary>
        /// Configures the timeout (in seconds) by antenna or for entire radio  
        /// </summary>
        /// <value>Configures the timeout (in seconds) by antenna or for entire radio  </value>
        [Required]

        [DataMember(Name="type")]
        public TypeEnum? Type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ReportFilter {\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ReportFilter)obj);
        }

        /// <summary>
        /// Returns true if ReportFilter instances are equal
        /// </summary>
        /// <param name="other">Instance of ReportFilter to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReportFilter other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Duration == other.Duration ||
                    Duration != null &&
                    Duration.Equals(other.Duration)
                ) && 
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
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
                    if (Duration != null)
                    hashCode = hashCode * 59 + Duration.GetHashCode();
                    if (Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ReportFilter left, ReportFilter right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReportFilter left, ReportFilter right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}