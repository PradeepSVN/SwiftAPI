using Swift.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Data.Interfaces
{
	public interface IRoleService
	{
		Task<bool> ValidateRoleByRoleId(Guid? role_UID, string role_ID);
		Task<bool> CreateRole(RoleModel roleModel);
		Task<List<RoleModel>> GetAllRoleDetails();
		Task<RoleModel> EditRoleDetailsById(Guid role_UID);
		Task<bool> UpdateRoleDetailsById(string role_ID, RoleModel roleModel);
		Task<List<RoleModel>> GetAllRoleDetailsBySearch(RoleSearchModel roleSearchModel);
	}
}
