using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Swift.Core.Models;
using Swift.Core.Interfaces;

namespace Swift.Services
{
    public class LoginService : ILoginService
    {
        #region Connection String

        public IConfiguration _configuration;
        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            }
        }
        #endregion
        public async Task<bool> Login(LoginModel loginModel)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@UserName", loginModel.UserName);
                    ObjParm.Add("@PassWord", loginModel.Password);
                    ObjParm.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);
                    dbConnection.Open();
                    await dbConnection.ExecuteAsync("SW_usp_UserLoginValidation", ObjParm, commandType: CommandType.StoredProcedure);
                    int result = ObjParm.Get<int>("@result");
                    dbConnection.Close();
                    return result == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            //var result = await _customerRepository.GetByIdAsync(customerId);

            //return result != null ? true : false;
        }
		public async Task<UserModel> GetLoginUserDetails(LoginModel loginModel)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{					
					dbConnection.Open();
					var result = await dbConnection.QueryAsync<UserModel>("SW_usp_GetLoginUserDetails", new { UserName = loginModel.UserName},
					   commandType: CommandType.StoredProcedure, commandTimeout: 1000);
					dbConnection.Close();
					return result.SingleOrDefault();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			//var result = await _customerRepository.GetByIdAsync(customerId);

			//return result != null ? true : false;
		}
	}
}
