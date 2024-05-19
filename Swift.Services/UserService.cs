using Dapper;
using Microsoft.Extensions.Configuration;
using Swift.Core.Interfaces;
using Swift.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Services
{
    public class UserService : IUserService
    {
        #region Connection String

        public IConfiguration _configuration;
        public UserService(IConfiguration configuration)
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

        public async Task<bool> ValidateUserByUserName(int? userId, string userName)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@UserId", userId);
                    ObjParm.Add("@UserName", userName);
                    ObjParm.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);
                    dbConnection.Open();
                    await dbConnection.ExecuteAsync("SW_usp_GetUserValidationByUserName", ObjParm, commandType: CommandType.StoredProcedure);
                    int result = ObjParm.Get<int>("@result");
                    dbConnection.Close();
                    return result == 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            //var result = await _customerRepository.GetByIdAsync(customerId);

            //return result != null ? true : false;
        }
        public async Task<bool> CreateUser(UserModel userModel)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@User_UID", userModel.User_UID);
                    ObjParm.Add("@User_ID", userModel.User_ID);
                    ObjParm.Add("@User_Prac_Admin", userModel.User_Prac_Admin);
                    ObjParm.Add("@User_First_Name", userModel.User_First_Name);
                    ObjParm.Add("@User_Last_Name", userModel.User_Last_Name);
                    ObjParm.Add("@User_Title", userModel.User_Title);
                    ObjParm.Add("@User_Email", userModel.User_Email);
                    ObjParm.Add("@User_Phone", userModel.User_Phone);
                    ObjParm.Add("@User_Phone_Extn", userModel.User_Phone_Extn);
                    ObjParm.Add("@User_Fax", userModel.User_Fax);
                    ObjParm.Add("@User_Active", userModel.User_Active);
                    ObjParm.Add("@User_Temp_Disable", userModel.User_Temp_Disable);
                    ObjParm.Add("@User_Change_Password", userModel.User_Change_Password);
                    //ObjParm.Add("@User_Password_Changed_Date", userModel.User_Password_Changed_Date);
                    ObjParm.Add("@User_Note", userModel.User_Note);
                    ObjParm.Add("@User_UserName", userModel.User_UserName);
                    ObjParm.Add("@User_Password", userModel.User_Password);
                    ObjParm.Add("@User_Terminated", userModel.User_Terminated);
                    ObjParm.Add("@User_Terminated_Date", userModel.User_Terminated_Date);
                    ObjParm.Add("@Role_UID", userModel.Role_UID);
                    ObjParm.Add("@Entities", userModel.Entities);
                    ObjParm.Add("@TINs", userModel.TINs);
                    ObjParm.Add("@Created_By_User_UID", userModel.Created_By_User_UID);
                    ObjParm.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);
                    dbConnection.Open();
                    await dbConnection.ExecuteAsync("SW_usp_InsertOrUpdateUserDetails", ObjParm, commandType: CommandType.StoredProcedure);
                    int result = ObjParm.Get<int>("@result");
                    dbConnection.Close();
                    return result == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
        public async Task<List<UserModel>> GetAllUserDetails()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryAsync<UserModel>("SW_usp_GetUserDetails",
                        commandType: CommandType.StoredProcedure, commandTimeout: 1000);
                    dbConnection.Close();
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
		public async Task<UserModel> EditUserDetailsById(int user_ID)
        { 
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					dbConnection.Open();
					var result = await dbConnection.QueryAsync<UserModel>("SW_usp_GetUserDetails", new { User_ID = user_ID },
						commandType: CommandType.StoredProcedure, commandTimeout: 1000);
					dbConnection.Close();
					return result.SingleOrDefault();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{

			}
		}
		public async Task<bool> UpdateUserDetailsById(int user_ID, UserModel userModel)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					DynamicParameters ObjParm = new DynamicParameters();
					ObjParm.Add("@User_ID", user_ID);
					ObjParm.Add("@User_Prac_Admin", userModel.User_Prac_Admin);
					ObjParm.Add("@User_First_Name", userModel.User_First_Name);
					ObjParm.Add("@User_Last_Name", userModel.User_Last_Name);
					ObjParm.Add("@User_Title", userModel.User_Title);
					ObjParm.Add("@User_Email", userModel.User_Email);
					ObjParm.Add("@User_Phone", userModel.User_Phone);
					ObjParm.Add("@User_Phone_Extn", userModel.User_Phone_Extn);
					ObjParm.Add("@User_Fax", userModel.User_Fax);
					ObjParm.Add("@User_Active", userModel.User_Active);
					ObjParm.Add("@User_Temp_Disable", userModel.User_Temp_Disable);
					ObjParm.Add("@User_Change_Password", userModel.User_Change_Password);
					//ObjParm.Add("@User_Password_Changed_Date", userModel.User_Password_Changed_Date);
					ObjParm.Add("@User_Note", userModel.User_Note);
					ObjParm.Add("@User_UserName", userModel.User_UserName);
					ObjParm.Add("@User_Password", userModel.User_Password);
					ObjParm.Add("@User_Terminated", userModel.User_Terminated);
					ObjParm.Add("@User_Terminated_Date", userModel.User_Terminated_Date);
					ObjParm.Add("@Created_By_User_UID", userModel.Created_By_User_UID);
					ObjParm.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);
					dbConnection.Open();
					await dbConnection.ExecuteAsync("SW_usp_InsertOrUpdateRoleDetails", ObjParm, commandType: CommandType.StoredProcedure);
					int result = ObjParm.Get<int>("@result");
					dbConnection.Close();
					return result == 1 ? true : false;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{

			}
		}
		//public async Task<List<UserEntitieModel>> GetUserEntityDetails()
		//{
		//	try
		//	{
		//		using (IDbConnection dbConnection = Connection)
		//		{
		//			dbConnection.Open();
		//			var result = await dbConnection.QueryAsync<UserEntitieModel>("SW_usp_GetEntityList",
		//				commandType: CommandType.StoredProcedure, commandTimeout: 1000);
		//			dbConnection.Close();
		//			return result.ToList();
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//	finally
		//	{

		//	}
		//}
		//public async Task<List<UserTINModel>> GetUserTinDetails(string entity_ID)
		//{
		//	try
		//	{
		//		using (IDbConnection dbConnection = Connection)
		//		{
		//			dbConnection.Open();
		//			var result = await dbConnection.QueryAsync<UserTINModel>("SW_usp_GetTINListByEntityId", new { Entity_ID = entity_ID },
		//				commandType: CommandType.StoredProcedure, commandTimeout: 1000);
		//			dbConnection.Close();
		//			return result.ToList();
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//	finally
		//	{

		//	}
		//}
	}
}
