using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ifunction;

namespace ifunction.YunPian.SDK
{
    /// <summary>
    /// Class ApiClient. (类ApiClient)
    /// Please refer documentation and description in methods for specific code samples.
    /// (具体的代码示例，请参看对应方法的文档和描述)
    /// <example>
    /// Following code sample is duplicated from method <c>SendSMSByTemplate</c>, which is mostly used.
    /// (下列代码示例是从最常用的方法<c>SendSMSByTemplate</c> 复制而来)
    /// </example>
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
    /// </summary>
    public partial class ApiClient
    {
        /// <summary>
        /// The function URI format
        /// {0}: Version
        /// {1}: resource
        /// {2}: function
        /// {3}: format
        /// {4}: apiKey
        /// </summary>
        protected const string functionUriFormat = "http://yunpian.com/{0}/{1}/{2}.{3}?apikey={4}&";

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>The API key.</value>
        public string ApiKey { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public ApiClient(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        /// <summary>
        /// Creates the function URI.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="function">The function.</param>
        /// <param name="urlParameters">The URL parameters.</param>
        /// <param name="format">The format.</param>
        /// <returns>System.String.</returns>
        protected HttpWebRequest CreateFunctionUri(string resource, string function, string urlParameters = null, string format = "json")
        {
            const string serverVersion = "v1";
            return
                (string.Format(functionUriFormat, serverVersion, resource, function, format, this.ApiKey) +
                 (!string.IsNullOrWhiteSpace(urlParameters) ? urlParameters : string.Empty)).CreateHttpWebRequest();
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpRequest">The HTTP request.</param>
        /// <param name="dataPropertyName">Name of the data property.</param>
        /// <returns>BaseResponse{``0}.</returns>
        /// <exception cref="System.InvalidOperationException">GetResponse</exception>
        protected static BaseResponse<T> GetResponse<T>(HttpWebRequest httpRequest, string dataPropertyName)
        {
            BaseResponse<T> result = new BaseResponse<T>();

            if (httpRequest != null)
            {
                try
                {
                    HttpStatusCode statusCode;
                    string responseBody = httpRequest.ReadResponseAsText(Encoding.UTF8, out statusCode);

                    JToken jsonObject = JToken.Parse(responseBody);
                    if (jsonObject != null)
                    {
                        result.Code = jsonObject.SelectToken("code").Value<Int32>();
                        result.Message = jsonObject.SelectToken("msg").Value<string>();

                        if (result.Code != 0)
                        {
                            throw new InvalidOperationException(string.Format("{0}, Code: {1}" + result.Message, result.Code));
                        }

                        if (!string.IsNullOrWhiteSpace(dataPropertyName))
                        {
                            result.Data = jsonObject.SelectToken(dataPropertyName).ToObject<T>();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("GetResponse", ex);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpRequest">The HTTP request.</param>
        /// <param name="dataPropertyName">Name of the data property.</param>
        /// <returns>BaseResponse{List{``0}}.</returns>
        /// <exception cref="System.InvalidOperationException">GetResponse
        /// or
        /// GetResponse</exception>
        protected static BaseResponse<List<T>> GetCollectionResponse<T>(HttpWebRequest httpRequest, string dataPropertyName)
        {
            BaseResponse<List<T>> result = new BaseResponse<List<T>> { Data = new List<T>() };

            if (httpRequest != null)
            {
                try
                {
                    HttpStatusCode statusCode;
                    string responseBody = httpRequest.ReadResponseAsText(Encoding.UTF8, out statusCode);

                    JToken jsonObject = JToken.Parse(responseBody);
                    if (jsonObject != null)
                    {
                        result.Code = jsonObject.SelectToken("code").Value<Int32>();
                        result.Message = jsonObject.SelectToken("msg").Value<string>();

                        if (result.Code != 0)
                        {
                            throw new InvalidOperationException("GetResponse");
                        }

                        if (!string.IsNullOrWhiteSpace(dataPropertyName))
                        {
                            foreach (var one in jsonObject.SelectToken(dataPropertyName).Children())
                            {
                                result.Data.Add(one.ToObject<T>());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("GetResponse", ex);
                }
            }

            return result;
        }
    }
}
