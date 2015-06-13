namespace ifunction.YunPian.SDK
{
    /// <summary>
    /// Enum TemplateActionNotificationType
    /// </summary>
    public enum TemplateActionNotificationType
    {
        /// <summary>
        /// Value indicating it is notification required (需要通知)
        /// </summary>
        NotificationRequired = 0,
        /// <summary>
        /// Value indicating it is notify only when fail to verify (仅失败时通知)
        /// </summary>
        NotifyOnlyWhenFailToVerify = 1,
        /// <summary>
        /// Value indicating it is notify only when succeed to verify (仅成功时通知)
        /// </summary>
        NotifyOnlyWhenSucceedToVerify = 2,
        /// <summary>
        /// Value indicating it is no notification (不需要通知)
        /// </summary>
        NoNotification = 3
    }
}
