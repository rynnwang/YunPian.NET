using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ifunction.YunPian.SDK
{
    partial class ApiClient
    {
        /// <summary>
        /// The resource_ SMS
        /// </summary>
        protected string resource_SMS = "sms";

        /// <summary>
        /// Sends the SMS. (发送短信)
        /// <remarks>REST API: http://yunpian.com/v1/sms/send.json </remarks>
        /// <example>
        /// Code sample: [Please change api key with your own in your codes]
        /// (示例代码: [请在你自己的代码里修改你自己的api key的值)]
        /// <code>
        /// <![CDATA[
        ///  class Program
        /// {
        ///     /// <summary>
        ///     /// Defines the entry point of the application.
        ///     /// </summary>
        ///     /// <param name="args">The arguments.</param>
        ///     /// <exception cref="System.InvalidOperationException">Failed to send SMS by template</exception>
        ///     static void Main(string[] args)
        ///     {
        ///         // Need to replace with your own API key here.
        ///         // 此处的值需要被替换成你自己的API Key
        ///         const string yourApiKey = "YourApiKey";
        ///
        ///         // Create instance of API client.
        ///         // 创建 API Client 实例
        ///         ApiClient client = new ApiClient(yourApiKey);
        ///
        ///         // Create SMS instance for sending
        ///         // 创建要发送的SMS 实例
        ///         var sms = new ShortMessage
        ///         {
        ///             // Set cellphone number of receiver
        ///             // 填写收信人手机号
        ///             Destination = "13800138000",
        ///             // Set content, which is ended by your company identity.
        ///             // 填写正文内容, 并以公司标识结尾
        ///             Content = "您的验证码是1234【云片网】"
        ///         };
        ///
        ///         // Send SMS and get response
        ///         // 发送短信并获得响应
        ///         var response = client.SendSMS(sms);
        ///
        ///         // Check if any error occurred.
        ///         // 检查是否有错误
        ///         if (response == null || response.Code != 0)
        ///         {
        ///             throw new InvalidOperationException("Failed to send SMS");
        ///         }
        ///
        ///         // Print response data for fee, id and count
        ///         // 打印返回的费用, ID和发送的记录条数
        ///         Console.WriteLine("Fee: {0}, ID: {1}, Count: {2}", response.Data.Fee, response.Data.Id, response.Data.Count);
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>BaseResponse{ShortMessageReceipt}.</returns>
        public BaseResponse<ShortMessageReceipt> SendSMS(ShortMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            var request = this.CreateFunctionUri(resource_SMS, "send");
            FillPostData(request, message);

            return GetResponse<ShortMessageReceipt>(request, "result");
        }

        /// <summary>
        /// Sends the SMS by template. (发送模板短信)
        /// <remarks>REST API: http://yunpian.com/v1/sms/tpl_send.json </remarks>
        /// <example>
        /// Code sample: [Please change api key with your own in your codes]
        /// (示例代码: [请在你自己的代码里修改你自己的api key的值)]
        /// <code>
        /// <![CDATA[
        /// class Program
        /// {
        ///     /// <summary>
        ///     /// Defines the entry point of the application.
        ///     /// </summary>
        ///     /// <param name="args">The arguments.</param>
        ///     /// <exception cref="System.InvalidOperationException">Failed to send SMS by template</exception>
        ///     static void Main(string[] args)
        ///     {
        ///         // Need to replace with your own API key here.
        ///         // 此处的值需要被替换成你自己的API Key
        ///         const string yourApiKey = "YourApiKey";
        ///
        ///         // Create instance of API client.
        ///         // 创建 API Client 实例
        ///         ApiClient client = new ApiClient(yourApiKey);
        ///
        ///         // Use default template (id= 1) here.
        ///         // 使用ID为1的默认模板
        ///         string templateId = "1";
        ///
        ///         // Template (ID = 1) uses #code# and #company#, so add values here
        ///         // 模板(ID = 1 )使用到了#code# 和 #company#, 所以在此添加对应值
        ///         Dictionary<string, string> templateValues = new Dictionary<string, string>();
        ///         templateValues.Add("code", "CODE12345");
        ///         templateValues.Add("company", "Google");
        ///
        ///         // Create SMS instance for sending
        ///         // 创建要发送的SMS 实例
        ///         var templateBasedSMS = new TemplateBasedShortMessage
        ///         {
        ///             // Set cellphone number of receiver
        ///             // 填写收信人手机号
        ///             Destination = "13800138000",
        ///             // Set template id
        ///             // 填写模板ID
        ///             TemplateId = templateId,
        ///             // Set template values of replacements
        ///             // 填写模板里占位符的值
        ///             TemplateValues = templateValues
        ///         };
        ///
        ///         // Send SMS and get response
        ///         // 发送短信并获得响应
        ///         var response = client.SendSMSByTemplate(templateBasedSMS);
        ///
        ///         // Check if any error occurred.
        ///         // 检查是否有错误
        ///         if (response == null || response.Code != 0)
        ///         {
        ///             throw new InvalidOperationException("Failed to send SMS by template");
        ///         }
        ///
        ///         // Print response data for fee, id and count
        ///         // 打印返回的费用, ID和发送的记录条数
        ///         Console.WriteLine("Fee: {0}, ID: {1}, Count: {2}", response.Data.Fee, response.Data.Id, response.Data.Count);
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>BaseResponse{ShortMessageReceipt}.</returns>
        /// <exception cref="System.ArgumentNullException">message</exception>
        public BaseResponse<ShortMessageReceipt> SendSMSByTemplate(TemplateBasedShortMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            var request = this.CreateFunctionUri(resource_SMS, "tpl_send");
            FillPostData(request, message);

            return GetResponse<ShortMessageReceipt>(request, "result");
        }

        /// <summary>
        /// Gets the blacklist of keyword. (获得屏蔽词)
        /// <remarks>REST API: http://yunpian.com/v1/sms/get_black_word.json </remarks>
        /// <example>
        /// Code sample: [Please change api key with your own in your codes]
        /// (示例代码: [请在你自己的代码里修改你自己的api key的值)]
        /// <code>
        /// <![CDATA[
        ///  class Program
        /// {
        ///     /// <summary>
        ///     /// Defines the entry point of the application.
        ///     /// </summary>
        ///     /// <param name="args">The arguments.</param>
        ///     /// <exception cref="System.InvalidOperationException">Failed to send SMS by template</exception>
        ///     static void Main(string[] args)
        ///     {
        ///         // Need to replace with your own API key here.
        ///         // 此处的值需要被替换成你自己的API Key
        ///         const string yourApiKey = "YourApiKey";
        ///
        ///         // Create instance of API client.
        ///         // 创建 API Client 实例
        ///         ApiClient client = new ApiClient(yourApiKey);
        ///
        ///         // Specify a sentence with dirty words
        ///         // 指定一句带脏话的话
        ///         var response = client.GetKeywordBlacklist("他妈的");
        ///
        ///         // Check if any error occurred.
        ///         // 检查是否有错误
        ///         if (response == null || response.Code != 0)
        ///         {
        ///             throw new InvalidOperationException("Failed to GetKeywordBlacklist");
        ///         }
        ///
        ///         // Print response data for word in blacklist
        ///         // 打印返回的屏蔽词
        ///         Console.WriteLine("Words: {0}", response.Data.Words);
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>BaseResponse{ShortMessageReceipt}.</returns>
        /// <exception cref="System.ArgumentNullException">message</exception>
        public BaseResponse<KeywordBlacklist> GetKeywordBlacklist(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentNullException("content");
            }

            var request = this.CreateFunctionUri(resource_SMS, "get_black_word", "text=" + content);

            return GetResponse<KeywordBlacklist>(request, "result");
        }

        #region FillPostData

        /// <summary>
        /// Fills the post data.
        /// </summary>
        /// <param name="httpRequest">The HTTP request.</param>
        /// <param name="message">The message.</param>
        protected void FillPostData(HttpWebRequest httpRequest, ShortMessage message)
        {
            if (httpRequest != null && message != null)
            {
                Dictionary<string, string> postData = new Dictionary<string, string>();

                postData.Add("apikey", this.ApiKey);
                postData.Add("text", message.Content);
                postData.Add("mobile", message.Destination);

                httpRequest.FillData("POST", postData, Encoding.UTF8);
            }
        }

        /// <summary>
        /// Fills the post data.
        /// </summary>
        /// <param name="httpRequest">The HTTP request.</param>
        /// <param name="message">The message.</param>
        protected void FillPostData(HttpWebRequest httpRequest, TemplateBasedShortMessage message)
        {
            if (httpRequest != null && message != null)
            {
                Dictionary<string, string> postData = new Dictionary<string, string>();

                postData.Add("apikey", this.ApiKey);
                postData.Add("tpl_id", message.TemplateId);
                postData.Add("tpl_value", message.TemplateValues.ToKeyValueStringWithUrlEncode().ToUrlEncodedText());
                postData.Add("mobile", message.Destination);

                httpRequest.FillData("POST", postData);
            }
        }

        /// <summary>
        /// Fills the post data.
        /// </summary>
        /// <param name="httpRequest">The HTTP request.</param>
        /// <param name="accountInfo">The account information.</param>
        protected void FillPostData(HttpWebRequest httpRequest, AccountInfo accountInfo)
        {
            if (httpRequest != null && accountInfo != null)
            {
                Dictionary<string, string> postData = new Dictionary<string, string>();

                postData.Add("apikey", this.ApiKey);
                postData.Add("emergency_contact", accountInfo.EmergencyContact);
                postData.Add("emergency_mobile", accountInfo.EmergencyCellphone);
                postData.Add("alarm_balance", accountInfo.BalanceAlarm.ToString());

                httpRequest.FillData("POST", postData);
            }
        }

        #endregion
    }
}
