using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserLogPassController : ControllerBase
	{
		readonly UsersContext usersContext;
		public UserLogPassController(UsersContext context)
		{
			usersContext = context;

		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.UserLogPass"/> from the database</returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserLogPass>>> Get(CancellationToken cancellationToken)
		{
			return await usersContext.UserLogPasses.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="id">Input UserlogPass</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserLogPass"/>with exact id from the database </returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<UserLogPass>> Get(int id, CancellationToken cancellationToken)
		{
			UserLogPass userLogPass = await usersContext.UserLogPasses.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
			if (userLogPass == null)
				return NotFound();
			return new ObjectResult(userLogPass);
		}
		/// <summary>
		/// Method POST is used for add brand-new user to database without writing an user id
		/// </summary>
		/// <param name="userLogPass">Input UserLogPass</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserLogPass"/></returns>
		[HttpPost]
		public async Task<ActionResult<UserLogPass>> Post(UserLogPass userLogPass, CancellationToken cancellationToken)
		{
			if (userLogPass == null)
			{
				return BadRequest();
			}

			usersContext.UserLogPasses.Add(userLogPass);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(userLogPass);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="userLogPass">Input UserLogPass</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.UserLogPass"/> with given id from the database if succeded</returns>
		[HttpPut]
		public async Task<ActionResult<UserLogPass>> Put(UserLogPass userLogPass, CancellationToken cancellationToken)
		{
			if (userLogPass == null)
			{
				return BadRequest();
			}
			if (!usersContext.UserLogPasses.Any(x => x.UserId == userLogPass.UserId))
			{
				return NotFound();
			}

			usersContext.Update(userLogPass);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(userLogPass);
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="id">Id for user that we want to delete from the database</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		[HttpDelete("{id}")]
		public async Task<ActionResult<UserLogPass>> Delete(int id, CancellationToken cancellationToken)
		{
			//UserLogPass userLogPass = new UserLogPass { UserId = id };//создание объекта-заглушки
			UserLogPass userLogPass = await usersContext.UserLogPasses.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
			if (userLogPass == null)
				return NotFound("Логин и пароль с данным id не был найден");
			var result = usersContext.Remove(userLogPass);
			await usersContext.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok(userLogPass);
			}
			else
				return NotFound("Удаление из бд не было произведено");

		}
	}
}
