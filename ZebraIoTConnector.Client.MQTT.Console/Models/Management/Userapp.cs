using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZebraIoTConnector.Client.MQTT.Console.Models.Management
{

    /// <summary>
    /// Asynchronous custom Events from userapps
    /// </summary>
    [DataContract]
    public class Userapp
    {
        /// <summary>
        /// RAW event string from userapp
        /// </summary>
        /// <value>RAW event string from userapp</value>
        [DataMember(Name = "event", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "event")]
        public string _Event { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Userapp {\n");
            sb.Append("  _Event: ").Append(_Event).Append("\n");
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
