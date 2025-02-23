using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

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
		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> Get(CancellationToken cancellationToken)
		{
			return await db.Users.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}
		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="id">id пользователя</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.User"/>with exact id from the database </returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<User>> Get(int id, CancellationToken cancellationToken)
		{
			User? user = await db.Users.FirstOrDefaultAsync(
				x => x.Id == id,
				cancellationToken);
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
		[HttpPost]
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
		[HttpPut]
		public async Task<ActionResult<User>> Put(User user, CancellationToken cancellationToken)
		{
			if (user == null)
			{
				return BadRequest();
			}
			if (!db.Users.Any(x => x.Id == user.Id))
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
		[HttpDelete("{id}")]
		public async Task<ActionResult<User>> Delete(int id, CancellationToken cancellationToken)
		{
			var user = new User { Id = id};//создание объекта-заглушки
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