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
    public class RoleService : IRoleService
    {
        #region Connection String

        public IConfiguration _configuration;
        public RoleService(IConfiguration configuration)
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

		public async Task<bool> ValidateRoleByRoleId(Guid? role_UID, string role_ID)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					DynamicParameters ObjParm = new DynamicParameters();
					ObjParm.Add("@Role_UID", role_UID);
					ObjParm.Add("@Role_ID", role_ID);
					ObjParm.Add("@result", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);
					dbConnection.Open();
					await dbConnection.ExecuteAsync("SW_usp_GetRoleValidationByRoleId", ObjParm, commandType: CommandType.StoredProcedure);
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
		public async Task<bool> CreateRole(RoleModel roleModel)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    DynamicParameters ObjParm = new DynamicParameters();
                    ObjParm.Add("@Role_ID", roleModel.Role_ID);
                    ObjParm.Add("@Role_Name", roleModel.Role_Name);
                    ObjParm.Add("@Role_Type", roleModel.Role_Type);
                    ObjParm.Add("@Prac_Admin_Assignable", roleModel.Prac_Admin_Assignable);
                    ObjParm.Add("@Memb_View", roleModel.Memb_View);
                    ObjParm.Add("@Memb_Submit", roleModel.Memb_Submit);
                    ObjParm.Add("@Memb_Reports", roleModel.Memb_Reports);
                    ObjParm.Add("@Auth_View", roleModel.Auth_View);
                    ObjParm.Add("@Auth_Submit", roleModel.Auth_Submit);
                    ObjParm.Add("@Auth_Reports", roleModel.Auth_Reports);
                    ObjParm.Add("@Claim_View", roleModel.Claim_View);
                    ObjParm.Add("@Claim_Submit", roleModel.Claim_Submit);
                    ObjParm.Add("@Claim_Reports", roleModel.Claim_Reports);
                    ObjParm.Add("@Prov_View", roleModel.Prov_View);
                    ObjParm.Add("@Prov_Submit", roleModel.Prov_Submit);
                    ObjParm.Add("@Prov_Reports", roleModel.Prov_Reports);
                    ObjParm.Add("@Fin_View", roleModel.Fin_View);
                    ObjParm.Add("@Fin_Reports", roleModel.Fin_Reports);
                    ObjParm.Add("@Created_By_User_UID", roleModel.Created_By_User_UID);
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
        public async Task<List<RoleModel>> GetAllRoleDetails()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var result = await dbConnection.QueryAsync<RoleModel>("SW_usp_GetRoleDetails",
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

		public async Task<RoleModel> EditRoleDetailsById(Guid role_UID)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					dbConnection.Open();
					var result = await dbConnection.QueryAsync<RoleModel>("SW_usp_GetRoleDetails", new { Role_UID=role_UID },
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
		public async Task<bool> UpdateRoleDetailsById(string role_ID, RoleModel roleModel)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					DynamicParameters ObjParm = new DynamicParameters();
					ObjParm.Add("@Role_ID", role_ID);
					ObjParm.Add("@Role_Name", roleModel.Role_Name);
					ObjParm.Add("@Role_Type", roleModel.Role_Type);
					ObjParm.Add("@Prac_Admin_Assignable", roleModel.Prac_Admin_Assignable);
					ObjParm.Add("@Memb_View", roleModel.Memb_View);
					ObjParm.Add("@Memb_Submit", roleModel.Memb_Submit);
					ObjParm.Add("@Memb_Reports", roleModel.Memb_Reports);
					ObjParm.Add("@Auth_View", roleModel.Auth_View);
					ObjParm.Add("@Auth_Submit", roleModel.Auth_Submit);
					ObjParm.Add("@Auth_Reports", roleModel.Auth_Reports);
					ObjParm.Add("@Claim_View", roleModel.Claim_View);
					ObjParm.Add("@Claim_Submit", roleModel.Claim_Submit);
					ObjParm.Add("@Claim_Reports", roleModel.Claim_Reports);
					ObjParm.Add("@Prov_View", roleModel.Prov_View);
					ObjParm.Add("@Prov_Submit", roleModel.Prov_Submit);
					ObjParm.Add("@Prov_Reports", roleModel.Prov_Reports);
					ObjParm.Add("@Fin_View", roleModel.Fin_View);
					ObjParm.Add("@Fin_Reports", roleModel.Fin_Reports);
					ObjParm.Add("@Created_By_User_UID", roleModel.Created_By_User_UID);
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
	}

}
