using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Control
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class SetAppledCommand : IEquatable<SetAppledCommand>
    {
        /// <summary>
        /// The color of the LED (red, amber, green)
        /// </summary>
        /// <value>The color of the LED (red, amber, green)</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ColorEnum
        {
            /// <summary>
            /// Enum RedEnum for red
            /// </summary>
            [EnumMember(Value = "red")]
            RedEnum = 0,
            /// <summary>
            /// Enum AmberEnum for amber
            /// </summary>
            [EnumMember(Value = "amber")]
            AmberEnum = 1,
            /// <summary>
            /// Enum GreenEnum for green
            /// </summary>
            [EnumMember(Value = "green")]
            GreenEnum = 2
        }

        /// <summary>
        /// The color of the LED (red, amber, green)
        /// </summary>
        /// <value>The color of the LED (red, amber, green)</value>
        [Required]

        [DataMember(Name = "color")]
        public ColorEnum? Color { get; set; }

        /// <summary>
        /// The duration in seconds for the LED state to be in effect
        /// </summary>
        /// <value>The duration in seconds for the LED state to be in effect</value>
        [Required]

        [DataMember(Name = "seconds")]
        public int? Seconds { get; set; }

        /// <summary>
        /// A value indicating whether to flash the LED
        /// </summary>
        /// <value>A value indicating whether to flash the LED</value>
        [Required]

        [DataMember(Name = "flash")]
        public bool? Flash { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SetAppledCommand {\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  Seconds: ").Append(Seconds).Append("\n");
            sb.Append("  Flash: ").Append(Flash).Append("\n");
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
            return obj.GetType() == GetType() && Equals((SetAppledCommand)obj);
        }

        /// <summary>
        /// Returns true if SetAppledCommand instances are equal
        /// </summary>
        /// <param name="other">Instance of SetAppledCommand to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SetAppledCommand other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Color == other.Color ||
                    Color != null &&
                    Color.Equals(other.Color)
                ) &&
                (
                    Seconds == other.Seconds ||
                    Seconds != null &&
                    Seconds.Equals(other.Seconds)
                ) &&
                (
                    Flash == other.Flash ||
                    Flash != null &&
                    Flash.Equals(other.Flash)
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
                if (Color != null)
                    hashCode = hashCode * 59 + Color.GetHashCode();
                if (Seconds != null)
                    hashCode = hashCode * 59 + Seconds.GetHashCode();
                if (Flash != null)
                    hashCode = hashCode * 59 + Flash.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(SetAppledCommand left, SetAppledCommand right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SetAppledCommand left, SetAppledCommand right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
