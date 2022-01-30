using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace WebApplication5.Models
{
    public class EmailSender : IEmailSender
    {
        private readonly MailSettingsOptions _mailSettings;

        private readonly ApplicationContext _context;

        /// <summary>
        /// EmailSender constructor
        /// </summary>
        /// <param name="mailSettings">Mail settings from appsetting.json configuration file</param>
        /// <param name="context">Database context</param>
        public EmailSender(MailSettingsOptions mailSettings, ApplicationContext context)
        {
            _mailSettings = mailSettings;
            _context = context;
        }
        /// <summary>
        /// Send emails to recipients
        /// </summary>
        /// <param name="message">Message with information about email recipients, subject and content</param>
        /// <returns></returns>
        public List<Email> SendEmail(Message message)
        {
            List<Email> emails = new List<Email>();
            message.To.ForEach(realEmail =>
            {
                var emailMessage = CreateEmailMessage(message, realEmail);
                emails.Add(Send(emailMessage));
            });
            return emails;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">Message with information about email recipients, subject and content</param>
        /// <param name="realEmail">Recipient's email address</param>
        /// <returns></returns>
        private MailMessage CreateEmailMessage(Message message, String realEmail)
        {
            MailAddress from = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
            MailAddress to = new MailAddress(realEmail);
            MailMessage m = new MailMessage(from, to);
            
            m.Subject = message.Subject;
            m.Body = message.Content;
            m.IsBodyHtml = false;
            return m;
        }
        /// <summary>
        /// Send email to recipient
        /// </summary>
        /// <param name="mailMessage">Message with information about email recipients, subject and content</param>
        /// <returns></returns>
        private Email Send(MailMessage mailMessage)
        {            
            using (var client = new SmtpClient(_mailSettings.Host, _mailSettings.Port))
            {
                Email email = new Email(mailMessage.To.ToString(), mailMessage.Subject, mailMessage.Body, "OK", "");                
                try
                {
                    if (!Regex.IsMatch(mailMessage.To.ToString(), @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                        throw new SmtpException("Invalid email");
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
                    client.EnableSsl = true;
                    client.Send(mailMessage);
                }
                catch (SmtpException e)
                {
                    email.Result = "Failed";
                    email.Failed = e.Message;
                }
                finally
                {
                    _context.emails.Add(email);
                    _context.SaveChanges();
                    client.Dispose();
                }
                return email;
            }
        }
    }
}