using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swift.AES;
using Swift.Api.ApiResponseHandler;
using Swift.Core;
using Swift.Core.Interfaces;


//using Swift.Services.Interfaces;
using Swift.Core.Models;
using Swift.Services;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace Swift.Api.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class RoleController : Controller
	{

        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: Role/GetAllRoleDetails
        [HttpGet(Name = "GetAllRoleDetails")]	
        public async Task<ActionResult> GetAllRoleDetails()
        {
            List<RoleModel> roleModelList = new List<RoleModel>();
            try
            {
                roleModelList = await _roleService.GetAllRoleDetails();
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Roles Data Retrived Successfully.", roleModelList, null));
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}
        // POST: Role/AddRole
        [HttpPost(Name = "AddRole")]		
		public async Task<IActionResult> AddRole(RoleModel roleModel)
		{
            try
            {
                var addResult = false;
                if (ModelState.IsValid)
                {
                    var result = await _roleService.ValidateRoleByRoleId(roleModel.Role_UID, roleModel.Role_ID);
					if (result)
					{
						addResult = await _roleService.CreateRole(roleModel);
						if (addResult)
						{
							return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Role Created Successfully.", null, null));
						}
						else
						{
							return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Failed.ToString(), "Role Creation Failed.", null, null));
						}
					}
					else
					{
						return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Failed.ToString(), "Role Already Exists.Please Check.", null, null));
					}
                }
                else
                {
					return BadRequest(new ApiResponse(Convert.ToInt32(HttpStatusCode.BadRequest), APIStatus.Failed.ToString(), "Enter Valid Credentials.", null, null));
				}
            }
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}


		// GET: Bind controls to Update details
		[HttpGet(Name = "EditRoleDetails")]
		public async Task<ActionResult> EditRoleDetails(Guid role_UID)
        {
           // RoleModel RoleModel = new RoleModel();
            try
            {
				var roleModel = await _roleService.EditRoleDetailsById(role_UID);
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Role Edit Successfully.", roleModel, null));
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}

		// POST:Update the details into database
		[HttpPost(Name = "EditRoleDetails")]
		public async Task<ActionResult> EditRoleDetails(string role_ID, RoleModel roleModel)
        {
            try
            {
                var updateResult = false;
				var result = await _roleService.ValidateRoleByRoleId(roleModel.Role_UID, roleModel.Role_ID);
				if (result)
				{
					 updateResult = await _roleService.UpdateRoleDetailsById(role_ID, roleModel);
					if (updateResult)
					{
						return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Role Updated Successfully.", null, null));
					}
					else
					{
						return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Failed.ToString(), "Role Update Failed.", null, null));
					}
				}
				else
				{
					return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Failed.ToString(), "Role Id Already Exists", null, null));
				}			
            }
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}

		// GET: Delete  Role details by id
		[HttpDelete(Name = "DeleteRole")]
		public ActionResult DeleteRole(int id)
        {
            try
            {
                return Ok();
            }
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}
    }
}
