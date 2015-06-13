using Newtonsoft.Json;

namespace ifunction.YunPian.SDK
{
    /// <summary>
    /// Class AccountInfo.
    /// </summary>
    public class AccountInfo
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [JsonProperty(PropertyName = "nick")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the cellphone.
        /// </summary>
        /// <value>The cellphone.</value>
        [JsonProperty(PropertyName = "mobile")]
        public string Cellphone { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the ip white list.
        /// </summary>
        /// <value>The ip white list.</value>
        [JsonProperty(PropertyName = "ip_whitelist")]
        public string IpWhiteList { get; set; }

        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        /// <value>The API version.</value>
        [JsonProperty(PropertyName = "api_version")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        [JsonProperty(PropertyName = "balance")]
        public int Balance { get; set; }

        /// <summary>
        /// Gets or sets the balance alarm.
        /// </summary>
        /// <value>The balance alarm.</value>
        [JsonProperty(PropertyName = "alarm_balance")]
        public int BalanceAlarm { get; set; }

        /// <summary>
        /// Gets or sets the emergency contact.
        /// </summary>
        /// <value>The emergency contact.</value>
        [JsonProperty(PropertyName = "emergency_contact")]
        public string EmergencyContact { get; set; }

        /// <summary>
        /// Gets or sets the emergency cellphone.
        /// </summary>
        /// <value>The emergency cellphone.</value>
        [JsonProperty(PropertyName = "emergency_mobile")]
        public string EmergencyCellphone { get; set; }
    }
}
