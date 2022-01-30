namespace WebApplication5.Models
{   /// <summary>
    /// SMTP settings
    /// </summary>
    public class MailSettingsOptions
    {
        /// <summary>
        /// Section name in appsetting.json configuration file
        /// </summary>
        public const string MailSettings = "MailSettings";
        /// <summary>
        /// Name displayed in an email
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Email address
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// Email password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// SMTP server address
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// SMTP server port
        /// </summary>
        public int Port { get; set; }
    }
}
