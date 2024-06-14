using Dapper;
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
using System.Collections.Immutable;

namespace Swift.Data.Services
{
    public class ProviderService : IProviderService
	{
        #region Connection String

        public IConfiguration _configuration;
        public ProviderService(IConfiguration configuration)
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

		public async Task<List<ProviderEntitiesModel>> GetProviderEntityList()
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					dbConnection.Open();
					var result = await dbConnection.QueryAsync<ProviderEntitiesModel>("SW_usp_GetProviderEntityList",
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
		public async Task<List<ProviderInsuranceModel>> GetProviderInsuranceList(string entity_Id)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					dbConnection.Open();
					var result = await dbConnection.QueryAsync<ProviderInsuranceModel>("SW_usp_GetProviderInsuranceList", new { ENTITY_ID = entity_Id },
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
		public async Task<List<ProviderTINModel>> GetProviderTinList(string entity_Id)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					dbConnection.Open();
					var result = await dbConnection.QueryAsync<ProviderTINModel>("SW_usp_GetProviderTinList", new { ENTITY_ID = entity_Id },
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
		public async Task <List<ProviderDetailsModel>> GetAllProviderDetailsBySearch(ProviderSearchModel providerSearchModel)
		{ 
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					DynamicParameters ObjParm = new DynamicParameters();
					ObjParm.Add("@ENTITY_ID", providerSearchModel.ENTITY_ID);
					ObjParm.Add("@INSURANCE", providerSearchModel.INSURANCE);
					ObjParm.Add("@TIN", providerSearchModel.TIN);
					ObjParm.Add("@FIRST_NAME", providerSearchModel.FIRST_NAME);
					ObjParm.Add("@LAST_NAME", providerSearchModel.LAST_NAME);
					ObjParm.Add("@NPI", providerSearchModel.NPI);
					ObjParm.Add("@page", providerSearchModel.Page);
					ObjParm.Add("@size", providerSearchModel.Size);
					ObjParm.Add("@sortColumn", providerSearchModel.SortColumn);
					ObjParm.Add("@Order", providerSearchModel.Order);				
					dbConnection.Open();
					var result = await dbConnection.QueryAsync<ProviderDetailsModel>("SW_usp_GetAllProviderDetailsBySearch", ObjParm,
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
		public async Task<ProviderInfoModel> ViewProviderDetailsById(Guid providerUid)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					dbConnection.Open();
					var result = await dbConnection.QueryAsync<ProviderInfoModel>("SW_usp_GetProviderDetailsById", new { PROVIDER_UID = providerUid },
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

	}
}
