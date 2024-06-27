using Newtonsoft.Json;
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
	
		public  string User_Password { get; set; }
		public bool User_Terminated { get; set; }

		//[JsonProperty("User_Terminated_Date", NullValueHandling = NullValueHandling.Ignore)]
		public string User_Terminated_Date { get; set; }
		public Guid Role_UID { get; set; }
		public string? Role_Name { get; set; }
		public string Entities { get; set; }
		public string TINs { get; set; }
	}

	public class UserViewModel
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

		public string User_Active { get; set; }

		public bool User_Temp_Disable { get; set; }

		public bool User_Change_Password { get; set; }
		public Guid Created_By_User_UID { get; set; }
		public string Created_Date { get; set; }
		public Guid Updated_By_User_UID { get; set; }

		public string Updated_Date { get; set; }
		public DateTime User_Password_Changed_Date { get; set; }
		public string? User_Note { get; set; }

		public required string User_UserName { get; set; }

		public string User_Password { get; set; }
		public bool User_Terminated { get; set; }

		//[JsonProperty("User_Terminated_Date", NullValueHandling = NullValueHandling.Ignore)]
		public string User_Terminated_Date { get; set; }
		public Guid Role_UID { get; set; }
		public string? Role_Name { get; set; }
		public string Entities { get; set; }
		public string TINs { get; set; }
		public string TotalCount { get; set; }
	}
	public class UserSearchModel
	{
        public string User_UserName { get; set; }
        public string User_First_Name { get; set; }
        public string User_Last_Name { get; set; }
        public string Role { get; set; }
        public string User_Prac_Admin { get; set; }
        public string User_Active { get; set; }
        public string User_Entities { get; set; }
        public string User_Tins { get; set; }
		public int Page { get; set; }
		public int Size { get; set; }
		public string SortColumn { get; set; }
		public string Order { get; set; }
	}
	public class UserEntitieModel
	{
		public string Entity_ID { get; set; }
		public string Entity_Name { get; set; }

	}
	public class UserTINModel
	{
		public string TIN_ID { get; set; }
		public string TIN_Name { get; set; }

	}

}
