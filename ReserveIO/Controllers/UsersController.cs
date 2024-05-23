using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;
//using ReserveIO.Repositories;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		readonly UsersContext usersContext;

		public UsersController(UsersContext context)
		{
			usersContext = context;

		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.User"/> from the database</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<User>>> Get(CancellationToken cancellationToken)
		{
			return await usersContext.Users.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос

		}
		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="id">Input User</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.User"/>with exact id from the database </returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpGet("[action]/{id}")]
		public async Task<ActionResult<User>> Get(int id, CancellationToken cancellationToken)
		{
			User user = await usersContext.Users.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
			if (user == null)
				return NotFound();
			return new ObjectResult(user);
		}
		/// <summary>
		/// Method POST is used for add brand-new user to database without writing an user id
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

			usersContext.Users.Add(user);
			await usersContext.SaveChangesAsync(cancellationToken);
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
		[HttpPut("[action]")]
		public async Task<ActionResult<User>> Put(User user, CancellationToken cancellationToken)
		{
			if (user == null)
			{
				return BadRequest();
			}
			if (!usersContext.Users.Any(x => x.UserId == user.UserId))
			{
				return NotFound();
			}

			usersContext.Update(user);
			await usersContext.SaveChangesAsync(cancellationToken);
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
		[HttpDelete("[action]")]
		public async Task<ActionResult<User>> Delete(int id, CancellationToken cancellationToken)
		{
			User user = await usersContext.Users.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
			if (user == null)
				return NotFound("Такого пользователя нет");
			user.Delete = true;//проставляем состояние удаления
			usersContext.Update(user);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(user);

		}
	}
}