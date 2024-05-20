using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ServiceController : ControllerBase
	{
		readonly UsersContext usersContext;
		public ServiceController(UsersContext context)
		{
			usersContext = context;

		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.Service"/> from the database</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Service>>> Get(CancellationToken cancellationToken)
		{
			return await usersContext.Services.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="id">Input Service</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Service"/>with exact id from the database </returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpGet("{id}")]
		public async Task<ActionResult<Service>> Get(int id, CancellationToken cancellationToken)
		{
			Service service = await usersContext.Services.FirstOrDefaultAsync(x => x.ServiceId == id, cancellationToken);
			if (service == null)
				return NotFound();
			return new ObjectResult(service);
		}
		/// <summary>
		/// Method POST is used for add brand-new user to database without writing an user id
		/// </summary>
		/// <param name="service">Input Service</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Service"/></returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpPost]
		public async Task<ActionResult<Service>> Post(Service service, CancellationToken cancellationToken)
		{
			if (service == null)
			{
				return BadRequest();
			}

			usersContext.Services.Add(service);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(service);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="service">Input Service</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Service"/> with given id from the database if succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpPut]
		public async Task<ActionResult<Service>> Put(Service service, CancellationToken cancellationToken)
		{
			if (service == null)
			{
				return BadRequest();
			}
			if (!usersContext.Services.Any(x => x.ServiceId == service.ServiceId))
			{
				return NotFound();
			}

			usersContext.Update(service);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(service);
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="id">Id for user that we want to delete from the database</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpDelete("{id}")]
		public async Task<ActionResult<Service>> Delete(int id, CancellationToken cancellationToken)
		{
			Service service = await usersContext.Services.FirstOrDefaultAsync(x => x.ServiceId == id, cancellationToken);
			if(service == null)
				return NotFound("Такой записи нет");
			var result = usersContext.Remove(service);
			await usersContext.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok(service);
			}
			else
				return NotFound("Изменения не были применены");

		}
	}
}
