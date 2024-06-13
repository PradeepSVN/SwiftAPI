using Microsoft.AspNetCore.Mvc;
using Swift.Api.ApiResponseHandler;
using Swift.Core.Models;
using Swift.Core;
using System.Net;
using Swift.Data.Interfaces;
using Swift.Data.Services;
using Microsoft.AspNetCore.Cors;

namespace Swift.Api.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	
	public class ProviderController : Controller
	{
		private readonly IProviderService _providerService;
		public ProviderController(IProviderService providerService)
		{
			_providerService = providerService;
		}
		[HttpPost(Name = "GetAllProviderDetailsBySearch")]
		public async Task<IActionResult> GetAllProviderDetailsBySearch(ProviderSearchModel providerSearchModel)
		{
			List<ProviderDetailsModel> providerModelList = new List<ProviderDetailsModel>();
			try
			{
				providerModelList = await _providerService.GetAllProviderDetailsBySearch(providerSearchModel);
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Provider Data Retrived Successfully By Search.", providerModelList, null));
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}
		[HttpGet(Name = "ViewProviderDetails")]
		public async Task<ActionResult> ViewProviderDetails(Guid providerUid)
		{
			// UserModel userModel = new UserModel();
			try
			{
				var providerInfoModel = await _providerService.ViewProviderDetailsById(providerUid);
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Provider View Successfully.", providerInfoModel, null));
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}
	}
}
