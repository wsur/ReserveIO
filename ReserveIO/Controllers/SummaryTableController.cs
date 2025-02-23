using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
		[ApiController]
		[Route("api/[controller]")]
		public class SummaryTableController : ControllerBase
		{
			readonly UsersContext usersContext;
			public SummaryTableController(UsersContext context)
			{
				usersContext = context;

			}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.SummaryTable"/> from the database</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpGet("[action]")]
			public async Task<ActionResult<IEnumerable<SummaryTable>>> Get(CancellationToken cancellationToken)
			{
				return await usersContext.SummaryTables.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
			}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="id">Input SummaryTable</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.SummaryTable"/>with exact id from the database </returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpGet("[action]/{id}")]
			public async Task<ActionResult<SummaryTable>> Get(int id, CancellationToken cancellationToken)
			{
				SummaryTable? summaryTable = await usersContext.SummaryTables.FirstOrDefaultAsync(x => x.SummaryId == id, cancellationToken);
				if (summaryTable == null)
					return NotFound();
				return new ObjectResult(summaryTable);
			}
		/// <summary>
		/// Method POST is used for add brand-new user to database without writing an user id
		/// </summary>
		/// <param name="summaryTable">Input SummaryTable</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.SummaryTable"/></returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (Обычно, проблема c Id, нужно оставить нулевым)</response>
		[Authorize]
		[HttpPost("[action]")]
			public async Task<ActionResult<SummaryTable>> Post(SummaryTable summaryTable, CancellationToken cancellationToken)
			{
				if (summaryTable == null)
				{
					return BadRequest();
				}

				usersContext.SummaryTables.Add(summaryTable);
				await usersContext.SaveChangesAsync(cancellationToken);
				return Ok(summaryTable);
			}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="summaryTable">Input SummaryTable</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.SummaryTable"/> with given id from the database if succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpPut("[action]")]
			public async Task<ActionResult<SummaryTable>> Put(SummaryTable summaryTable, CancellationToken cancellationToken)
			{
				if (summaryTable == null)
				{
					return BadRequest();
				}
				if (!usersContext.SummaryTables.Any(x => x.SummaryId == summaryTable.SummaryId))
				{
					return NotFound();
				}

				usersContext.Update(summaryTable);
				await usersContext.SaveChangesAsync(cancellationToken);
				return Ok(summaryTable);
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
		[Authorize]
		[HttpDelete("[action]")]
			public async Task<ActionResult<SummaryTable>> Delete(int id, CancellationToken cancellationToken)
			{
				SummaryTable? summaryTable = await usersContext.SummaryTables.FirstOrDefaultAsync(x => x.SummaryId == id, cancellationToken);
				if (summaryTable == null)
					return NotFound("Такой записи нет");
				var result = usersContext.Remove(summaryTable);
				await usersContext.SaveChangesAsync(cancellationToken);
				if (result != null)
				{
					return Ok(summaryTable);
				}
				else
					return NotFound("Операция не выполнена");

			}
		}
}
