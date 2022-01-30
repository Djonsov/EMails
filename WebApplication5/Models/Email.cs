namespace WebApplication5.Models
{   /// <summary>
    /// Entity class for database context 
    /// </summary>
    public class Email
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Email reciepient
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// Email subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Emai content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Email send result
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// Error message
        /// </summary>
        public string? Failed { get; set; } 
        public Email(string recipient, string subject, string content, string result, string failed)
        {
            Recipient = recipient;
            Subject = subject;
            Content = content;
            Result = result;
            Failed = failed;
        }
    }
}
