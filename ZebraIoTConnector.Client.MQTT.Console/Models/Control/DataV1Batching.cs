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
    /// Tag Data Events batching configuration
    /// </summary>
    [DataContract]
    public partial class DataV1Batching : IEquatable<DataV1Batching>
    { 
        /// <summary>
        /// Event Report interval in milliseconds
        /// </summary>
        /// <value>Event Report interval in milliseconds</value>

        [DataMember(Name="reportingInterval")]
        public decimal? ReportingInterval { get; set; }

        /// <summary>
        /// Maximum payload size in bytes
        /// </summary>
        /// <value>Maximum payload size in bytes</value>

        [Range(1, 256000)]
        [DataMember(Name="maxPayloadSizePerReport")]
        public decimal? MaxPayloadSizePerReport { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DataV1Batching {\n");
            sb.Append("  ReportingInterval: ").Append(ReportingInterval).Append("\n");
            sb.Append("  MaxPayloadSizePerReport: ").Append(MaxPayloadSizePerReport).Append("\n");
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
            return obj.GetType() == GetType() && Equals((DataV1Batching)obj);
        }

        /// <summary>
        /// Returns true if DataV1Batching instances are equal
        /// </summary>
        /// <param name="other">Instance of DataV1Batching to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DataV1Batching other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    ReportingInterval == other.ReportingInterval ||
                    ReportingInterval != null &&
                    ReportingInterval.Equals(other.ReportingInterval)
                ) && 
                (
                    MaxPayloadSizePerReport == other.MaxPayloadSizePerReport ||
                    MaxPayloadSizePerReport != null &&
                    MaxPayloadSizePerReport.Equals(other.MaxPayloadSizePerReport)
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
                    if (ReportingInterval != null)
                    hashCode = hashCode * 59 + ReportingInterval.GetHashCode();
                    if (MaxPayloadSizePerReport != null)
                    hashCode = hashCode * 59 + MaxPayloadSizePerReport.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(DataV1Batching left, DataV1Batching right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DataV1Batching left, DataV1Batching right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
