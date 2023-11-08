using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using OnlineSchool.App.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.Infrastructure.Services.Email
{
	public class EmailYandexService : IEmailService
	{
		private readonly EmailYandexSettings _settingsYandex;

		public EmailYandexService(IOptions<EmailYandexSettings> settingsYandex)
		{
			_settingsYandex = settingsYandex.Value;
		}

		public async Task<bool> SendEmailAsync(string email, string subject, string message)
		{
			var emailMessage = new MimeMessage();

			//от кого отправляем и заголовок
			emailMessage.From.Add(new MailboxAddress(_settingsYandex.From, _settingsYandex.Address));

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
				client.Connect("smtp.yandex.ru", 465, true);

				//Указываем свой Email адрес и пароль приложения
				try
				{
					client.Authenticate(_settingsYandex.Address, _settingsYandex.YandexPassword);
				}
				catch (Exception ex)
				{
					return false;
				}

				//Проверка нашей почты на авторизацию и соединение
				if (client.IsConnected && client.IsAuthenticated)
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
