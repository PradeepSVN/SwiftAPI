using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
//using Swift.Services.Interfaces;
using Swift.Core.Models;

namespace Swift.Api.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class RoleController : Controller
	{

        //private IUserService _userService;
        //public RoleController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        // GET: Role/GetAllRoleDetails
        [HttpGet(Name = "GetAllRoleDetails")]	
        public ActionResult GetAllRoleDetails()
        {
            List<RoleModel> RoleModelList = new List<RoleModel>();
            try
            {
                return Ok(RoleModelList);
            }
            catch
            {
                return BadRequest();
            }           
            
        }
        // POST: Role/AddRole
        [HttpPost(Name = "AddRole")]		
		public async Task<IActionResult> AddRole(RoleModel RoleModel)
		{

            try
            {
                return Ok(RoleModel);
            }
            catch
            {
                return BadRequest();
            }
        }


		// GET: Bind controls to Update details
		[HttpGet(Name = "EditRoleDetails")]
		public ActionResult EditRoleDetails(int id)
        {
           // RoleModel RoleModel = new RoleModel();
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

		// POST:Update the details into database
		[HttpPost(Name = "EditRoleDetails")]
		public ActionResult EditRoleDetails(int id, RoleModel RoleModel)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
            }
        }
    }
}
