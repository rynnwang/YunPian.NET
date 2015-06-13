using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ifunction.YunPian.SDK
{
    /// <summary>
    /// Class MessageTemplate.
    /// </summary>
    public class MessageTemplate
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty(PropertyName = "tpl_id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        [JsonProperty(PropertyName = "tpl_content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty(PropertyName = "check_status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>The reason.</value>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

    }
}
