using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.IdentityModel.Tokens;
using ReserveIO.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TokensController : ControllerBase
	{
		readonly UsersContext usersContext;
		public TokensController(UsersContext context)
		{
			usersContext = context;

		}

		[HttpGet("login/{username}")]
		public async Task<ActionResult<string>> GetToken(string userName)
		{

			var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };
			var jwt = new JwtSecurityToken(
					issuer: AuthOptions.ISSUER,
					audience: AuthOptions.AUDIENCE,
					claims: claims,
					expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
					signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

			return new JwtSecurityTokenHandler().WriteToken(jwt);
		}
	}
}
