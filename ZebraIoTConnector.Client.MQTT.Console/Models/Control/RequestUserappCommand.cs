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
    /// Send request to userapp
    /// </summary>
    [DataContract]
    public partial class RequestUserappCommand : IEquatable<RequestUserappCommand>
    { 
        /// <summary>
        /// name of userapp to send command
        /// </summary>
        /// <value>name of userapp to send command</value>
        [Required]

        [MinLength(1)]
        [DataMember(Name="userapp")]
        public string Userapp { get; set; }

        /// <summary>
        /// custom command or data to send
        /// </summary>
        /// <value>custom command or data to send</value>
        [Required]

        [DataMember(Name="command")]
        public Object Command { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RequestUserappCommand {\n");
            sb.Append("  Userapp: ").Append(Userapp).Append("\n");
            sb.Append("  Command: ").Append(Command).Append("\n");
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
            return obj.GetType() == GetType() && Equals((RequestUserappCommand)obj);
        }

        /// <summary>
        /// Returns true if RequestUserappCommand instances are equal
        /// </summary>
        /// <param name="other">Instance of RequestUserappCommand to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RequestUserappCommand other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Userapp == other.Userapp ||
                    Userapp != null &&
                    Userapp.Equals(other.Userapp)
                ) && 
                (
                    Command == other.Command ||
                    Command != null &&
                    Command.Equals(other.Command)
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
                    if (Userapp != null)
                    hashCode = hashCode * 59 + Userapp.GetHashCode();
                    if (Command != null)
                    hashCode = hashCode * 59 + Command.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(RequestUserappCommand left, RequestUserappCommand right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RequestUserappCommand left, RequestUserappCommand right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
