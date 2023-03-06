using MimeKit;
using OnlineSchool.App.Common.Interfaces.Services;
using System;
using MailKit.Net.Smtp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.Infrastructure.Services.Email
{
    public class EmailGoogleService : IEmailService
    {
        public void SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            //от кого отправляем и заголовок
            emailMessage.From.Add(new MailboxAddress("OnlineSchool", "onlineschoolproject2023@gmail.com"));
            //кому отправляем
            emailMessage.To.Add(new MailboxAddress("Запись на курс", email));
            //тема письма
            emailMessage.Subject = subject;
            //тело письма
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())

            {
                //Указываем smtp сервер почты и порт
                client.Connect("smtp.gmail.com", 587, false);
                //Указываем свой Email адрес и пароль приложения
                client.Authenticate("onlineschoolproject2023@gmail.com", "supyootzbubmagno");
                client.Send(emailMessage);
                client.Disconnect(true);

            }   
        }
    }
}
