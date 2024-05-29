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

		/// <summary>
		/// Получение токена для доступа к методам API. Прежде чем получить токен, вы должны добавить запись в бд, привязать пользователя к роли, добавить логин и пароль отдельно по id пользователя
		/// </summary>
		/// <param name="roleId">Id роли пользователя. Получите их через метод GET</param>
		/// <param name="login">логин</param>
		/// <param name="password">пароль</param>
		/// <returns></returns>
		[HttpGet("login")]
		public async Task<IResult> GetToken(int roleId,
									  string login,
									  string password)
		{
			//Проверка на наличие таких записей в БД
			UserLogPass? ulp = await usersContext.UserLogPasses.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
			if (ulp == null)
				return Results.Unauthorized();
			Role? role = await usersContext.Roles.FirstOrDefaultAsync(x => x.RoleId == roleId);
			if (role == null)
				return Results.Unauthorized();
			UserRole? userRole = await usersContext.UserRoles.FirstOrDefaultAsync(x => x.RoleId == role.RoleId && x.UserId == ulp.UserId);
			if (userRole == null)
				return Results.Unauthorized();
			var claims = new List<Claim> { new Claim(ClaimTypes.Actor, role.RoleName),new Claim(ClaimTypes.NameIdentifier, login), new Claim(ClaimTypes.UserData, password) };
			var jwt = new JwtSecurityToken(
					issuer: AuthOptions.ISSUER,
					audience: AuthOptions.AUDIENCE,
					claims: claims,
					expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
					signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
			var encodedJWT = new JwtSecurityTokenHandler().WriteToken(jwt);
			var result = new
			{
				login = login,
				password = password,
				access_token = encodedJWT
			};
			return Results.Json(result);
		}
	}
}
