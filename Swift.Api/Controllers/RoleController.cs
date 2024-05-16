using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swift.AES;
using Swift.Core.Interfaces;


//using Swift.Services.Interfaces;
using Swift.Core.Models;
using Swift.Services;
using System.Text;

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
                return Ok(roleModelList);
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

            var addResult = false;
            if (ModelState.IsValid)
            {
                try
                { 
                    addResult = await _roleService.CreateRole(RoleModel);                    
                    return Ok(addResult);
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
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
