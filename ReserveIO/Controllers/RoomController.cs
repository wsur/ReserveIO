﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RoomController : ControllerBase
	{
		readonly UsersContext usersContext;
		public RoomController(UsersContext context)
		{
			usersContext = context;
		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.Room"/> from the database</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<Room>>> Get(CancellationToken cancellationToken)
		{
			return await usersContext.Rooms.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="id">Input Room</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Room"/>with exact id from the database </returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpGet("([action]/{id}")]
		public async Task<ActionResult<Room>> Get(int id, CancellationToken cancellationToken)
		{
			Room? room = await usersContext.Rooms.FirstOrDefaultAsync(x => x.RoomId == id, cancellationToken);
			if (room == null)
				return NotFound();
			return new ObjectResult(room);
		}
		/// <summary>
		/// Добавление новой комнаты
		/// </summary>
		/// <param name="room">Input Room</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Room"/></returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (Обычно, проблема c Id, нужно оставить нулевым)</response>
		[Authorize(Roles = "Owner,Lessor")]
		[HttpPost("[action]")]
		public async Task<ActionResult<Room>> Post(Room room, CancellationToken cancellationToken)
		{
			if (room == null)
			{
				return BadRequest();
			}

			usersContext.Rooms.Add(room);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(room);
		}
		/// <summary>
		/// Изменить параметры существующей комнаты
		/// </summary>
		/// <param name="room">Input Room</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Room"/> with given id from the database if succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize(Roles = "Owner,Lessor")]
		[HttpPut("[action]")]
		public async Task<ActionResult<Room>> Put(Room room, CancellationToken cancellationToken)
		{
			if (room == null)
			{
				return BadRequest();
			}
			if (!usersContext.Rooms.Any(x => x.RoomId == room.RoomId))
			{
				return NotFound();
			}

			usersContext.Update(room);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(room);
		}
		/// <summary>
		/// Удалить комнату
		/// </summary>
		/// <param name="id">Id for user that we want to delete from the database</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize(Roles = "Owner,Lessor")]
		[HttpDelete("[action]")]
		public async Task<ActionResult<Room>> Delete(int id, CancellationToken cancellationToken)
		{
			Room Room = new Room { RoomId = id };//создание объекта-заглушки
			var result = usersContext.Remove(Room);
			await usersContext.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok();
			}
			else
				return NotFound();

		}
	}
}
