using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Swift.Core.Models
{
	public class UserModel
	{
		public Guid User_UID { get; set; }
		public int? User_ID { get; set; }
	
		public required bool User_Prac_Admin { get; set; }
		[StringLength(50, MinimumLength = 2)]
		public required string User_First_Name { get; set; }
		
		[StringLength(50, MinimumLength = 2)]
		public required string User_Last_Name { get; set; }
	
		[StringLength(50, MinimumLength = 2)]
		public required string User_Title { get; set; }

		[StringLength(50, MinimumLength = 2)]
		[DataType(DataType.EmailAddress)]
		public required string User_Email { get; set; }
		
		[StringLength(50, MinimumLength = 2)]
		public required string User_Phone { get; set; }
		public string? User_Phone_Extn { get; set; }
		public string User_Fax { get; set; }
	
		public bool User_Active { get; set; }

		public bool User_Temp_Disable { get; set; }
		
		public bool User_Change_Password { get; set; }		
		public Guid Created_By_User_UID { get; set; }
		public DateTime Created_Date { get; set; }
		public Guid Updated_By_User_UID { get; set; }
		public DateTime Updated_Date { get; set; }
		public DateTime User_Password_Changed_Date { get; set; }
		public string? User_Note { get; set; }

		public required string User_UserName { get; set; }
		[Required]
		public required string User_Password { get; set; }
		public bool User_Terminated { get; set; }
		public DateTime User_Terminated_Date { get; set; }
	}
}
