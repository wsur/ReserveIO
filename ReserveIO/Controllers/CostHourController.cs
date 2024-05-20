using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CostHourController : ControllerBase
	{
		readonly UsersContext usersContext;
		public CostHourController(UsersContext context)
		{
			usersContext = context;
		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.CostHour"/> from the database</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CostHour>>> Get(CancellationToken cancellationToken)
		{
			return await usersContext.CostHours.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.CostHour"/>with exact id from the database </returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpGet("{id}")]
		public async Task<ActionResult<CostHour>> Get(int id, CancellationToken cancellationToken)
		{
			CostHour costHour = await usersContext.CostHours.FirstOrDefaultAsync(x => x.CostId == id, cancellationToken);
			if (costHour == null)
				return NotFound();
			return new ObjectResult(costHour);
		}
		/// <summary>
		/// Method POST is used for add brand-new user to database without writing an user id
		/// </summary>
		/// <param name="costHour">Input CostHour</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.CostHour"/></returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (Обычно, проблема c Id, нужно оставить нулевым)</response>
		[HttpPost]
		public async Task<ActionResult<CostHour>> Post(CostHour costHour, CancellationToken cancellationToken)
		{
			if (costHour == null)
			{
				return BadRequest();
			}

			usersContext.CostHours.Add(costHour);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(costHour);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="costHour">Input CostHour</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.CostHour"/> with given id from the database if succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpPut]
		public async Task<ActionResult<CostHour>> Put(CostHour costHour, CancellationToken cancellationToken)
		{
			
			if (costHour == null)
			{
				return BadRequest("Данные не введены");
			}
			if (!usersContext.CostHours.Any(x => x.CostId == costHour.CostId))
			{
				return NotFound("Такой сущности нет");
			}
			usersContext.Update(costHour);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(costHour);
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="id">Id for cost note that we want to delete from the database</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[HttpDelete("{id}")]
		public async Task<ActionResult<CostHour>> Delete(int id, CancellationToken cancellationToken)
		{
			CostHour costHour = new CostHour { CostId = id };//создание объекта-заглушки
			var result = usersContext.Remove(costHour);
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
