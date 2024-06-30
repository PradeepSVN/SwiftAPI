using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
	public class ForgotPasswordModel
	{
		[MaxLength(250)]
		[Display(Name = "Email Address")]
		[Required(ErrorMessage = "Email Address is required.")]
		[RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address")]
		public string Email { get; set; }
	}
}
