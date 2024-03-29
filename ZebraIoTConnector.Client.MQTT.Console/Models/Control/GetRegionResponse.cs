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
    /// Represents the region and regulatory configuration.
    /// </summary>
    [DataContract]
    public partial class GetRegionResponse : IEquatable<GetRegionResponse>
    { 
        /// <summary>
        /// The RF region of operation
        /// </summary>
        /// <value>The RF region of operation</value>
        [Required]

        [DataMember(Name="region")]
        public string Region { get; set; }

        /// <summary>
        /// The RF regulatory standard followed
        /// </summary>
        /// <value>The RF regulatory standard followed</value>

        [DataMember(Name="regulatoryStandard")]
        public string RegulatoryStandard { get; set; }

        /// <summary>
        /// A flag indicating whether listen before talk is enabled
        /// </summary>
        /// <value>A flag indicating whether listen before talk is enabled</value>
        [Required]

        [DataMember(Name="lbtEnabled")]
        public bool? LbtEnabled { get; set; }

        /// <summary>
        /// The list of channels enabled
        /// </summary>
        /// <value>The list of channels enabled</value>

        [DataMember(Name="channelData")]
        public List<decimal?> ChannelData { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetRegionResponse {\n");
            sb.Append("  Region: ").Append(Region).Append("\n");
            sb.Append("  RegulatoryStandard: ").Append(RegulatoryStandard).Append("\n");
            sb.Append("  LbtEnabled: ").Append(LbtEnabled).Append("\n");
            sb.Append("  ChannelData: ").Append(ChannelData).Append("\n");
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
            return obj.GetType() == GetType() && Equals((GetRegionResponse)obj);
        }

        /// <summary>
        /// Returns true if GetRegionResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of GetRegionResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetRegionResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Region == other.Region ||
                    Region != null &&
                    Region.Equals(other.Region)
                ) && 
                (
                    RegulatoryStandard == other.RegulatoryStandard ||
                    RegulatoryStandard != null &&
                    RegulatoryStandard.Equals(other.RegulatoryStandard)
                ) && 
                (
                    LbtEnabled == other.LbtEnabled ||
                    LbtEnabled != null &&
                    LbtEnabled.Equals(other.LbtEnabled)
                ) && 
                (
                    ChannelData == other.ChannelData ||
                    ChannelData != null &&
                    ChannelData.SequenceEqual(other.ChannelData)
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
                    if (Region != null)
                    hashCode = hashCode * 59 + Region.GetHashCode();
                    if (RegulatoryStandard != null)
                    hashCode = hashCode * 59 + RegulatoryStandard.GetHashCode();
                    if (LbtEnabled != null)
                    hashCode = hashCode * 59 + LbtEnabled.GetHashCode();
                    if (ChannelData != null)
                    hashCode = hashCode * 59 + ChannelData.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(GetRegionResponse left, GetRegionResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GetRegionResponse left, GetRegionResponse right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
