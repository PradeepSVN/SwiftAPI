using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Swift.Core.Models
{
	public class RoleModel
	{
        public Guid Role_UID { get; set; }
        public string Role_ID { get; set; }
        public string Role_Name { get; set; }
        public int Role_Type { get; set; }
        public bool Prac_Admin_Assignable { get; set; }
        public bool Memb_View { get; set; }
        public bool Memb_Submit { get; set; }
        public bool Memb_Reports { get; set; }
        public bool Auth_View { get; set; }
        public bool Auth_Submit { get; set; }
        public bool Auth_Reports { get; set; }
        public bool Claim_View { get; set; }
        public bool Claim_Submit { get; set; }
        public bool Claim_Reports { get; set; }
        public bool Prov_View { get; set; }
        public bool Prov_Submit { get; set; }
        public bool Prov_Reports { get; set; }
        public bool Fin_View { get; set; }
        public bool Fin_Reports { get; set; }
        public Guid Created_By_User_UID { get; set; }
        public DateTime Created_Date { get; set; }
        public Guid Updated_By_User_UID { get; set; }
        public DateTime Updated_Date { get; set; }

    }
    public class RoleSearchModel
    {
		public string Role_ID { get; set; }
		public string Role_Name { get; set; }
		public string Prac_Admin_Assignable { get; set; }
	}
}
