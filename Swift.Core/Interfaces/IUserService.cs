using Swift.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Core.Interfaces
{
	public interface IUserService
	{
		Task<bool> ValidateUserByUserName(int? userId, string userName);
		Task<bool> CreateUser(UserModel userModel);
        Task <List<UserModel>> GetAllUserDetails();
		Task<UserModel> EditUserDetailsById(int user_ID);
		Task<bool> UpdateUserDetailsById(int user_ID, UserModel userModel);
		Task<List<UserEntitieModel>> GetEntityDetails();
		Task<List<UserTINModel>> GetTinDetails(string entity_ID);
	}
}
