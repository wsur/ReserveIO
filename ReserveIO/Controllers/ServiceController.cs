using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ServiceController : ControllerBase
	{
		readonly UsersContext service_db;
		public ServiceController(UsersContext context)
		{
			service_db = context;

		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.Service"/> from the database</returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Service>>> Get(CancellationToken cancellationToken)
		{
			return await service_db.Services.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Service"/>with exact id from the database </returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<Service>> Get(int id, CancellationToken cancellationToken)
		{
			Service service = await service_db.Services.FirstOrDefaultAsync(x => x.ServiceId == id, cancellationToken);
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
		[HttpPost]
		public async Task<ActionResult<Service>> Post(Service service, CancellationToken cancellationToken)
		{
			if (service == null)
			{
				return BadRequest();
			}

			service_db.Services.Add(service);
			await service_db.SaveChangesAsync(cancellationToken);
			return Ok(service);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="service">Input Service</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.Service"/> with given id from the database if succeded</returns>
		[HttpPut]
		public async Task<ActionResult<Service>> Put(Service service, CancellationToken cancellationToken)
		{
			if (service == null)
			{
				return BadRequest();
			}
			if (!service_db.Services.Any(x => x.ServiceId == service.ServiceId))
			{
				return NotFound();
			}

			service_db.Update(service);
			await service_db.SaveChangesAsync(cancellationToken);
			return Ok(service);
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="id">Id for user that we want to delete from the database</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		[HttpDelete("{id}")]
		public async Task<ActionResult<Service>> Delete(int id, CancellationToken cancellationToken)
		{
			Service service = await service_db.Services.FirstOrDefaultAsync(x => x.ServiceId == id, cancellationToken);
			if(service == null)
				return NotFound("Такой записи нет");
			var result = service_db.Remove(service);
			await service_db.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok(service);
			}
			else
				return NotFound("Изменения не были применены");

		}
	}
}
