using Swift.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Core.Interfaces
{
	public interface IRoleService
	{
		
		Task<bool> CreateRole(RoleModel roleModel);
		Task<List<RoleModel>> GetAllRoleDetails();

    }
}
