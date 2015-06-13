using Newtonsoft.Json;

namespace ifunction.YunPian.SDK
{
    /// <summary>
    /// Class ShortMessage.
    /// Property reference: http://www.yunpian.com/api/sms.html
    /// </summary>
    public class ShortMessage
    {
        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>The destination.</value>
        [JsonProperty(PropertyName = "mobile")]
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        [JsonProperty(PropertyName = "text")]
        public string Content { get; set; }
    }
}
