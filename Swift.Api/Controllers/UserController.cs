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
                return Ok(userModelList);
			}
			catch
			{
				return BadRequest();
			}

		}
		// POST: User/AddUser
		[HttpPost(Name = "AddUser")]

		public async Task<IActionResult> AddUser(UserModel userModel)
		{
			var addResult = false;
			if (ModelState.IsValid)
			{
				try
				{					
					var result = await _userService.ValidateUserByUserName(userModel.User_ID,userModel.User_UserName);
					if(result)
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
					}
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
		[HttpGet(Name = "EditUserDetails")]
		public async Task<ActionResult> EditUserDetails(int user_ID)
		{
			// UserModel userModel = new UserModel();
			try
			{
				var userModel = await _userService.EditUserDetailsById(user_ID);
				return Ok(userModel);
			}
			catch
			{
				return BadRequest();
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
				}
				return Ok(updateResult);
			}
			catch
			{
				return BadRequest();
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
			catch
			{
				return BadRequest();
			}
		}
	}
}
