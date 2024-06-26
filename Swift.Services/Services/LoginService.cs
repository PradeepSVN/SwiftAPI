﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Swift.Core.Models;
using Swift.Data.Interfaces;

namespace Swift.Data.Services
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
                throw ex;
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
                    var result = await dbConnection.QueryAsync<UserModel>("SW_usp_GetLoginUserDetails", new { loginModel.UserName },
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
		public async Task<bool> ChengePassword(ChangePasswordModel changePasswordModel)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					DynamicParameters ObjParm = new DynamicParameters();
					ObjParm.Add("@User_Uid", changePasswordModel.User_UID);
					ObjParm.Add("@PassWord", changePasswordModel.Password);
					ObjParm.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);
					dbConnection.Open();
					await dbConnection.ExecuteAsync("SW_usp_UserChangePassword", ObjParm, commandType: CommandType.StoredProcedure);
					int result = ObjParm.Get<int>("@result");
					dbConnection.Close();
					return result == 1 ? true : false;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			//var result = await _customerRepository.GetByIdAsync(customerId);

			//return result != null ? true : false;
		}
		public async Task<bool> FindByEmail(string email)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					DynamicParameters ObjParm = new DynamicParameters();
					ObjParm.Add("@Email", email);
					ObjParm.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);
					dbConnection.Open();
					await dbConnection.ExecuteAsync("SW_usp_FindByEmail", ObjParm, commandType: CommandType.StoredProcedure);
					int result = ObjParm.Get<int>("@result");
					dbConnection.Close();
					return result == 1 ? true : false;
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
