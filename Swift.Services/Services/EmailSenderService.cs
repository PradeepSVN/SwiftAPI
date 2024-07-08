using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Swift.Data.Interfaces;

namespace Swift.Data.Services
{
	public class EmailSenderService : IEmailSenderService
	{
		public string FromEmail { get; private set; }
		public string ToEmail { get; private set; }
		public string SmtpServer { get; private set; }

		public string UserName { get; private set; }
		public string Password { get; private set; }
		public int Port { get; private set; }
		public string Host { get; private set; }

		private IConfiguration _configuration;
		public EmailSenderService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		private void LoadConfig()
		{
			FromEmail = _configuration["EmailSettings:FromEmail"];
			Host = _configuration["EmailSettings:PrimaryDomain"];
			Port = Convert.ToInt32(_configuration["EmailSettings:PrimaryPort"]);
			UserName = _configuration["EmailSettings:UsernameEmail"];
			Password = _configuration["EmailSettings:UsernamePassword"];

		}
		public async Task SendEmail(string toEmail, string subject, string messageBody, string attachements)
		{
			try
			{
				MailMessage mail = new MailMessage()
				{
					From = new MailAddress(_configuration["EmailSettings:FromEmail"])
				};

				mail.Bcc.Add(new MailAddress(toEmail));
				mail.To.Add(new MailAddress(_configuration["EmailSettings:ToEmail"]));
				mail.CC.Add(new MailAddress(_configuration["EmailSettings:CcEmail"]));

				mail.Subject = "Swift - " + subject;
				mail.Body = messageBody;
				mail.IsBodyHtml = true;
				mail.Priority = MailPriority.High;

				if (attachements != null && attachements != "")
				{
					string[] values = attachements.Split(',');
					for (int i = 0; i < values.Length; i++)
					{
						values[i] = values[i].Trim();

						var filename = values[i].Split('/').Last();
						var stream = new WebClient().OpenRead(values[i]);
						Attachment attachement = new Attachment(stream, filename);

						if (attachement != null)
							mail.Attachments.Add(attachement);
					}
				}

				mail.To.Add("satya@gmail.com");
				mail.To.Add("satya@gmail.com");
				mail.From = new MailAddress("satya@gmail.com");
				mail.Subject = "Confirmation of Registration on Job Junction.";
				string Body = "Hi, this mail is to test sending mail using Gmail in ASP.NET";
				mail.Body = Body;
				mail.IsBodyHtml = true;
				SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
				smtp.Credentials = new System.Net.NetworkCredential("satya@gmail.com", "Mypassword1!");
				//Or your Smtp Email ID and Password
				smtp.UseDefaultCredentials = false;
				smtp.EnableSsl = false;
				smtp.Send(mail);

			}
			catch (Exception ex)
			{
			
				throw ex;
			}
		}

	}
}
