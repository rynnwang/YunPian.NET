using Newtonsoft.Json;

namespace ifunction.YunPian.SDK
{
    /// <summary>
    /// Class ShortMessageReceipt.
    /// </summary>
    public class ShortMessageReceipt
    {
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the fee.
        /// </summary>
        /// <value>The fee.</value>
        [JsonProperty(PropertyName = "fee")]
        public int Fee { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty(PropertyName = "sid")]
        public int Id { get; set; }
    }
}
