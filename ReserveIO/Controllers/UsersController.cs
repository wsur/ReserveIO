using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;
//using ReserveIO.Repositories;

namespace ReserveIO.Controllers
{
	/// <summary>
	/// Контроллер для управления данными пользователей
	/// </summary>
	/// <remarks>
	/// конструктор контроллера пользователей
	/// </remarks>
	/// <param name="context"></param>
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController(UsersContext context) : ControllerBase
	{
		private readonly UsersContext db = context;

		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.User"/> from the database</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<User>>> Get(CancellationToken cancellationToken)
		{
			List<User> users =  await db.Users.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
			User? user = users.FirstOrDefault(x => x.UserId == 1);
			user.Age = 99;
			user.Name = "ФИГ ВАМ";
			return users;

		}
		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="id">id пользователя</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.User"/>with exact id from the database </returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpGet("[action]/{id}")]
		public async Task<ActionResult<User>> Get(int id, CancellationToken cancellationToken)
		{
			User? user = await db.Users.FirstOrDefaultAsync(
				x => x.UserId == id,
				cancellationToken);
			if (user == null)
				return NotFound();
			if (user.UserId == 1)
				return BadRequest("Фиг вам!");
			return new ObjectResult(user);
		}
		/// <summary>
		/// Добавление пользователя в бд. Доступ есть без авторизации
		/// </summary>
		/// <param name="user">Input user</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.User"/></returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (Обычно, проблема c Id, нужно оставить нулевым)</response>
		[HttpPost("[action]")]
		public async Task<ActionResult<User>> Post(User user, CancellationToken cancellationToken)
		{
			if (user == null)
			{
				return BadRequest();
			}

			db.Users.Add(user);
			await db.SaveChangesAsync(cancellationToken);
			return Ok(user);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="user">Input user</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.User"/> with given id from the database if succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpPut("[action]")]
		public async Task<ActionResult<User>> Put(User user, CancellationToken cancellationToken)
		{
			if (user == null)
			{
				return BadRequest();
			}
			if (!db.Users.Any(x => x.UserId == user.UserId))
			{
				return NotFound();
			}

			db.Update(user);
			await db.SaveChangesAsync(cancellationToken);
			return Ok(user);
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
		public async Task<ActionResult<User>> Delete(int id, CancellationToken cancellationToken)
		{
			var user = new User { UserId = id};//создание объекта-заглушки
			var result = db.Remove(user);
			await db.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok();
			}
			else
				return NotFound();

		}
	}
}