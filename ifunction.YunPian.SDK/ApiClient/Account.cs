using System;

namespace ifunction.YunPian.SDK
{
    partial class ApiClient
    {
        /// <summary>
        /// The resource_ user
        /// </summary>
        protected string resource_User = "user";

        /// <summary>
        /// Gets the account information. (获得帐号信息)
        /// <remarks>REST API: http://yunpian.com/v1/user/get.json </remarks>
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
        ///         // Get account info
        ///         // 获得帐号信息
        ///         var response = client.GetAccountInfo();
        ///
        ///         // Check if any error occurred.
        ///         // 检查是否有错误
        ///         if (response == null || response.Code != 0)
        ///         {
        ///             throw new InvalidOperationException("Failed to GetAccountInfo");
        ///         }
        ///
        ///         // Print response data for account info
        ///         // 打印返回的帐号信息
        ///         Console.WriteLine("Email: {0}, Balance: {1}, Cellphone: {2}", response.Data.Email, response.Data.Balance, response.Data.Cellphone);
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>BaseResponse{AccountInfo}.</returns>
        public BaseResponse<AccountInfo> GetAccountInfo()
        {
            var request = this.CreateFunctionUri(resource_User, "get");
            return GetResponse<AccountInfo>(request, "user");
        }

        /// <summary>
        /// Updates the account information. (更改账号信息.)
        /// <remarks>REST API: http://yunpian.com/v1/user/set.json </remarks>
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
        ///         // Get account info
        ///         // 获得帐号信息
        ///         var accountResponse = client.GetAccountInfo();
        ///
        ///         // Update account info.
        ///         // 更新账户信息
        ///         // Only following fields can be updated.
        ///         // 只有以下字段的值可以被更新
        ///         var accountInfo = accountResponse.Data;
        ///         // Set your new emergency cellphone
        ///         // 设置新的紧急联系人手机号码
        ///         accountInfo.EmergencyCellphone = "YourNewEmergencyCellphone";
        ///         // Set your new emergency contact name
        ///         // 设置新的紧急联系人姓名
        ///         accountInfo.EmergencyContact = "YourNewEmergencyContact";
        ///         // Set your new balance alarm
        ///         // 设置新的余量预警值
        ///         accountInfo.BalanceAlarm = 100;
        ///
        ///         // Update account info
        ///         // 更新帐号信息
        ///         var response = client.UpdateAccountInfo(accountInfo);
        ///
        ///         // Check if any error occurred.
        ///         // 检查是否有错误
        ///         if (response == null || response.Code != 0)
        ///         {
        ///             throw new InvalidOperationException("Failed to UpdateAccountInfo");
        ///         }
        ///     }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>BaseResponse{System.String}.</returns>
        public BaseResponse<string> UpdateAccountInfo(AccountInfo accountInfo)
        {
            if (accountInfo == null)
            {
                throw new ArgumentNullException("accountInfo");
            }

            var request = this.CreateFunctionUri(resource_User, "set");
            FillPostData(request, accountInfo);
            return GetResponse<string>(request, "detail");
        }
    }
}
