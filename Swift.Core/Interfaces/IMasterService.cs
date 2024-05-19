using Swift.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Core.Interfaces
{
	public interface IMasterService
	{
		
		Task<List<EntitieModel>> GetEntityDetails();
		Task<List<TINModel>> GetTinDetails(string entity_ID);
	}
}
