﻿using Swift.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Data.Interfaces
{
	public interface IUserService
	{
		Task<bool> ValidateUserByUserName(Guid user_UID, string userName);
		Task<bool> CreateUser(UserModel userModel);
        Task <List<UserViewModel>> GetAllUserDetails();
        Task <List<UserViewModel>> GetAllUserDetailsBySearch(UserSearchModel userSearchModel);
		Task<UserModel> EditUserDetailsById(Guid user_UID);
		Task<bool> UpdateUserDetailsById(UserModel userModel);
		Task<UserModel> UserViewDetailsByUId(Guid user_UID);
		Task<List<UserEntitieModel>> GetUserEntityDetails(Guid user_UID);
		Task<List<UserTINModel>> GetUserTinDetails(Guid user_UID);
	}
}
