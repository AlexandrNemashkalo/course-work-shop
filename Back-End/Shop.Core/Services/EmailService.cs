using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Services
{
    public class EmailService
    {
        private readonly IConfiguration configuration;

       
        public EmailService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string message1)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Столовая МИЭМ", "avnemashkalo@edu.hse.ru"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Подтвердите ваш Email";
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message1
            };

           // faabapolov @edu.hse.ru
            using (var client = new SmtpClient())
            {
                //await client.ConnectAsync("smtp.mail.ru", 456, SecureSocketOptions.Auto);
                client.ServerCertificateValidationCallback = (mysender, certificate, chain, sslPolicyErrors) => { return true; };
                client.CheckCertificateRevocation = false;
                await client.ConnectAsync("SMTP.Office365.com", 587, SecureSocketOptions.StartTls);



                await client.AuthenticateAsync(configuration.GetConnectionString("EmailCompany"), configuration.GetConnectionString("EmailPassword"));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

            }

               
            
        }
    }
}
