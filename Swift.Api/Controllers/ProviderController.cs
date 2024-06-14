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
		// GET: Entity details
		[HttpGet(Name = "GetProviderEntityList")]
		public async Task<ActionResult> GetProviderEntityList()
		{
			try
			{
				var providerEntityList = await _providerService.GetProviderEntityList();
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Provider Entity List Retrived Successfully.", providerEntityList, null));
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}
		// GET: GetProviderInsuranceList
		[HttpGet(Name = "GetProviderInsuranceList")]
		public async Task<ActionResult> GetProviderInsuranceList(string entity_Id)
		{
			try
			{
				var providerInsuranceList = await _providerService.GetProviderInsuranceList(entity_Id);
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Provider Insurance List Retrived Successfully.", providerInsuranceList, null));
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}
		// GET: GetProviderTinList
		[HttpGet(Name = "GetProviderTinList")]
		public async Task<ActionResult> GetProviderTinList(string entity_Id)
		{
			try
			{
				var providerTinList = await _providerService.GetProviderTinList(entity_Id);
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Provider Tin List Retrived Successfully.", providerTinList, null));
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
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
