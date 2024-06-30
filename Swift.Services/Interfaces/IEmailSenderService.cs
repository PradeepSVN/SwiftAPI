using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Data.Interfaces
{
	public interface IEmailSenderService
	{
		Task SendEmail(string toEmail, string subject, string messageBody, string attachements);
	}
}
