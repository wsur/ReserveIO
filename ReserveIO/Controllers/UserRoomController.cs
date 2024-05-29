using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
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
		[Authorize]
		[HttpGet("[action]")]
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
		[Authorize]
		[HttpGet("[action]/{id}")]
		public async Task<ActionResult<UserRoom>> Get(int id, CancellationToken cancellationToken)
		{
			UserRoom? userRoom = await usersContext.UserRooms.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
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
		[Authorize(Roles ="Owner,Lessor")]
		[HttpPost("[action]")]
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
		/// <param name="userId">Id пользователя в БД</param>
		/// <param name="roomId">Id комнаты в БД</param>
		/// <param name="userIdNew">Новый Id пользователя</param>
		/// <param name="roomIdNew">Новый Id комнаты</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserRoom"/> with given id from the database if succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize(Roles = "Owner,Lessor")]
		[HttpPut("[action]")]
		public async Task<ActionResult<UserRoom>> Put(int userId, int roomId, int userIdNew, int roomIdNew, CancellationToken cancellationToken)
		{
			Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<UserRoom>? result = null;
			UserRoom s1 = new UserRoom { UserRoomId = 0};//стандартная заглушка
			//Необходимо сначала узнать id объекта -- получить его из бд.
			var userRoomMany = usersContext.UserRooms.Where(u =>
			EF.Functions.Like(u.UserId.ToString(), userId.ToString())
			);
			foreach (UserRoom s in userRoomMany)
			{
				if (s.RoomId == roomId)
				{
					//меняем параметры сущности
					s1.UserRoomId = s.UserRoomId;
					s1.RoomId = roomIdNew;
					s1.UserId = userIdNew;
					//т.к. roomId и userId являются внешними ключами, то необходимо удалить сущность и создать новую.
					usersContext.Remove(s);//удаляем
					result = usersContext.Add(s1);
				}
			}
			if (s1 == null)
			{
				return NotFound("Такой сущности нет");
			}
			if (result != null)
			{
				//только в этом случае имеет смысл сохранять в бд данные.
				await usersContext.SaveChangesAsync(cancellationToken);
				return Ok(s1);
			}
			else
				return NotFound("Данные не обновились");
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="userId">Id пользователя</param>
		/// <param name="roomId">Id комнаты в его собственности</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize(Roles = "Owner,Lessor")]
		[HttpDelete("[action]")]
		public async Task<ActionResult<UserRoom>> Delete(int userId, int roomId, CancellationToken cancellationToken)
		{
			Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<UserRoom>? result = null;
			UserRoom? s1 = null;
			
			var userRoomMany = usersContext.UserRooms.Where(u =>
			EF.Functions.Like(u.UserId.ToString(), userId.ToString())
			);
			foreach (UserRoom s in userRoomMany)
			{
				if (s.RoomId == roomId)
				{
					result = usersContext.Remove(s);
					s1 = s;
				}
			}

			if (s1 == null)
				return NotFound("Такой записи нет");

			await usersContext.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok(s1);
			}
			else
				return NotFound("Операция не выполнена");

		}
	}
}
