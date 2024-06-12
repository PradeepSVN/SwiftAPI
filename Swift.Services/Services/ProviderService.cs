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

        
		public async Task <List<ProviderDetailsModel>> GetAllProviderDetailsBySearch(ProviderSearchModel providerSearchModel)
		{ 
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					DynamicParameters ObjParm = new DynamicParameters();
					ObjParm.Add("@ENTITY_UID", providerSearchModel.ENTITY_UID);
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
		public async Task<ProviderModel> ViewMemberDetailsById(Guid providerUid)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					dbConnection.Open();
					var result = await dbConnection.QueryAsync<ProviderModel>("SW_usp_GetMemberDetailsById", new { PROVIDER_UID = providerUid },
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