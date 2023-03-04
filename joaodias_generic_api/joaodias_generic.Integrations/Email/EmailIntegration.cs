using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace joaodias_generic.Integrations.Email
{
    public class EmailIntegration
    {
        private readonly string _emailAddress;
        private readonly string _emailPassword;
        private readonly IConfiguration _configuration;

        public EmailIntegration(IConfiguration configuration)
        {
            _configuration = configuration;
            var emailSettings = _configuration.GetSection("EmailSettings");
            _emailAddress = emailSettings.GetSection("Email").Value!;
            _emailPassword = emailSettings.GetSection("Password").Value!;
        }

        public void SendEmail(string destEmail, string result)
        {
            string fromAddress = "joaodiasworking@gmail.com";
            string toAddress = destEmail;
            string subject = "Loto Fácil Caixa Results";
            string body = $"{result}\n Go Check your Loterias Caixa Account João Dias <3";

            using SmtpClient smtpClient = new("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(_emailAddress, _emailPassword),
                EnableSsl = true
            };

            using MailMessage mailMessage = new(fromAddress, toAddress, subject, body);
            smtpClient.Send(mailMessage);
        }
    }
}
