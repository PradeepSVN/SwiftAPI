using Microsoft.AspNetCore.Mvc;
using Swift.Api.ApiResponseHandler;
using Swift.Core.Models;
using Swift.Core;
using System.Net;
using Swift.Data.Interfaces;
using Swift.Data.Services;

namespace Swift.Api.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class MemberController : Controller
	{
		private readonly IMemberService _memberService;
		public MemberController(IMemberService memberService)
		{
			_memberService = memberService;
		}
		[HttpPost(Name = "GetAllMemberDetailsBySearch")]
		public async Task<IActionResult> GetAllMemberDetailsBySearch(MemberSearchModel memberSearchModel)
		{
			List<MemberSearchDetailsModel> memberSearchDetailsModel = new List<MemberSearchDetailsModel>();
			try
			{
				memberSearchDetailsModel = await _memberService.GetAllMemberDetailsBySearch(memberSearchModel);
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Member Data Retrived Successfully By Search.", memberSearchDetailsModel, null));
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}
	}
}
