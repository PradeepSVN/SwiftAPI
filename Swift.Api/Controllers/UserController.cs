using Microsoft.AspNetCore.Mvc;
using Swift.Core.Interfaces;
using Swift.Core.Models;
using System.Reflection;
using System.Security.Cryptography;
using Swift.AES;
using System.Text;
using Swift.Services;
using System.Text.RegularExpressions;
using Swift.Api.ApiResponseHandler;
using Swift.Core;
using System.Net;
namespace Swift.Api.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		public IConfiguration _configuration;
		public UserController(IUserService userService, IConfiguration configuration)
		{
			_userService = userService;
			_configuration = configuration;
		}

		[HttpGet(Name = "GetAllUserDetails")]
		public async Task<IActionResult> GetAllUserDetails()
		{
			List<UserModel> userModelList = new List<UserModel>();
			try
			{
                userModelList = await _userService.GetAllUserDetails();
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Users Data Retrived Successfully.", userModelList, null));
			}
			catch(Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}

		}
		// POST: User/AddUser
		[HttpPost(Name = "AddUser")]

		public async Task<IActionResult> AddUser(UserModel userModel)
		{
			try
			{
				var addResult = false;
				if (ModelState.IsValid)
				{
					userModel.User_Password = Generate(8);
					var result = await _userService.ValidateUserByUserName(userModel.User_ID, userModel.User_UserName);
					if (result)
					{
						using (Aes myAes = Aes.Create())
						{
							myAes.Key = Encoding.UTF8.GetBytes(_configuration["SwiftSaltKey:Key"]);
							byte[] iv = new byte[16];
							myAes.IV = iv;
							// Encrypt the string to an array of bytes.
							userModel.User_Password = EncryptionHelper.EncryptStringToBytes_Aes(userModel.User_Password, myAes.Key, myAes.IV);
							// Decrypt the bytes to a string.
							//string roundtrip = EncryptionHelper.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);
						}
						addResult = await _userService.CreateUser(userModel);
						if (addResult)
						{
							return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "User Created Successfully.", null, null));
						}else
						{
							return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Failed.ToString(), "User Creation Failed.", null, null));
						}
					}
					else
					{
						return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Failed.ToString(), "User Already Exists.Please Check.", null, null));
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
		private readonly static Random _rand = new Random();

		public static string Generate(int length = 24)
		{
			const string lower = "abcdefghijklmnopqrstuvwxyz";
			const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			const string number = "1234567890";
			const string special = "!@#$%^&*_-=+";

			// Get cryptographically random sequence of bytes
			var bytes = new byte[length];
			new RNGCryptoServiceProvider().GetBytes(bytes);

			// Build up a string using random bytes and character classes
			var res = new StringBuilder();
			foreach (byte b in bytes)
			{
				// Randomly select a character class for each byte
				switch (_rand.Next(4))
				{
					// In each case use mod to project byte b to the correct range
					case 0:
						res.Append(lower[b % lower.Count()]);
						break;
					case 1:
						res.Append(upper[b % upper.Count()]);
						break;
					case 2:
						res.Append(number[b % number.Count()]);
						break;
					case 3:
						res.Append(special[b % special.Count()]);
						break;
				}
			}
			return res.ToString();
		}
		// GET: Bind controls to Update details
		[HttpGet(Name = "EditUserDetails")]
		public async Task<ActionResult> EditUserDetails(int user_ID)
		{
			// UserModel userModel = new UserModel();
			try
			{
				var userModel = await _userService.EditUserDetailsById(user_ID);
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "Role Edit Successfully.", userModel, null));
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}

		// POST:Update the details into database
		[HttpPost(Name = "EditUserDetails")]
		public async Task<ActionResult> EditUserDetails(int User_ID, UserModel userModel)
		{
			try
			{
				var updateResult = false;
				var result = await _userService.ValidateUserByUserName(User_ID, userModel.User_UserName);
				if (result)
				{
					updateResult = await _userService.UpdateUserDetailsById(User_ID, userModel);
					if (updateResult)
					{
						return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "User Updated Successfully.", null, null));
					}
					else
					{
						return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Failed.ToString(), "User Update Failed.", null, null));
					}
				}else
				{
					return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Failed.ToString(), "User Name Already Exists", null, null));
				}
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}

		// GET: Delete  User details by id
		[HttpDelete(Name = "DeleteUser")]
		public ActionResult DeleteUser(int id)
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

		// GET: Entity details
		[HttpGet(Name = "GetUserEntityDetails")]
		public async Task<ActionResult> GetUserEntityDetails(Guid user_UID)
		{
			// UserModel userModel = new UserModel();
			try
			{
				var userEntity = await _userService.GetUserEntityDetails(user_UID);
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "User Entity Details Retrived Successfully.", userEntity, null));
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}
		// GET: Tin details
		[HttpGet(Name = "GetUserTinDetails")]
		public async Task<ActionResult> GetUserTinDetails(Guid user_UID)
		{
			// UserModel userModel = new UserModel();
			try
			{
				var userTin = await _userService.GetUserTinDetails(user_UID);
				return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), APIStatus.Success.ToString(), "User Tin Details Retrived Successfully.", userTin, null));
			}
			catch (Exception ex)
			{
				return BadRequest(new ApiResponse(500, APIStatus.Failed.ToString(), "An internal server error occurred.", null, ex.Message));
			}
		}
	}
}
