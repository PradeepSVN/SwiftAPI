using Microsoft.AspNetCore.Mvc;
using Swift.Core.Interfaces;
using Swift.Core.Models;
using System.Reflection;
using System.Security.Cryptography;
using Swift.AES;
using System.Text;
using Swift.Services;
using System.Text.RegularExpressions;
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
					userModel.User_Password = Generate(8);
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

		// GET: Entity details
		[HttpGet(Name = "GetUserEntityDetails")]
		public async Task<ActionResult> GetUserEntityDetails(Guid user_UID)
		{
			// UserModel userModel = new UserModel();
			try
			{
				var userModel = await _userService.GetUserEntityDetails(user_UID);
				return Ok(userModel);
			}
			catch
			{
				return BadRequest();
			}
		}
		// GET: Tin details
		[HttpGet(Name = "GetUserTinDetails")]
		public async Task<ActionResult> GetUserTinDetails(Guid user_UID)
		{
			// UserModel userModel = new UserModel();
			try
			{
				var userModel = await _userService.GetUserTinDetails(user_UID);
				return Ok(userModel);
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
