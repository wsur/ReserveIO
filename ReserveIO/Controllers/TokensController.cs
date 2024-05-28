using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

		[HttpGet("login")]
		public async Task<ActionResult<string>> GetToken(string login, string password)
		{
			UserLogPass? ulp = await usersContext.UserLogPasses.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
			if (ulp == null)
				return Unauthorized("Такого пользователя нет в системе");
			var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, login), new Claim(ClaimTypes.UserData, password) };
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
