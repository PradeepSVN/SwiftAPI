using Swift.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Data.Interfaces
{
	public interface IMemberService
	{
        Task <List<MemberSearchDetailsModel>> GetAllMemberDetailsBySearch(MemberSearchModel memberSearchModel);
		Task<MemberInfoModel> EditMemberDetailsById(string memberId);
	}
}
