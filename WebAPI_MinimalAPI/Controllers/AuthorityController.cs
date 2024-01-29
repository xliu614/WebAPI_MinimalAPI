using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using WebAPI_MinimalAPI.Authority;
using System.Text;
using System.Security.Claims;

namespace WebAPI_MinimalAPI.Controllers
{
	//[Route("api/[controller]")]
	[ApiController]
	public class AuthorityController : ControllerBase
	{
		private readonly IConfiguration configuaration;

		public AuthorityController(IConfiguration configuaration)
        {
			this.configuaration = configuaration;
		}

        /// <summary>
        /// process of verify user and password
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        [HttpPost("auth")]
		public IActionResult Authenticate([FromBody] AppCredential credential) {
			if (AppRepository.Authenticate(credential.ClientId, credential.Secret))
			{
				var expiresAt = DateTime.UtcNow.AddMinutes(10);
				return Ok(new
				{
					access_token = CreateToken(credential.ClientId, expiresAt),
					expires_at = expiresAt
				}); ;
			}
			else {
				ModelState.AddModelError("UnAuthorized", "You are not authorzied.");
				var problemDetail = new ValidationProblemDetails(ModelState)
				{
					Status = StatusCodes.Status401Unauthorized,
				};
				return new UnauthorizedObjectResult(problemDetail);
			}
		}

		private string CreateToken(string clientId, DateTime expiresAt) {

			//Algo
			//Payload (claims)
			//Signature

			var app = AppRepository.GetApplicationByClientId(clientId);
			var claims = new List<Claim> {
				new Claim("AppName", app.ApplicationName??string.Empty),
				new Claim("Read", (app?.Scopes??string.Empty).Contains("read")? "true":"false"),
				new Claim("Write", (app?.Scopes??string.Empty).Contains("write")? "true":"false"),
			};

		
			var secretKey = Encoding.ASCII.GetBytes(configuaration.GetValue<string>("SecretKey"));
			var jwt = new JwtSecurityToken(
					signingCredentials: new SigningCredentials(
						  new SymmetricSecurityKey(secretKey),
						  SecurityAlgorithms.HmacSha256Signature),
                    claims: claims,
					expires: expiresAt,
					notBefore: DateTime.UtcNow
				);


			return new JwtSecurityTokenHandler().WriteToken(jwt);
		}
	}
}
