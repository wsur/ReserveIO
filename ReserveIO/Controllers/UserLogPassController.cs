using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserLogPassController : ControllerBase
	{
		readonly UsersContext usersContext;
		public UserLogPassController(UsersContext context)
		{
			usersContext = context;

		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.UserLogPass"/> from the database</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<UserLogPass>>> Get(CancellationToken cancellationToken)
		{

			List<UserLogPass> usls = await usersContext.UserLogPasses.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
			var usl = usls.First(x => x.UserId == 1);
			//подмена перед отправкой
			usl.Login = "aaaaa";
			usl.Password = "bbbbb";
			return usls;
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="id">Input UserlogPass</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserLogPass"/>with exact id from the database </returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpGet("[action]/{id}")]
		public async Task<ActionResult<UserLogPass>> Get(int id, CancellationToken cancellationToken)
		{
			UserLogPass? userLogPass = await usersContext.UserLogPasses.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
			if (userLogPass.UserId == 1)
				return BadRequest("Фиг вам!");
			if (userLogPass == null)
				return NotFound();
			return new ObjectResult(userLogPass);
		}
		/// <summary>
		/// Добавление логина и пароля пользователю по заданному id пользователя. Нужно для авторизации.
		/// </summary>
		/// <param name="userLogPass">Input UserLogPass</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserLogPass"/></returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (Обычно, проблема c Id, нужно оставить нулевым)</response>
		[Authorize]
		[HttpPost("[action]")]
		public async Task<ActionResult<UserLogPass>> Post(UserLogPass userLogPass, CancellationToken cancellationToken)
		{
			if (userLogPass == null)
			{
				return BadRequest();
			}
			if (userLogPass.UserId == 1)
				return BadRequest("Фиг вам!");
			usersContext.UserLogPasses.Add(userLogPass);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(userLogPass);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="userLogPass">Input UserLogPass</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserLogPass"/> with given id from the database if succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpPut("[action]")]
		public async Task<ActionResult<UserLogPass>> Put(UserLogPass userLogPass, CancellationToken cancellationToken)
		{
			if (userLogPass == null)
			{
				return BadRequest();
			}
			if (!usersContext.UserLogPasses.Any(x => x.UserId == userLogPass.UserId))
			{
				return NotFound();
			}
			if (userLogPass.UserId == 1)
				return BadRequest("Фиг вам!");

			usersContext.Update(userLogPass);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(userLogPass);
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="id">Id for user that we want to delete from the database</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpDelete("[action]")]
		public async Task<ActionResult<UserLogPass>> Delete(int id, CancellationToken cancellationToken)
		{
			//UserLogPass userLogPass = new UserLogPass { UserId = id };//создание объекта-заглушки
			UserLogPass? userLogPass = await usersContext.UserLogPasses.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
			if (id == 1)
				return BadRequest("Фиг вам!");
			if (userLogPass == null)
				return NotFound("Логин и пароль с данным id не был найден");
			var result = usersContext.Remove(userLogPass);
			await usersContext.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok(userLogPass);
			}
			else
				return NotFound("Удаление из бд не было произведено");

		}
	}
}
