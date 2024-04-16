using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		UsersContext db;
		public UsersController(UsersContext context)
		{
			db = context;
			/*			if (!db.Users.Any())
						{
							db.Users.Add(new User { Name = "Tom", Age = 26 });
							db.Users.Add(new User { Name = "Alice", Age = 31 });
							db.SaveChanges();
						}*/

		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> Get(CancellationToken cancellationToken)
		{
			return await db.Users.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<User>> Get(int id, CancellationToken cancellationToken)
		{
			User user = await db.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (user == null)
				return NotFound();
			return new ObjectResult(user);
		}
		[HttpPost]
		public async Task<ActionResult<User>> Post(User user, CancellationToken cancellationToken)
		{
			if (user == null)
			{
				return BadRequest();
			}

			db.Users.Add(user);
			await db.SaveChangesAsync(cancellationToken);
			return Ok(user);
		}
		[HttpPut]
		public async Task<ActionResult<User>> Put(User user, CancellationToken cancellationToken)
		{
			if (user == null)
			{
				return BadRequest();
			}
			if (!db.Users.Any(x => x.Id == user.Id))
			{
				return NotFound();
			}

			db.Update(user);
			await db.SaveChangesAsync(cancellationToken);
			return Ok(user);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<User>> Delete(int id, CancellationToken cancellationToken)
		{
			User user = new User { Id = id};//создание объекта-заглушки
			var result = db.Remove(user);
			await db.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok();
			}
			else
				return NotFound();

		}
	}
}