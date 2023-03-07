using MimeKit;
using OnlineSchool.App.Common.Interfaces.Services;
using System;
using MailKit.Net.Smtp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OnlineSchool.Infrastructure.Services.YouTube;

namespace OnlineSchool.Infrastructure.Services.Email
{
    public class EmailGoogleService : IEmailService
    {
        private readonly EmailGoogleSettings _settingsGmail;

        public EmailGoogleService(IOptions<EmailGoogleSettings> settingsGmail)
        {
            _settingsGmail = settingsGmail.Value;
		}

		public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            //от кого отправляем и заголовок
            emailMessage.From.Add(new MailboxAddress(_settingsGmail.From, _settingsGmail.Address));

            //кому отправляем
            emailMessage.To.Add(new MailboxAddress("", email));

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
                try
                {
                    //client.Authenticate(_settingsGmail.Address, _settingsGmail.GmailPassword);
                }
                catch (Exception ex)
                {
                    return false;
                }

                //Проверка нашей почты на авторизацию и соединение
                if(client.IsConnected)
                {
					await client.SendAsync(emailMessage);

					client.Disconnect(true);

                    return true;
				}

                return false;
            }   
        }
    }
}
