using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RoomController : ControllerBase
	{
		readonly UsersContext RoomDb;
		public RoomController(UsersContext context)
		{
			RoomDb = context;
		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.Room"/> from the database</returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Room>>> Get(CancellationToken cancellationToken)
		{
			return await RoomDb.Rooms.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Room"/>with exact id from the database </returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<Room>> Get(int id, CancellationToken cancellationToken)
		{
			Room room = await RoomDb.Rooms.FirstOrDefaultAsync(x => x.RoomId == id, cancellationToken);
			if (room == null)
				return NotFound();
			return new ObjectResult(room);
		}
		/// <summary>
		/// Method POST is used for add brand-new user to database without writing an user id
		/// </summary>
		/// <param name="Room">Input Room</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Room"/></returns>
		[HttpPost]
		public async Task<ActionResult<Room>> Post(Room room, CancellationToken cancellationToken)
		{
			if (room == null)
			{
				return BadRequest();
			}

			RoomDb.Rooms.Add(room);
			await RoomDb.SaveChangesAsync(cancellationToken);
			return Ok(room);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="Room">Input Room</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Room"/> with given id from the database if succeded</returns>
		[HttpPut]
		public async Task<ActionResult<Room>> Put(Room room, CancellationToken cancellationToken)
		{
			if (room == null)
			{
				return BadRequest();
			}
			if (!RoomDb.Rooms.Any(x => x.RoomId == room.RoomId))
			{
				return NotFound();
			}

			RoomDb.Update(room);
			await RoomDb.SaveChangesAsync(cancellationToken);
			return Ok(room);
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="id">Id for user that we want to delete from the database</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		[HttpDelete("{id}")]
		public async Task<ActionResult<Room>> Delete(int id, CancellationToken cancellationToken)
		{
			Room Room = new Room { RoomId = id };//создание объекта-заглушки
			var result = RoomDb.Remove(Room);
			await RoomDb.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok();
			}
			else
				return NotFound();

		}
	}
}
