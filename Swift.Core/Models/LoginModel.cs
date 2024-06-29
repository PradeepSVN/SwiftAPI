using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Core.Models
{
	public class LoginModel
	{
		public required string UserName { get; set; }
		public required string Password { get; set; }

	}
	public class ChangePasswordModel
	{
		public required Guid User_UID { get; set; }
		public required string Password { get; set; }

	}
}
