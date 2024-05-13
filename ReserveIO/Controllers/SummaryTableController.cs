using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
		[ApiController]
		[Route("api/[controller]")]
		public class SummaryTableController : ControllerBase
		{
			readonly UsersContext summaryDb;
			public SummaryTableController(UsersContext context)
			{
				summaryDb = context;

			}
			/// <summary>
			/// Methon get is used for getting all elements from database
			/// </summary>
			/// <param name="cancellationToken">There is cancellation token</param>
			/// <returns>All <see cref="T:ReserveIO.Models.SummaryTable"/> from the database</returns>
			[HttpGet]
			public async Task<ActionResult<IEnumerable<SummaryTable>>> Get(CancellationToken cancellationToken)
			{
				return await summaryDb.SummaryTables.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
			}

			/// <summary>
			/// Methon get is used for getting element with exact id
			/// </summary>
			/// <param name="cancellationToken">There is cancellation token</param>
			/// <returns><see cref="T:ReserveIO.Models.SummaryTable"/>with exact id from the database </returns>
			[HttpGet("{id}")]
			public async Task<ActionResult<SummaryTable>> Get(int id, CancellationToken cancellationToken)
			{
				SummaryTable summaryTable = await summaryDb.SummaryTables.FirstOrDefaultAsync(x => x.SummaryId == id, cancellationToken);
				if (summaryTable == null)
					return NotFound();
				return new ObjectResult(summaryTable);
			}
			/// <summary>
			/// Method POST is used for add brand-new user to database without writing an user id
			/// </summary>
			/// <param name="SummaryTable">Input SummaryTable</param>
			/// <param name="cancellationToken">There is cancellation token</param>
			/// <returns><see cref="T:ReserveIO.Models.SummaryTable"/></returns>
			[HttpPost]
			public async Task<ActionResult<SummaryTable>> Post(SummaryTable summaryTable, CancellationToken cancellationToken)
			{
				if (summaryTable == null)
				{
					return BadRequest();
				}

				summaryDb.SummaryTables.Add(summaryTable);
				await summaryDb.SaveChangesAsync(cancellationToken);
				return Ok(summaryTable);
			}
			/// <summary>
			/// Method PUT is used for modify existing users in the database
			/// </summary>
			/// <param name="SummaryTable">Input SummaryTable</param>
			/// <param name="cancellationToken">There is cancellation token</param>
			/// <returns><see cref="T:ReserveIO.Models.SummaryTable"/> with given id from the database if succeded</returns>
			[HttpPut]
			public async Task<ActionResult<SummaryTable>> Put(SummaryTable summaryTable, CancellationToken cancellationToken)
			{
				if (summaryTable == null)
				{
					return BadRequest();
				}
				if (!summaryDb.SummaryTables.Any(x => x.SummaryId == summaryTable.SummaryId))
				{
					return NotFound();
				}

				summaryDb.Update(summaryTable);
				await summaryDb.SaveChangesAsync(cancellationToken);
				return Ok(summaryTable);
			}
			/// <summary>
			/// Method Delete is used for Deleting user that exist in database
			/// </summary>
			/// <param name="id">Id for user that we want to delete from the database</param>
			/// <param name="cancellationToken">There is cancellation token</param>
			/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
			[HttpDelete("{id}")]
			public async Task<ActionResult<SummaryTable>> Delete(int id, CancellationToken cancellationToken)
			{
				SummaryTable summaryTable = new SummaryTable { SummaryId = id };//создание объекта-заглушки
				var result = summaryDb.Remove(summaryTable);
				await summaryDb.SaveChangesAsync(cancellationToken);
				if (result != null)
				{
					return Ok();
				}
				else
					return NotFound();

			}
		}
}
