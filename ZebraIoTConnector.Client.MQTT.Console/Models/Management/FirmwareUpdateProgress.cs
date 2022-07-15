using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Management
{

    /// <summary>
    /// current firmware update progress
    /// </summary>
    [DataContract]
    public class FirmwareUpdateProgress
    {
        /// <summary>
        /// current firmware update status
        /// </summary>
        /// <value>current firmware update status</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// current partition update progress percentage
        /// </summary>
        /// <value>current partition update progress percentage</value>
        [DataMember(Name = "imageDownloadProgress", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "imageDownloadProgress")]
        public decimal? ImageDownloadProgress { get; set; }

        /// <summary>
        /// overall update progress percentage
        /// </summary>
        /// <value>overall update progress percentage</value>
        [DataMember(Name = "overallUpdateProgress", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "overallUpdateProgress")]
        public decimal? OverallUpdateProgress { get; set; }

        /// <summary>
        /// Gets or Sets UpdateProgressDetails
        /// </summary>
        [DataMember(Name = "updateProgressDetails", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "updateProgressDetails")]
        public OneOffirmwareUpdateProgressUpdateProgressDetails UpdateProgressDetails { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FirmwareUpdateProgress {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ImageDownloadProgress: ").Append(ImageDownloadProgress).Append("\n");
            sb.Append("  OverallUpdateProgress: ").Append(OverallUpdateProgress).Append("\n");
            sb.Append("  UpdateProgressDetails: ").Append(UpdateProgressDetails).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
