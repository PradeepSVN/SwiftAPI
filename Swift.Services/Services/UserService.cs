﻿using Dapper;
using Microsoft.Extensions.Configuration;
using Swift.Data.Interfaces;
using Swift.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Swift.Data.Services
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

        public async Task<bool> ValidateUserByUserName(Guid user_UID, string userName)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@user_UID", user_UID);
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
                    ObjParm.Add("@User_Phone", (userModel.User_Phone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "")) );
                    ObjParm.Add("@User_Phone_Extn", userModel.User_Phone_Extn);
                    ObjParm.Add("@User_Fax", (userModel.User_Fax.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "")) );
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
        public async Task<List<UserViewModel>> GetAllUserDetails()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryAsync<UserViewModel>("SW_usp_GetUserDetails", new { User_UID = "00000000-0000-0000-0000-000000000000" },

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
		public async Task<List<UserViewModel>> GetAllUserDetailsBySearch(UserSearchModel userSearchModel)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					DynamicParameters ObjParm = new DynamicParameters();
					ObjParm.Add("@User_UserName", userSearchModel.User_UserName);
					ObjParm.Add("@User_First_Name", userSearchModel.User_First_Name);
					ObjParm.Add("@User_Last_Name", userSearchModel.User_Last_Name);
					ObjParm.Add("@Role", userSearchModel.Role);
					ObjParm.Add("@User_Prac_Admin", userSearchModel.User_Prac_Admin);
					ObjParm.Add("@User_Active", userSearchModel.User_Active);
					ObjParm.Add("@User_Entities", userSearchModel.User_Entities);
					ObjParm.Add("@User_Tins", userSearchModel.User_Tins);
					ObjParm.Add("@page", userSearchModel.Page);
					ObjParm.Add("@size", userSearchModel.Size);
					ObjParm.Add("@sortColumn", userSearchModel.SortColumn);
					ObjParm.Add("@Order", userSearchModel.Order);
					dbConnection.Open();
					var result = await dbConnection.QueryAsync<UserViewModel>("SW_usp_GetAllUserDetailsBySearch", ObjParm,

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
		public async Task<UserModel> EditUserDetailsById(Guid user_UID)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryAsync<UserModel>("SW_usp_GetUserDetailsByUser", new { User_UID = user_UID },
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
        public async Task<bool> UpdateUserDetailsById(UserModel userModel)
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
                    ObjParm.Add("@User_Phone", (userModel.User_Phone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "")));
                    ObjParm.Add("@User_Phone_Extn", userModel.User_Phone_Extn);
                    ObjParm.Add("@User_Fax", (userModel.User_Fax.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "")));
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
                    ObjParm.Add("@Role_UID", userModel.Role_UID);
                    ObjParm.Add("@Entities", userModel.Entities);
                    ObjParm.Add("@TINs", userModel.TINs);
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
		public async Task<UserModel> UserViewDetailsByUId(Guid user_UID)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					dbConnection.Open();
					var result = await dbConnection.QueryAsync<UserModel>("SW_usp_GetUserViewDetails", new { User_UID = user_UID },
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
		public async Task<List<UserEntitieModel>> GetUserEntityDetails(Guid user_UID)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryAsync<UserEntitieModel>("SW_usp_GetUserEntityList", new { User_UID = user_UID },
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
        public async Task<List<UserTINModel>> GetUserTinDetails(Guid user_UID)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryAsync<UserTINModel>("SW_usp_GetUserTinList", new { User_UID = user_UID },
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
    }
}
