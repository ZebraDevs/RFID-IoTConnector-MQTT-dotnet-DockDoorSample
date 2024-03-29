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
    /// Configuration of HTTP Post Basic Authentication
    /// </summary>
    [DataContract]
    public partial class HttpPostBasicAuthenticationV1 : IEquatable<HttpPostBasicAuthenticationV1>
    { 
        /// <summary>
        /// Basic Authentication Username
        /// </summary>
        /// <value>Basic Authentication Username</value>
        [Required]

        [DataMember(Name="username")]
        public string Username { get; set; }

        /// <summary>
        /// Basic Authentication Password
        /// </summary>
        /// <value>Basic Authentication Password</value>
        [Required]

        [DataMember(Name="password")]
        public string Password { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HttpPostBasicAuthenticationV1 {\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
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
            return obj.GetType() == GetType() && Equals((HttpPostBasicAuthenticationV1)obj);
        }

        /// <summary>
        /// Returns true if HttpPostBasicAuthenticationV1 instances are equal
        /// </summary>
        /// <param name="other">Instance of HttpPostBasicAuthenticationV1 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HttpPostBasicAuthenticationV1 other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Username == other.Username ||
                    Username != null &&
                    Username.Equals(other.Username)
                ) && 
                (
                    Password == other.Password ||
                    Password != null &&
                    Password.Equals(other.Password)
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
                    if (Username != null)
                    hashCode = hashCode * 59 + Username.GetHashCode();
                    if (Password != null)
                    hashCode = hashCode * 59 + Password.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(HttpPostBasicAuthenticationV1 left, HttpPostBasicAuthenticationV1 right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HttpPostBasicAuthenticationV1 left, HttpPostBasicAuthenticationV1 right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
