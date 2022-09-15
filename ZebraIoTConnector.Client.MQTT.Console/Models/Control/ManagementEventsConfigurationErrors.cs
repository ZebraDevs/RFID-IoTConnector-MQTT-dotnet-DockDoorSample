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
    /// Asynchronous Management Errors
    /// </summary>
    [DataContract]
    public partial class ManagementEventsConfigurationErrors : IEquatable<ManagementEventsConfigurationErrors>
    { 
        /// <summary>
        /// Gets or Sets Cpu
        /// </summary>

        [DataMember(Name="cpu")]
        public ManagementEventsConfigurationErrorsCpu Cpu { get; set; }

        /// <summary>
        /// Gets or Sets Flash
        /// </summary>

        [DataMember(Name="flash")]
        public ManagementEventsConfigurationErrorsFlash Flash { get; set; }

        /// <summary>
        /// Gets or Sets Ram
        /// </summary>

        [DataMember(Name="ram")]
        public ManagementEventsConfigurationErrorsRam Ram { get; set; }

        /// <summary>
        /// Reader Gateway Errors
        /// </summary>
        /// <value>Reader Gateway Errors</value>

        [DataMember(Name="reader_gateway")]
        public bool? ReaderGateway { get; set; }

        /// <summary>
        /// Antenna Connect/Disconnect Alerts
        /// </summary>
        /// <value>Antenna Connect/Disconnect Alerts</value>

        [DataMember(Name="antenna")]
        public bool? Antenna { get; set; }

        /// <summary>
        /// Radio Database Error Alerts
        /// </summary>
        /// <value>Radio Database Error Alerts</value>

        [DataMember(Name="database")]
        public bool? Database { get; set; }

        /// <summary>
        /// Radio Error Alerts
        /// </summary>
        /// <value>Radio Error Alerts</value>

        [DataMember(Name="radio")]
        public bool? Radio { get; set; }

        /// <summary>
        /// Radio Control Error Alerts
        /// </summary>
        /// <value>Radio Control Error Alerts</value>

        [DataMember(Name="radio_control")]
        public bool? RadioControl { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ManagementEventsConfigurationErrors {\n");
            sb.Append("  Cpu: ").Append(Cpu).Append("\n");
            sb.Append("  Flash: ").Append(Flash).Append("\n");
            sb.Append("  Ram: ").Append(Ram).Append("\n");
            sb.Append("  ReaderGateway: ").Append(ReaderGateway).Append("\n");
            sb.Append("  Antenna: ").Append(Antenna).Append("\n");
            sb.Append("  Database: ").Append(Database).Append("\n");
            sb.Append("  Radio: ").Append(Radio).Append("\n");
            sb.Append("  RadioControl: ").Append(RadioControl).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ManagementEventsConfigurationErrors)obj);
        }

        /// <summary>
        /// Returns true if ManagementEventsConfigurationErrors instances are equal
        /// </summary>
        /// <param name="other">Instance of ManagementEventsConfigurationErrors to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ManagementEventsConfigurationErrors other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Cpu == other.Cpu ||
                    Cpu != null &&
                    Cpu.Equals(other.Cpu)
                ) && 
                (
                    Flash == other.Flash ||
                    Flash != null &&
                    Flash.Equals(other.Flash)
                ) && 
                (
                    Ram == other.Ram ||
                    Ram != null &&
                    Ram.Equals(other.Ram)
                ) && 
                (
                    ReaderGateway == other.ReaderGateway ||
                    ReaderGateway != null &&
                    ReaderGateway.Equals(other.ReaderGateway)
                ) && 
                (
                    Antenna == other.Antenna ||
                    Antenna != null &&
                    Antenna.Equals(other.Antenna)
                ) && 
                (
                    Database == other.Database ||
                    Database != null &&
                    Database.Equals(other.Database)
                ) && 
                (
                    Radio == other.Radio ||
                    Radio != null &&
                    Radio.Equals(other.Radio)
                ) && 
                (
                    RadioControl == other.RadioControl ||
                    RadioControl != null &&
                    RadioControl.Equals(other.RadioControl)
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
                    if (Cpu != null)
                    hashCode = hashCode * 59 + Cpu.GetHashCode();
                    if (Flash != null)
                    hashCode = hashCode * 59 + Flash.GetHashCode();
                    if (Ram != null)
                    hashCode = hashCode * 59 + Ram.GetHashCode();
                    if (ReaderGateway != null)
                    hashCode = hashCode * 59 + ReaderGateway.GetHashCode();
                    if (Antenna != null)
                    hashCode = hashCode * 59 + Antenna.GetHashCode();
                    if (Database != null)
                    hashCode = hashCode * 59 + Database.GetHashCode();
                    if (Radio != null)
                    hashCode = hashCode * 59 + Radio.GetHashCode();
                    if (RadioControl != null)
                    hashCode = hashCode * 59 + RadioControl.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ManagementEventsConfigurationErrors left, ManagementEventsConfigurationErrors right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ManagementEventsConfigurationErrors left, ManagementEventsConfigurationErrors right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}