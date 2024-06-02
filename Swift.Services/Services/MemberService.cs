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

namespace Swift.Data.Services
{
    public class MemberService : IMemberService
    {
        #region Connection String

        public IConfiguration _configuration;
        public MemberService(IConfiguration configuration)
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

        
		public async Task<List<MemberSearchDetailsModel>> GetAllMemberDetailsBySearch(MemberSearchModel memberSearchModel)
		{
			try
			{
				using (IDbConnection dbConnection = Connection)
				{
					DynamicParameters ObjParm = new DynamicParameters();
					ObjParm.Add("@ENTITY_UID", memberSearchModel.ENTITY_UID);
					ObjParm.Add("@INSURANCE", memberSearchModel.INSURANCE);
					ObjParm.Add("@OPTION", memberSearchModel.OPTION);
					ObjParm.Add("@MEMBER_ID", memberSearchModel.MEMBER_ID);
					ObjParm.Add("@FIRST_NAME", memberSearchModel.FIRST_NAME);
					ObjParm.Add("@LAST_NAME", memberSearchModel.LAST_NAME);
					ObjParm.Add("@DOB", memberSearchModel.DOB);
					ObjParm.Add("@PCP", memberSearchModel.PCP);
					ObjParm.Add("@page", memberSearchModel.Page);
					ObjParm.Add("@size", memberSearchModel.Size);
					ObjParm.Add("@sortColumn", memberSearchModel.SortColumn);
					ObjParm.Add("@Order", memberSearchModel.Order);
					ObjParm.Add("@totalrows", memberSearchModel.Totalrows);
					
					dbConnection.Open();
					var result = await dbConnection.QueryAsync<MemberSearchDetailsModel>("SW_usp_GetAllMemberDetailsBySearch", ObjParm,

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
