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
    /// Asynchronous Management Warnings
    /// </summary>
    [DataContract]
    public partial class ManagementEventsConfigurationWarnings : IEquatable<ManagementEventsConfigurationWarnings>
    { 
        /// <summary>
        /// Gets or Sets Cpu
        /// </summary>

        [DataMember(Name="cpu")]
        public ManagementEventsConfigurationWarningsCpu Cpu { get; set; }

        /// <summary>
        /// Gets or Sets Flash
        /// </summary>

        [DataMember(Name="flash")]
        public ManagementEventsConfigurationWarningsFlash Flash { get; set; }

        /// <summary>
        /// Gets or Sets Ram
        /// </summary>

        [DataMember(Name="ram")]
        public ManagementEventsConfigurationWarningsRam Ram { get; set; }

        /// <summary>
        /// NTP Warning Alert
        /// </summary>
        /// <value>NTP Warning Alert</value>

        [DataMember(Name="ntp")]
        public OneOfManagementEventsConfigurationWarningsNtp Ntp { get; set; }

        /// <summary>
        /// Gets or Sets Temperature
        /// </summary>

        [DataMember(Name="temperature")]
        public ManagementEventsConfigurationWarningsTemperature Temperature { get; set; }

        /// <summary>
        /// Radio Database warnings
        /// </summary>
        /// <value>Radio Database warnings</value>

        [DataMember(Name="database")]
        public bool? Database { get; set; }

        /// <summary>
        /// NGE warnings
        /// </summary>
        /// <value>NGE warnings</value>

        [DataMember(Name="radio_api")]
        public bool? RadioApi { get; set; }

        /// <summary>
        /// Radio Control warnings
        /// </summary>
        /// <value>Radio Control warnings</value>

        [DataMember(Name="radio_control")]
        public bool? RadioControl { get; set; }

        /// <summary>
        /// Reader Gateway Errors
        /// </summary>
        /// <value>Reader Gateway Errors</value>

        [DataMember(Name="reader_gateway")]
        public bool? ReaderGateway { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ManagementEventsConfigurationWarnings {\n");
            sb.Append("  Cpu: ").Append(Cpu).Append("\n");
            sb.Append("  Flash: ").Append(Flash).Append("\n");
            sb.Append("  Ram: ").Append(Ram).Append("\n");
            sb.Append("  Ntp: ").Append(Ntp).Append("\n");
            sb.Append("  Temperature: ").Append(Temperature).Append("\n");
            sb.Append("  Database: ").Append(Database).Append("\n");
            sb.Append("  RadioApi: ").Append(RadioApi).Append("\n");
            sb.Append("  RadioControl: ").Append(RadioControl).Append("\n");
            sb.Append("  ReaderGateway: ").Append(ReaderGateway).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ManagementEventsConfigurationWarnings)obj);
        }

        /// <summary>
        /// Returns true if ManagementEventsConfigurationWarnings instances are equal
        /// </summary>
        /// <param name="other">Instance of ManagementEventsConfigurationWarnings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ManagementEventsConfigurationWarnings other)
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
                    Ntp == other.Ntp ||
                    Ntp != null &&
                    Ntp.Equals(other.Ntp)
                ) && 
                (
                    Temperature == other.Temperature ||
                    Temperature != null &&
                    Temperature.Equals(other.Temperature)
                ) && 
                (
                    Database == other.Database ||
                    Database != null &&
                    Database.Equals(other.Database)
                ) && 
                (
                    RadioApi == other.RadioApi ||
                    RadioApi != null &&
                    RadioApi.Equals(other.RadioApi)
                ) && 
                (
                    RadioControl == other.RadioControl ||
                    RadioControl != null &&
                    RadioControl.Equals(other.RadioControl)
                ) && 
                (
                    ReaderGateway == other.ReaderGateway ||
                    ReaderGateway != null &&
                    ReaderGateway.Equals(other.ReaderGateway)
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
                    if (Ntp != null)
                    hashCode = hashCode * 59 + Ntp.GetHashCode();
                    if (Temperature != null)
                    hashCode = hashCode * 59 + Temperature.GetHashCode();
                    if (Database != null)
                    hashCode = hashCode * 59 + Database.GetHashCode();
                    if (RadioApi != null)
                    hashCode = hashCode * 59 + RadioApi.GetHashCode();
                    if (RadioControl != null)
                    hashCode = hashCode * 59 + RadioControl.GetHashCode();
                    if (ReaderGateway != null)
                    hashCode = hashCode * 59 + ReaderGateway.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ManagementEventsConfigurationWarnings left, ManagementEventsConfigurationWarnings right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ManagementEventsConfigurationWarnings left, ManagementEventsConfigurationWarnings right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
