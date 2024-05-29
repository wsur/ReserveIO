using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;


namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RolesController : ControllerBase
	{
		readonly UsersContext usersContext;
		public RolesController(UsersContext context)
		{
			usersContext = context;

		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.Role"/> from the database</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<Role>>> Get(CancellationToken cancellationToken)
		{
			return await usersContext.Roles.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="id">Input Role</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Role"/>with exact id from the database </returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpGet("[action]/{id}")]
		public async Task<ActionResult<Role>> Get(int id, CancellationToken cancellationToken)
		{
			Role? role = await usersContext.Roles.FirstOrDefaultAsync(x => x.RoleId == id, cancellationToken);
			if (role == null)
				return NotFound();
			return new ObjectResult(role);
		}
		/// <summary>
		/// Method POST is used for add brand-new user to database without writing an user id
		/// </summary>
		/// <param name="role">Input role</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Role"/></returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="401">Пользователь не авторизован/нет доступа к ресурсу</response>
		/// <response code="500">Ошибка API (Обычно, проблема c Id, нужно оставить нулевым)</response>
		[Authorize]
		[HttpPost("[action]")]
		public async Task<ActionResult<Role>> Post(Role role, CancellationToken cancellationToken)
		{
			if (role == null)
			{
				return BadRequest();
			}

			usersContext.Roles.Add(role);
			var r = await usersContext.SaveChangesAsync(cancellationToken);
			if (r == 0)
			{
				return BadRequest("Изменения не записались в базу");
			}
			return Ok(role);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="role">Input role</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Role"/> with given id from the database if succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="401">Пользователь не авторизован/нет доступа к ресурсу</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpPut("[action]")]
		public async Task<ActionResult<Role>> Put(Role role, CancellationToken cancellationToken)
		{
			if (role == null)
			{
				return BadRequest();
			}
			if (!usersContext.Roles.Any(x => x.RoleId == role.RoleId))
			{
				return NotFound();
			}

			usersContext.Update(role);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(role);
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="id">Id for user that we want to delete from the database</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="401">Пользователь не авторизован/нет доступа к ресурсу</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpDelete("[action]")]
		public async Task<ActionResult<Role>> Delete(int id, CancellationToken cancellationToken)
		{
			Role? role = await usersContext.Roles.FirstOrDefaultAsync(x => x.RoleId == id, cancellationToken);
			if (role == null)
				return NotFound();
			role.Delete = true;
			usersContext.Update(role);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(role);

		}
	}
}
