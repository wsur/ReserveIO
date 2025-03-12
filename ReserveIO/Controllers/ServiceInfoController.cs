using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ServiceInfoController : ControllerBase
	{
		readonly UsersContext usersContext;
		public ServiceInfoController(UsersContext context)
		{
			usersContext = context;
		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.ServiceInfo"/> from the database</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<ServiceInfo>>> Get(CancellationToken cancellationToken)
		{
			return await usersContext.ServiceInfos.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="id">Input ServiceInfo</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.ServiceInfo"/>with exact id from the database </returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpGet("[action]/{id}")]
		public async Task<ActionResult<ServiceInfo>> Get(int id, CancellationToken cancellationToken)
		{
			ServiceInfo? serviceInfo = await usersContext.ServiceInfos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (serviceInfo == null)
				return NotFound();
			return new ObjectResult(serviceInfo);
		}
		/// <summary>
		/// Method POST is used for add brand-new user to database without writing an user id
		/// </summary>
		/// <param name="serviceInfo">Input ServiceInfo</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.ServiceInfo"/></returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (Таких ID нет, проблема с ID сущностей, либо id записи не оставили равным 0)</response>
		[Authorize]
		[HttpPost("[action]")]
		public async Task<ActionResult<ServiceInfo>> Post(ServiceInfo serviceInfo, CancellationToken cancellationToken)
		{
			if (serviceInfo == null)
			{
				return BadRequest();
			}

			usersContext.ServiceInfos.Add(serviceInfo);
			await usersContext.SaveChangesAsync(cancellationToken);
			return Ok(serviceInfo);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="serviceId">Id сервиса в БД</param>
		/// <param name="reserveId">id заказа в БД</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.ServiceInfo"/> with given id from the database if succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpPut("[action]")]
		public async Task<ActionResult<ServiceInfo>> Put(int serviceId, int reserveId, int serviceIdNew, int reserveIdNew, CancellationToken cancellationToken)
		{
			Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ServiceInfo> result = null;
			ServiceInfo s1 = new (){ Id = 0 };//стандартная заглушка
														  //Необходимо сначала узнать id объекта -- получить его из бд.
			var userRoomMany = usersContext.ServiceInfos.Where(u =>
			EF.Functions.Like(u.ServiceId.ToString(), serviceId.ToString())
			);
			foreach (ServiceInfo s in userRoomMany)
			{
				if (s.ReserveId == reserveId)
				{
					//меняем параметры сущности
					s1.Id = s.Id;
					s1.ServiceId = serviceIdNew;
					s1.ReserveId = reserveIdNew;
					//т.к. ReserveId и ServiceId являются внешними ключами, то необходимо удалить сущность и создать новую.
					usersContext.Remove(s);//удаляем
					result = usersContext.Add(s1);
				}
			}
			if (s1 == null)
			{
				return NotFound("Такой сущности нет");
			}
			if (result != null)
			{
				//только в этом случае имеет смысл сохранять в бд данные.
				await usersContext.SaveChangesAsync(cancellationToken);
				return Ok(s1);
			}
			else
				return NotFound("Данные не обновились");
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="serviceId">ID сервиса</param>
		/// <param name="reserveId">ID заказа</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		/// <response code="200">Успешное выполнение</response>
		/// <response code="400">Ошибка API</response>
		/// <response code="500">Ошибка API (возможно, проблема c Id)</response>
		[Authorize]
		[HttpDelete("[action]")]
		public async Task<ActionResult<ServiceInfo>> Delete(int serviceId, int reserveId, CancellationToken cancellationToken)
		{
			//сначала нужно получить объект с нужным id
			//получаем все объекты с данным reserveId
			Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ServiceInfo>? result = null;
			ServiceInfo? s1 = null;
			var serviceInfoMany = usersContext.ServiceInfos.Where(u =>
			EF.Functions.Like(u.ReserveId.ToString(),reserveId.ToString())
			);
			foreach(ServiceInfo s in serviceInfoMany)
			{
				if(s.ServiceId == serviceId)
				{
					result = usersContext.Remove(s);
					s1 = s;
				}
			}
			await usersContext.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok(s1);
			}
			else
				return NotFound();

		}
	}
}
