using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserRoomController : ControllerBase
	{
		readonly UsersContext userRoomDb;
		public UserRoomController(UsersContext context)
		{
			userRoomDb = context;

		}

		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.UserRoom"/> from the database</returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserRoom>>> Get(CancellationToken cancellationToken)
		{
			return await userRoomDb.UserRooms.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserRoom"/>with exact id from the database </returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<UserRoom>> Get(int id, CancellationToken cancellationToken)
		{
			UserRoom userRoom = await userRoomDb.UserRooms.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
			if (userRoom == null)
				return NotFound();
			return new ObjectResult(userRoom);
		}
		/// <summary>
		/// Method POST is used for add brand-new user to database without writing an user id
		/// </summary>
		/// <param name="UserRoom">Input UserRoom</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserRoom"/></returns>
		[HttpPost]
		public async Task<ActionResult<UserRoom>> Post(UserRoom userRoom, CancellationToken cancellationToken)
		{
			if (userRoom == null)
			{
				return BadRequest();
			}

			userRoomDb.UserRooms.Add(userRoom);
			await userRoomDb.SaveChangesAsync(cancellationToken);
			return Ok(userRoom);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="UserRoom">Input UserRoom</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserRoom"/> with given id from the database if succeded</returns>
		[HttpPut]
		public async Task<ActionResult<UserRoom>> Put(UserRoom userRoom, CancellationToken cancellationToken)
		{
			if (userRoom == null)
			{
				return BadRequest();
			}
			if (!userRoomDb.UserRooms.Any(x => x.UserId == userRoom.UserId))
			{
				return NotFound();
			}

			userRoomDb.Update(userRoom);
			await userRoomDb.SaveChangesAsync(cancellationToken);
			return Ok(userRoom);
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="id">Id for user that we want to delete from the database</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		[HttpDelete("{id}")]
		public async Task<ActionResult<UserRoom>> Delete(int id, CancellationToken cancellationToken)
		{
			UserRoom userRoom = await userRoomDb.UserRooms.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
			if (userRoom == null)
				return NotFound("Такой записи нет");
			var result = userRoomDb.Remove(userRoom);
			await userRoomDb.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok(userRoom);
			}
			else
				return NotFound("Операция не выполнена");

		}
	}
}
