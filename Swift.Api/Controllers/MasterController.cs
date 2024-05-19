using Microsoft.AspNetCore.Mvc;
using Swift.Core.Interfaces;
using Swift.Core.Models;
using System.Reflection;
using System.Security.Cryptography;
using Swift.AES;
using System.Text;
using Swift.Services;
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
				return Ok(entityModel);
			}
			catch
			{
				return BadRequest();
			}
		}
		// GET: Tin details
		[HttpGet(Name = "GetTinDetails")]
		public async Task<ActionResult> GetTinDetails(string entity_ID)
		{
			
			try
			{
				var tinModel = await _masterService.GetTinDetails(entity_ID);
				return Ok(tinModel);
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
