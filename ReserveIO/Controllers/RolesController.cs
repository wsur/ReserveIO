using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;


namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RolesController : ControllerBase
	{
		readonly UsersContext roles_db;
		public RolesController(UsersContext context)
		{
			roles_db = context;

		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.Role"/> from the database</returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Role>>> Get(CancellationToken cancellationToken)
		{
			return await roles_db.Roles.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Role"/>with exact id from the database </returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<Role>> Get(int id, CancellationToken cancellationToken)
		{
			Role role = await roles_db.Roles.FirstOrDefaultAsync(x => x.RoleId == id, cancellationToken);
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
		[HttpPost]
		public async Task<ActionResult<Role>> Post(Role role, CancellationToken cancellationToken)
		{
			if (role == null)
			{
				return BadRequest();
			}

			roles_db.Roles.Add(role);
			await roles_db.SaveChangesAsync(cancellationToken);
			return Ok(role);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="role">Input role</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Role"/> with given id from the database if succeded</returns>
		[HttpPut]
		public async Task<ActionResult<Role>> Put(Role role, CancellationToken cancellationToken)
		{
			if (role == null)
			{
				return BadRequest();
			}
			if (!roles_db.Roles.Any(x => x.RoleId == role.RoleId))
			{
				return NotFound();
			}

			roles_db.Update(role);
			await roles_db.SaveChangesAsync(cancellationToken);
			return Ok(role);
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="id">Id for user that we want to delete from the database</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		[HttpDelete("{id}")]
		public async Task<ActionResult<Role>> Delete(int id, CancellationToken cancellationToken)
		{
			Role role = new Role { RoleId = id };//создание объекта-заглушки
			var result = roles_db.Remove(role);
			await roles_db.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok();
			}
			else
				return NotFound();

		}
	}
}
