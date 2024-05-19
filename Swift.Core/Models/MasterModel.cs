using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Core.Models
{
    public class MasterModel
    {

    }
	public class EntitiesModel
	{
		public Guid User_UID { get; set; }
		public string Entity_ID { get; set; }
		public string Entity_Name { get; set; }
		public Guid Created_By_User_UID { get; set; }
		public DateTime Created_Date { get; set; }
		public Guid Updated_By_User_UID { get; set; }
		public DateTime Updated_Date { get; set; }

	}
	public class EntitieModel
	{
		public string Entity_ID { get; set; }
		public string Entity_Name { get; set; }

	}
	public class TINsModel
	{
		public Guid User_UID { get; set; }
		public string TIN_ID { get; set; }
		public string TIN_Name { get; set; }
		public Guid Created_By_User_UID { get; set; }
		public DateTime Created_Date { get; set; }
		public Guid Updated_By_User_UID { get; set; }
		public DateTime Updated_Date { get; set; }

	}
	public class TINModel
	{
		public string TIN_ID { get; set; }
		public string TIN_Name { get; set; }

	}
}
