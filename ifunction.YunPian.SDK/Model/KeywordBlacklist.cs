using Newtonsoft.Json;

namespace ifunction.YunPian.SDK
{
    /// <summary>
    /// Class KeywordBlacklist.
    /// </summary>
    public class KeywordBlacklist
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [JsonProperty(PropertyName="black_word")]
        public string Words { get; set; }
    }
}
