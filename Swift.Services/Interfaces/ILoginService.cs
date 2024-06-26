﻿using Swift.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Data.Interfaces
{
    public interface ILoginService
    {
        Task<bool> Login(LoginModel loginModel);
        Task<UserModel> GetLoginUserDetails(LoginModel loginModel);
		Task<bool> ChengePassword(ChangePasswordModel changePasswordModel);
        Task<bool> FindByEmail(string email);
	}
}
