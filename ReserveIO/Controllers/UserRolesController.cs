using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using ReserveIO.Models;
namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserRolesController : ControllerBase
	{
		readonly UsersContext usersContext;
		public UserRolesController(UsersContext context)
		{
			usersContext = context;

		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.UserRoles"/> from the database</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpGet("[action]")]
	public async Task<ActionResult<IEnumerable<UserRole>>> Get(CancellationToken cancellationToken)
	{
		return await usersContext.UserRoles.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
	}
		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="id">Input User/Role connection</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserRoles"/>with exact id from the database </returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpGet("[action]/{id}")]
	public async Task<ActionResult<UserRole>> Get(int id, CancellationToken cancellationToken)
	{
		UserRole? userRole = await usersContext.UserRoles.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
		if (userRole == null)
			return NotFound();
		return new ObjectResult(userRole);
	}
		/// <summary>
		/// Method POST is used for add brand-new userRole to database without writing an userRole id
		/// </summary>
		/// <param name="userRole">Input UserRole</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserRoles"/></returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (Таких ID нет, проблема с ID)</response>
		[HttpPost("[action]")]
	public async Task<ActionResult<UserRole>> Post(UserRole userRole, CancellationToken cancellationToken)
	{
		if (userRole == null)
		{
			return BadRequest();
		}

		usersContext.UserRoles.Add(userRole);
		await usersContext.SaveChangesAsync(cancellationToken);
		return Ok(userRole);
	}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="userId">id пользователя</param>
		/// <param name="roleId">id роли</param>
		/// <param name="userIdNew">новый id пользователя</param>
		/// <param name="roleIdNew">новый id роли</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserRoles"/> with given id from the database if succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpPut("[action]")]
	public async Task<ActionResult<UserRole>> Put(int userId, int roleId, int userIdNew, int roleIdNew, CancellationToken cancellationToken)
	{
			Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<UserRole>? result = null;
			UserRole s1 = new UserRole { UserId = 0 };//стандартная заглушка
														//Необходимо сначала узнать id объекта -- получить его из бд.
			var userRoomMany = usersContext.UserRoles.Where(u =>
			EF.Functions.Like(u.UserId.ToString(), userId.ToString())
			);
			foreach (UserRole s in userRoomMany)
			{
				if (s.RoleId == roleId)
				{
					//меняем параметры сущности
					s1.UserRoleId = s.UserRoleId;
					s1.UserId = userIdNew;
					s1.RoleId = roleIdNew;
					//т.к. ReserveId и ServiceId являются внешними ключами, то необходимо удалить сущность и создать новую.
					usersContext.Remove(s);//удаляем
					result = usersContext.Add(s1);
				}
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
		/// Method Delete is used for Deleting userRole that exist in database
		/// </summary>
		/// <param name="userId">id пользователя</param>
		/// <param name="roleId">id роли пользователя</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpDelete("[action]")]
	public async Task<ActionResult<UserRole>> Delete(int userId, int roleId, CancellationToken cancellationToken)
	{
			Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<UserRole>? result = null;
			UserRole? s1 = null;
			var userRoleMany = usersContext.UserRoles.Where(u =>
			EF.Functions.Like(u.UserId.ToString(), userId.ToString())
			);
			foreach (UserRole? s in userRoleMany)
			{
				if (s.RoleId == roleId)
				{
					result = usersContext.Remove(s);
					s1 = s;
				}
			}
		if (s1 == null)
			return NotFound("У пользователя нет такой роли");
		await usersContext.SaveChangesAsync(cancellationToken);
		if (result != null)
		{
			return Ok(s1);
		}
		else
			return NotFound("Удаление не произошло");

	}
}
}
