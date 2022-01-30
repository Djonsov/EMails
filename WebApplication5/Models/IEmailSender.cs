namespace WebApplication5.Models
{
    public interface IEmailSender
    {
        List<Email> SendEmail(Message message);
    }
}
