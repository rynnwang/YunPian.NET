using System.Collections.Generic;
using Newtonsoft.Json;

namespace ifunction.YunPian.SDK
{
    /// <summary>
    /// Class ShortMessage.
    /// Property reference: http://www.yunpian.com/api/sms.html
    /// </summary>
    public class TemplateBasedShortMessage
    {
        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>The destination.</value>
        [JsonProperty(PropertyName = "mobile")]
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the template identifier.
        /// </summary>
        /// <value>The template identifier.</value>
        [JsonProperty(PropertyName = "tpl_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the template values.
        /// </summary>
        /// <value>The template values.</value>
        [JsonProperty(PropertyName = "tpl_value")]
        public Dictionary<string,string> TemplateValues { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateBasedShortMessage"/> class.
        /// </summary>
        public TemplateBasedShortMessage()
        {
            this.TemplateValues = new Dictionary<string, string>();
        }
    }
}
