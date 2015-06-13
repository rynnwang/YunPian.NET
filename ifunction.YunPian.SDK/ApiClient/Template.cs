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
        /// The resource_ template
        /// </summary>
        protected const string resource_Template = "tpl";

        /// <summary>
        /// Gets the default template by identifier. (根据ID获得默认模板)
        /// <remarks>REST API: http://yunpian.com/v1/tpl/get_default.json </remarks>
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
        ///         // Get template content
        ///         // 获得模板内容
        ///         var response = client.GetDefaultTemplateById(templateId);
        ///
        ///         // Check if any error occurred.
        ///         // 检查是否有错误
        ///         if (response == null || response.Code != 0)
        ///         {
        ///             throw new InvalidOperationException("Failed to GetDefaultTemplateById");
        ///         }
        ///
        ///         // Print response data for template info
        ///         // 打印返回的模板信息
        ///         Console.WriteLine("Id: {0}, Content: {1}", response.Data.Id, response.Data.Content);
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="templateId">The template identifier.</param>
        /// <returns>BaseResponse{MessageTemplate}.</returns>
        public BaseResponse<MessageTemplate> GetDefaultTemplateById(string templateId)
        {
            var request = this.CreateFunctionUri(resource_Template, "get_default", "tpl_id=" + templateId);
            return GetResponse<MessageTemplate>(request, "template");
        }

        /// <summary>
        /// Gets the default templates. (获得所有默认模板)
        /// <remarks>REST API: http://yunpian.com/v1/tpl/get_default.json </remarks>
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
        ///         // Get template content
        ///         // 获得模板内容
        ///         var response = client.GetDefaultTemplates();
        ///
        ///         // Check if any error occurred.
        ///         // 检查是否有错误
        ///         if (response == null || response.Code != 0)
        ///         {
        ///             throw new InvalidOperationException("Failed to GetDefaultTemplates");
        ///         }
        ///
        ///         // Print response data for template info
        ///         // 打印返回的模板信息
        ///         foreach (var item in response.Data)
        ///         {
        ///             Console.WriteLine("Id: {0}, Content: {1}", item.Id, item.Content);
        ///         }
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>BaseResponse{List{MessageTemplate}}.</returns>
        public BaseResponse<List<MessageTemplate>> GetDefaultTemplates()
        {
            var request = this.CreateFunctionUri(resource_Template, "get_default");
            return GetCollectionResponse<MessageTemplate>(request, "template");
        }

        /// <summary>
        /// Creates the template. (创建模板)
        /// <remarks>REST API: http://yunpian.com/v1/tpl/add.json </remarks>
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
        ///         // Set template content here.
        ///         // 设置模板内容
        ///         var templateContent = "Your content【YourCompany】";
        ///
        ///         // Post template
        ///         // 提交模版
        ///         var response = client.CreateTemplate(templateContent);
        ///
        ///         // Check if any error occurred.
        ///         // 检查是否有错误
        ///         if (response == null || response.Code != 0)
        ///         {
        ///             throw new InvalidOperationException("Failed to CreateTemplate");
        ///         }
        ///
        ///         // Print response data for template info
        ///         // 打印返回的模板信息
        ///         Console.WriteLine("Id: {0}, Content: {1}", response.Data.Id, response.Data.Content);
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="templateContent">Content of the template.</param>
        /// <param name="notificationType">Type of the notification.</param>
        /// <returns>BaseResponse{MessageTemplate}.</returns>
        /// <exception cref="System.ArgumentNullException">message</exception>
        public BaseResponse<MessageTemplate> CreateTemplate(string templateContent, TemplateActionNotificationType notificationType = 0)
        {
            if (string.IsNullOrWhiteSpace(templateContent))
            {
                throw new ArgumentNullException("templateContent");
            }

            var request = this.CreateFunctionUri(resource_Template, "add");
            FillPostData(request, templateContent, notificationType);
            return GetResponse<MessageTemplate>(request, "template");
        }

        /// <summary>
        /// Gets the message template by id. (根据ID获得自定义模板)
        /// <remarks>REST API: http://yunpian.com/v1/tpl/get.json </remarks>
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
        ///         // Use your customized template (id= 100) here.
        ///         // 使用ID为100的自定义模板
        ///         string templateId = "100";
        ///
        ///         // Get template content
        ///         // 获得模板内容
        ///         var response = client.GetMessageTemplateById(templateId);
        ///
        ///         // Check if any error occurred.
        ///         // 检查是否有错误
        ///         if (response == null || response.Code != 0)
        ///         {
        ///             throw new InvalidOperationException("Failed to GetMessageTemplateById");
        ///         }
        ///
        ///         // Print response data for template info
        ///         // 打印返回的模板信息
        ///         Console.WriteLine("Id: {0}, Content: {1}", response.Data.Id, response.Data.Content);
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BaseResponse{MessageTemplate}.</returns>
        public BaseResponse<MessageTemplate> GetMessageTemplateById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id");
            }

            var request = this.CreateFunctionUri(resource_Template, "get", "tpl_id=" + id);
            return GetResponse<MessageTemplate>(request, "template");
        }

        /// <summary>
        /// Gets the message templates. (获得所有自定义模板)
        /// <remarks>REST API: http://yunpian.com/v1/tpl/get.json </remarks>
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
        ///         const string yourApiKey = "YourApiKey ";
        ///
        ///         // Create instance of API client.
        ///         // 创建 API Client 实例
        ///         ApiClient client = new ApiClient(yourApiKey);
        ///
        ///         // Get template content
        ///         // 获得模板内容
        ///         var response = client.GetMessageTemplates();
        ///
        ///         // Check if any error occurred.
        ///         // 检查是否有错误
        ///         if (response == null || response.Code != 0)
        ///         {
        ///             throw new InvalidOperationException("Failed to GetMessageTemplates");
        ///         }
        ///
        ///         // Print response data for template info
        ///         // 打印返回的模板信息
        ///         foreach (var item in response.Data)
        ///         {
        ///             Console.WriteLine("Id: {0}, Content: {1}", item.Id, item.Content);
        ///         }
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>BaseResponse{List{MessageTemplate}}.</returns>
        public BaseResponse<List<MessageTemplate>> GetMessageTemplates()
        {
            var request = this.CreateFunctionUri(resource_Template, "get");
            return GetCollectionResponse<MessageTemplate>(request, "template");
        }

        /// <summary>
        /// Fills the post data.
        /// </summary>
        /// <param name="httpRequest">The HTTP request.</param>
        /// <param name="content">The content.</param>
        /// <param name="notificationType">Type of the notification.</param>
        protected void FillPostData(HttpWebRequest httpRequest, string content, TemplateActionNotificationType notificationType = 0)
        {
            if (httpRequest != null && !string.IsNullOrWhiteSpace(content))
            {
                var postData = new Dictionary<string, string>
                {
                    {"apikey", this.ApiKey},
                    {"tpl_content", content},
                    {"notify_type", notificationType.ToString()}
                };

                httpRequest.FillData(HttpConstants.HttpMethod.Post, postData, Encoding.UTF8);
            }
        }
    }
}
