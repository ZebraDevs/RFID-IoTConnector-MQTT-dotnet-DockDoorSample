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
    /// 
    /// </summary>
    [DataContract]
    public partial class SetLogsCommandComponents : IEquatable<SetLogsCommandComponents>
    { 
        /// <summary>
        /// Gets or Sets ComponentName
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ComponentNameEnum
        {
            /// <summary>
            /// Enum RGEnum for RG
            /// </summary>
            [EnumMember(Value = "RG")]
            RGEnum = 0,
            /// <summary>
            /// Enum RCEnum for RC
            /// </summary>
            [EnumMember(Value = "RC")]
            RCEnum = 1        }

        /// <summary>
        /// Gets or Sets ComponentName
        /// </summary>

        [DataMember(Name="componentName")]
        public ComponentNameEnum? ComponentName { get; set; }

        /// <summary>
        /// Gets or Sets Level
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum LevelEnum
        {
            /// <summary>
            /// Enum DEBUGEnum for DEBUG
            /// </summary>
            [EnumMember(Value = "DEBUG")]
            DEBUGEnum = 0,
            /// <summary>
            /// Enum INFOEnum for INFO
            /// </summary>
            [EnumMember(Value = "INFO")]
            INFOEnum = 1,
            /// <summary>
            /// Enum WARNINGEnum for WARNING
            /// </summary>
            [EnumMember(Value = "WARNING")]
            WARNINGEnum = 2,
            /// <summary>
            /// Enum ERROREnum for ERROR
            /// </summary>
            [EnumMember(Value = "ERROR")]
            ERROREnum = 3        }

        /// <summary>
        /// Gets or Sets Level
        /// </summary>

        [DataMember(Name="level")]
        public LevelEnum? Level { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SetLogsCommandComponents {\n");
            sb.Append("  ComponentName: ").Append(ComponentName).Append("\n");
            sb.Append("  Level: ").Append(Level).Append("\n");
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
            return obj.GetType() == GetType() && Equals((SetLogsCommandComponents)obj);
        }

        /// <summary>
        /// Returns true if SetLogsCommandComponents instances are equal
        /// </summary>
        /// <param name="other">Instance of SetLogsCommandComponents to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SetLogsCommandComponents other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    ComponentName == other.ComponentName ||
                    ComponentName != null &&
                    ComponentName.Equals(other.ComponentName)
                ) && 
                (
                    Level == other.Level ||
                    Level != null &&
                    Level.Equals(other.Level)
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
                    if (ComponentName != null)
                    hashCode = hashCode * 59 + ComponentName.GetHashCode();
                    if (Level != null)
                    hashCode = hashCode * 59 + Level.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(SetLogsCommandComponents left, SetLogsCommandComponents right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SetLogsCommandComponents left, SetLogsCommandComponents right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}