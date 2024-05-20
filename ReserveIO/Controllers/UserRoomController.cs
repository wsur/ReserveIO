using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserRoomController : ControllerBase
	{
		readonly UsersContext usersContext;
		public UserRoomController(UsersContext context)
		{
			usersContext = context;

		}

		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.UserRoom"/> from the database</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserRoom>>> Get(CancellationToken cancellationToken)
		{
			return await usersContext.UserRooms.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="id">Input User/Room connection</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserRoom"/>with exact id from the database </returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpGet("{id}")]
		public async Task<ActionResult<UserRoom>> Get(int id, CancellationToken cancellationToken)
		{
			UserRoom userRoom = await usersContext.UserRooms.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
			if (userRoom == null)
				return NotFound();
			return new ObjectResult(userRoom);
		}
		/// <summary>
		/// Method POST is used for add brand-new user to database without writing an user id
		/// </summary>
		/// <param name="userRoom">Input UserRoom</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserRoom"/></returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (Таких ID нет, проблема с ID)</response>
		[HttpPost]
		public async Task<ActionResult<UserRoom>> Post(UserRoom userRoom, CancellationToken cancellationToken)
		{
			if (userRoom == null)
			{
				return BadRequest();
			}

			usersContext.UserRooms.Add(userRoom);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(userRoom);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="userRoom">Input UserRoom</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserRoom"/> with given id from the database if succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpPut]
		public async Task<ActionResult<UserRoom>> Put(UserRoom userRoom, CancellationToken cancellationToken)
		{
			if (userRoom == null)
			{
				return BadRequest();
			}
			if (!usersContext.UserRooms.Any(x => x.UserId == userRoom.UserId))
			{
				return NotFound();
			}

			usersContext.Update(userRoom);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(userRoom);
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
		[HttpDelete("{id}")]
		public async Task<ActionResult<UserRoom>> Delete(int id, CancellationToken cancellationToken)
		{
			UserRoom userRoom = await usersContext.UserRooms.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
			if (userRoom == null)
				return NotFound("Такой записи нет");
			var result = usersContext.Remove(userRoom);
			await usersContext.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok(userRoom);
			}
			else
				return NotFound("Операция не выполнена");

		}
	}
}
