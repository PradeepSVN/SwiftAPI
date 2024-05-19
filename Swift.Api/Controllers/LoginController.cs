using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swift.AES;
using Swift.Api.ApiResponseHandler;
using Swift.Core.Interfaces;
using Swift.Core.Models;
using Swift.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Swift.Api.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class LoginController : Controller
	{
		public IConfiguration _configuration;
        private readonly ILoginService _loginService;
	
		public LoginController(ILoginService loginService, IConfiguration configuration)
		{
			_loginService = loginService;
            _configuration = configuration;
		}
		[HttpPost(Name = "Login")]
		public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
		{
			if (ModelState.IsValid)
			{
				try
                {
                    IActionResult response = Unauthorized();
                    using (Aes myAes = Aes.Create())
					{						
                        myAes.Key = Encoding.UTF8.GetBytes(_configuration["SwiftSaltKey:Key"]);
                        byte[] iv = new byte[16];
                        myAes.IV = iv;
                        // Encrypt the string to an array of bytes.
                        loginModel.Password = EncryptionHelper.EncryptStringToBytes_Aes(loginModel.Password, myAes.Key, myAes.IV);
                        // Decrypt the bytes to a string.
                        //string roundtrip = EncryptionHelper.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                    }
                    var status=await _loginService.Login(loginModel);
					if (status)
					{
						var tokenString = GenerateJSONWebToken(loginModel);
						var userModel = _loginService.GetLoginUserDetails(loginModel);

						response = Ok(new { token = tokenString, userid = userModel.Result.User_UID }) ;
					}
					string result = "", responseMessage = "";
					return response;
                    //return Ok(new ApiResponse(Convert.ToInt32(HttpStatusCode.OK), responseMessage, result));

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
			return Ok();
		}
		private string GenerateJSONWebToken(LoginModel loginInfo)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[] {
				new Claim(JwtRegisteredClaimNames.Sub, loginInfo.UserName),
				//new Claim(JwtRegisteredClaimNames.Email, loginInfo.EmailAddress),
				//new Claim("DateOfJoing", userInfo.DateOfJoing.ToString("yyyy-MM-dd")),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
				_configuration["Jwt:Issuer"],
				claims,
				expires: DateTime.Now.AddMinutes(120),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	}
}
