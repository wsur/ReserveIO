﻿using Microsoft.AspNetCore.Mvc;
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
		/// Получение токена для доступа к методам API
		/// </summary>
		/// <param name="roleName">Роль пользователя</param>
		/// <param name="login">логин</param>
		/// <param name="password">пароль</param>
		/// <returns></returns>
		[HttpGet("login")]
		public async Task<IResult> GetToken(string roleName,
									  string login,
									  string password)
		{
			UserLogPass? ulp = await usersContext.UserLogPasses.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
			if (ulp == null)
				return Results.Unauthorized();
			var claims = new List<Claim> { new Claim(ClaimTypes.Actor, roleName),new Claim(ClaimTypes.NameIdentifier, login), new Claim(ClaimTypes.UserData, password) };
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
