using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
	[HttpGet]
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
		[HttpGet("{id}")]
	public async Task<ActionResult<UserRole>> Get(int id, CancellationToken cancellationToken)
	{
		UserRole userRole = await usersContext.UserRoles.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
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
		[HttpPost]
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
		/// <param name="userRole">Input UserRole</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserRoles"/> with given id from the database if succeded</returns>
		[HttpPut]
	public async Task<ActionResult<UserRole>> Put(UserRole userRole, CancellationToken cancellationToken)
	{
		if (userRole == null)
		{
			return BadRequest();
		}
		UserRole userRole1 = await usersContext.UserRoles.FirstOrDefaultAsync(x => x.UserId == userRole.UserId, cancellationToken);
		if (userRole1 == null)
		{
			return NotFound("Такой сущности нет");
		}
		usersContext.Remove(userRole1);//все поля ключевые, нельзя изменить просто так
		usersContext.Add(userRole);
		await usersContext.SaveChangesAsync(cancellationToken);
		return Ok(userRole);
	}
	/// <summary>
	/// Method Delete is used for Deleting userRole that exist in database
	/// </summary>
	/// <param name="id">Id for userRole that we want to delete from the database</param>
	/// <param name="cancellationToken">There is cancellation token</param>
	/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
	[HttpDelete("{id}")]
	public async Task<ActionResult<User>> Delete(int id, CancellationToken cancellationToken)
	{
		UserRole userRole = await usersContext.UserRoles.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
		if (userRole == null)
			return NotFound("У пользователя не определена роль");
			//UserRole userRole = new UserRole { UserId = id };//создание объекта-заглушки
		var result = usersContext.Remove(userRole);
		await usersContext.SaveChangesAsync(cancellationToken);
		if (result != null)
		{
			return Ok(userRole);
		}
		else
			return NotFound("Удаление не произошло");

	}
}
}
