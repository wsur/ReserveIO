using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CostHourController : ControllerBase
	{
		readonly UsersContext CostHourDb;
		public CostHourController(UsersContext context)
		{
			CostHourDb = context;
		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.CostHour"/> from the database</returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CostHour>>> Get(CancellationToken cancellationToken)
		{
			return await CostHourDb.CostHours.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.CostHour"/>with exact id from the database </returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<CostHour>> Get(int id, CancellationToken cancellationToken)
		{
			CostHour costHour = await CostHourDb.CostHours.FirstOrDefaultAsync(x => x.CostId == id, cancellationToken);
			if (costHour == null)
				return NotFound();
			return new ObjectResult(costHour);
		}
		/// <summary>
		/// Method POST is used for add brand-new user to database without writing an user id
		/// </summary>
		/// <param name="CostHour">Input CostHour</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.CostHour"/></returns>
		[HttpPost]
		public async Task<ActionResult<CostHour>> Post(CostHour costHour, CancellationToken cancellationToken)
		{
			if (costHour == null)
			{
				return BadRequest();
			}

			CostHourDb.CostHours.Add(costHour);
			await CostHourDb.SaveChangesAsync(cancellationToken);
			return Ok(costHour);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="CostHour">Input CostHour</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.CostHour"/> with given id from the database if succeded</returns>
		[HttpPut]
		public async Task<ActionResult<CostHour>> Put(CostHour costHour, CancellationToken cancellationToken)
		{
			
			if (costHour == null)
			{
				return BadRequest("Данные не введены");
			}
			if (!CostHourDb.CostHours.Any(x => x.CostId == costHour.CostId))
			{
				return NotFound("Такой сущности нет");
			}
			CostHourDb.Update(costHour);
			await CostHourDb.SaveChangesAsync(cancellationToken);
			return Ok(costHour);
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="id">Id for user that we want to delete from the database</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		[HttpDelete("{id}")]
		public async Task<ActionResult<CostHour>> Delete(int id, CancellationToken cancellationToken)
		{
			CostHour costHour = new CostHour { CostId = id };//создание объекта-заглушки
			var result = CostHourDb.Remove(costHour);
			await CostHourDb.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok();
			}
			else
				return NotFound();

		}
	}
}
