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
    /// Reader version information
    /// </summary>
    [DataContract]
    public partial class GetVersionResponse : IEquatable<GetVersionResponse>
    { 
        /// <summary>
        /// Reader software version
        /// </summary>
        /// <value>Reader software version</value>
        [Required]

        [DataMember(Name="readerApplication")]
        public string ReaderApplication { get; set; }

        /// <summary>
        /// API to the radio engine
        /// </summary>
        /// <value>API to the radio engine</value>
        [Required]

        [DataMember(Name="radioApi")]
        public string RadioApi { get; set; }

        /// <summary>
        /// Firmware running on the radio
        /// </summary>
        /// <value>Firmware running on the radio</value>
        [Required]

        [DataMember(Name="radioFirmware")]
        public string RadioFirmware { get; set; }

        /// <summary>
        /// Reader radio control version
        /// </summary>
        /// <value>Reader radio control version</value>
        [Required]

        [DataMember(Name="radioControlApplication")]
        public string RadioControlApplication { get; set; }

        /// <summary>
        /// Reader operating system version
        /// </summary>
        /// <value>Reader operating system version</value>
        [Required]

        [DataMember(Name="readerOS")]
        public string ReaderOS { get; set; }

        /// <summary>
        /// Hardware version of the reader
        /// </summary>
        /// <value>Hardware version of the reader</value>
        [Required]

        [DataMember(Name="readerHardware")]
        public string ReaderHardware { get; set; }

        /// <summary>
        /// Reader boot loader version
        /// </summary>
        /// <value>Reader boot loader version</value>
        [Required]

        [DataMember(Name="readerBootLoader")]
        public string ReaderBootLoader { get; set; }

        /// <summary>
        /// Reader root file system version
        /// </summary>
        /// <value>Reader root file system version</value>
        [Required]

        [DataMember(Name="readerFileSystem")]
        public string ReaderFileSystem { get; set; }

        /// <summary>
        /// Reader cloud agent version
        /// </summary>
        /// <value>Reader cloud agent version</value>
        [Required]

        [DataMember(Name="cloudAgentApplication")]
        public string CloudAgentApplication { get; set; }

        /// <summary>
        /// FPGA running on radio (only applicable to ATR7000)
        /// </summary>
        /// <value>FPGA running on radio (only applicable to ATR7000)</value>

        [DataMember(Name="fpga")]
        public string Fpga { get; set; }

        /// <summary>
        /// Gets or Sets RevertBackFirmware
        /// </summary>
        [Required]

        [DataMember(Name="revertBackFirmware")]
        public GetVersionResponseRevertBackFirmware RevertBackFirmware { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetVersionResponse {\n");
            sb.Append("  ReaderApplication: ").Append(ReaderApplication).Append("\n");
            sb.Append("  RadioApi: ").Append(RadioApi).Append("\n");
            sb.Append("  RadioFirmware: ").Append(RadioFirmware).Append("\n");
            sb.Append("  RadioControlApplication: ").Append(RadioControlApplication).Append("\n");
            sb.Append("  ReaderOS: ").Append(ReaderOS).Append("\n");
            sb.Append("  ReaderHardware: ").Append(ReaderHardware).Append("\n");
            sb.Append("  ReaderBootLoader: ").Append(ReaderBootLoader).Append("\n");
            sb.Append("  ReaderFileSystem: ").Append(ReaderFileSystem).Append("\n");
            sb.Append("  CloudAgentApplication: ").Append(CloudAgentApplication).Append("\n");
            sb.Append("  Fpga: ").Append(Fpga).Append("\n");
            sb.Append("  RevertBackFirmware: ").Append(RevertBackFirmware).Append("\n");
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
            return obj.GetType() == GetType() && Equals((GetVersionResponse)obj);
        }

        /// <summary>
        /// Returns true if GetVersionResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of GetVersionResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetVersionResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    ReaderApplication == other.ReaderApplication ||
                    ReaderApplication != null &&
                    ReaderApplication.Equals(other.ReaderApplication)
                ) && 
                (
                    RadioApi == other.RadioApi ||
                    RadioApi != null &&
                    RadioApi.Equals(other.RadioApi)
                ) && 
                (
                    RadioFirmware == other.RadioFirmware ||
                    RadioFirmware != null &&
                    RadioFirmware.Equals(other.RadioFirmware)
                ) && 
                (
                    RadioControlApplication == other.RadioControlApplication ||
                    RadioControlApplication != null &&
                    RadioControlApplication.Equals(other.RadioControlApplication)
                ) && 
                (
                    ReaderOS == other.ReaderOS ||
                    ReaderOS != null &&
                    ReaderOS.Equals(other.ReaderOS)
                ) && 
                (
                    ReaderHardware == other.ReaderHardware ||
                    ReaderHardware != null &&
                    ReaderHardware.Equals(other.ReaderHardware)
                ) && 
                (
                    ReaderBootLoader == other.ReaderBootLoader ||
                    ReaderBootLoader != null &&
                    ReaderBootLoader.Equals(other.ReaderBootLoader)
                ) && 
                (
                    ReaderFileSystem == other.ReaderFileSystem ||
                    ReaderFileSystem != null &&
                    ReaderFileSystem.Equals(other.ReaderFileSystem)
                ) && 
                (
                    CloudAgentApplication == other.CloudAgentApplication ||
                    CloudAgentApplication != null &&
                    CloudAgentApplication.Equals(other.CloudAgentApplication)
                ) && 
                (
                    Fpga == other.Fpga ||
                    Fpga != null &&
                    Fpga.Equals(other.Fpga)
                ) && 
                (
                    RevertBackFirmware == other.RevertBackFirmware ||
                    RevertBackFirmware != null &&
                    RevertBackFirmware.Equals(other.RevertBackFirmware)
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
                    if (ReaderApplication != null)
                    hashCode = hashCode * 59 + ReaderApplication.GetHashCode();
                    if (RadioApi != null)
                    hashCode = hashCode * 59 + RadioApi.GetHashCode();
                    if (RadioFirmware != null)
                    hashCode = hashCode * 59 + RadioFirmware.GetHashCode();
                    if (RadioControlApplication != null)
                    hashCode = hashCode * 59 + RadioControlApplication.GetHashCode();
                    if (ReaderOS != null)
                    hashCode = hashCode * 59 + ReaderOS.GetHashCode();
                    if (ReaderHardware != null)
                    hashCode = hashCode * 59 + ReaderHardware.GetHashCode();
                    if (ReaderBootLoader != null)
                    hashCode = hashCode * 59 + ReaderBootLoader.GetHashCode();
                    if (ReaderFileSystem != null)
                    hashCode = hashCode * 59 + ReaderFileSystem.GetHashCode();
                    if (CloudAgentApplication != null)
                    hashCode = hashCode * 59 + CloudAgentApplication.GetHashCode();
                    if (Fpga != null)
                    hashCode = hashCode * 59 + Fpga.GetHashCode();
                    if (RevertBackFirmware != null)
                    hashCode = hashCode * 59 + RevertBackFirmware.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(GetVersionResponse left, GetVersionResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GetVersionResponse left, GetVersionResponse right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}