using Swift.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Data.Interfaces
{
	public interface IProviderService
	{
        Task <List<ProviderDetailsModel>> GetAllProviderDetailsBySearch(ProviderSearchModel providerSearchModel);
		Task<ProviderInfoModel> ViewProviderDetailsById(Guid providerUid);
	}
}
