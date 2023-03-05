using MimeKit;
using OnlineSchool.App.Common.Interfaces.Services;
using System;
using MailKit.Net.Smtp;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.Infrastructure.Services.Email
{
    public class EmailYandexService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("OnlineSchool", "pin11kurochkin@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("ggg", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.ru", 587, false);
                await client.AuthenticateAsync("pin11kurochkin@gmail.com", "kwzzixrftluenjrv");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
