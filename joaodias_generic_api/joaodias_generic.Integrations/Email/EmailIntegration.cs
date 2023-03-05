using System.Net;
using System.Net.Mail;

namespace joaodias_generic.Integrations.Email
{
    public static class EmailIntegration
    {
        public static void SendEmail(string senderEmail, string password, string destEmail, string result)
        {
            string fromAddress = "joaodiasworking@gmail.com";
            string toAddress = destEmail;
            string subject = "Loto Fácil Caixa Results";
            string body = $"{result}\n Go Check your Loterias Caixa Account João Dias <3";

            using SmtpClient smtpClient = new("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(senderEmail, password),
                EnableSsl = true
            };

            using MailMessage mailMessage = new(fromAddress, toAddress, subject, body);
            smtpClient.Send(mailMessage);
        }
    }
}
