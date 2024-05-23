using Microsoft.AspNetCore.Mvc;
using Swift.Data.Interfaces;
using Swift.Core.Models;
using System.Reflection;
using System.Security.Cryptography;
using Swift.AES;
using System.Text;
using Swift.Api.ApiResponseHandler;
using System.Net;
using System.Xml.Linq;
using Swift.Core;
namespace Swift.Api.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class MasterController : Controller
	{
		private readonly IMasterService _masterService;
		public IConfiguration _configuration;
		public MasterController(IMasterService masterService, IConfiguration configuration)
		{
			_masterService = masterService;
			_configuration = configuration;
		}		

		// GET: Entity details
		[HttpGet(Name = "GetEntityDetails")]
		public async Task<ActionResult> GetEntityDetails()
		{
			try
			{
				var entityModel = await _masterService.GetEntityDetails();
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Entity Details Retrived Successfully.", entityModel, null));				
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}
		// GET: Tin details
		[HttpGet(Name = "GetTinDetails")]
		public async Task<ActionResult> GetTinDetails(string entity_ID)
		{			
			try
			{
				var tinModel = await _masterService.GetTinDetails(entity_ID);
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Tin Details Retrived Successfully.", tinModel, null));
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}
	}
}
