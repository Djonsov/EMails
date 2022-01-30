using System.Net.Mail;

namespace WebApplication5.Models
{
    public class Message
    {
        /// <summary>
        /// Email recipient list
        /// </summary>
        public List<String> To { get; set; }
        /// <summary>
        /// Email subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Email content
        /// </summary>
        public string Content { get; set; }
        public Message(List<String> to, string subject, string content)
        {
            To = to;
            Subject = subject;
            Content = content;
        }
    }
}
