using Swift.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Core.Interfaces
{
    public interface ILoginService
    {
        Task<bool> Login(LoginModel loginModel);
        Task<UserModel> GetLoginUserDetails(LoginModel loginModel);
    }
}
