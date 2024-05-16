using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Core.Models
{
    public class UsersEntitiesModel
    {
        public Guid User_UID { get; set; }
        public string Entity_ID { get; set; }
        public string Entity_Name { get; set; }
        public Guid Created_By_User_UID { get; set; }
        public DateTime Created_Date { get; set; }
        public Guid Updated_By_User_UID { get; set; }
        public DateTime Updated_Date { get; set; }

    }
}
