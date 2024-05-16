﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ServiceInfoController : ControllerBase
	{
		readonly UsersContext ServiceInfoDb;
		public ServiceInfoController(UsersContext context)
		{
			ServiceInfoDb = context;
		}
		/// <summary>
		/// Methon get is used for getting all elements from database
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns>All <see cref="T:ReserveIO.Models.ServiceInfo"/> from the database</returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ServiceInfo>>> Get(CancellationToken cancellationToken)
		{
			return await ServiceInfoDb.ServiceInfos.ToListAsync(cancellationToken);//добавлен токен, который позволяет отменить запрос
		}

		/// <summary>
		/// Methon get is used for getting element with exact id
		/// </summary>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.ServiceInfo"/>with exact id from the database </returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<ServiceInfo>> Get(int id, CancellationToken cancellationToken)
		{
			ServiceInfo serviceInfo = await ServiceInfoDb.ServiceInfos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (serviceInfo == null)
				return NotFound();
			return new ObjectResult(serviceInfo);
		}
		/// <summary>
		/// Method POST is used for add brand-new user to database without writing an user id
		/// </summary>
		/// <param name="ServiceInfo">Input ServiceInfo</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.ServiceInfo"/></returns>
		[HttpPost]
		public async Task<ActionResult<ServiceInfo>> Post(ServiceInfo serviceInfo, CancellationToken cancellationToken)
		{
			if (serviceInfo == null)
			{
				return BadRequest();
			}

			ServiceInfoDb.ServiceInfos.Add(serviceInfo);
			await ServiceInfoDb.SaveChangesAsync(cancellationToken);
			return Ok(serviceInfo);
		}
		/// <summary>
		/// Method PUT is used for modify existing users in the database
		/// </summary>
		/// <param name="ServiceInfo">Input ServiceInfo</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="T:ReserveIO.Models.ServiceInfo"/> with given id from the database if succeded</returns>
		[HttpPut]
		public async Task<ActionResult<ServiceInfo>> Put(ServiceInfo serviceInfo, CancellationToken cancellationToken)
		{
			if (serviceInfo == null)
			{
				return BadRequest();
			}
			if (!ServiceInfoDb.ServiceInfos.Any(x => x.Id == serviceInfo.Id))
			{
				return NotFound();
			}

			ServiceInfoDb.Update(serviceInfo);
			await ServiceInfoDb.SaveChangesAsync(cancellationToken);
			return Ok(serviceInfo);
		}
		/// <summary>
		/// Method Delete is used for Deleting user that exist in database
		/// </summary>
		/// <param name="id">Id for user that we want to delete from the database</param>
		/// <param name="cancellationToken">There is cancellation token</param>
		/// <returns><see cref="M:ControllerBase.OK()"/> if operation is succeded</returns>
		[HttpDelete("{id}")]
		public async Task<ActionResult<ServiceInfo>> Delete(int id, CancellationToken cancellationToken)
		{
			ServiceInfo ServiceInfo = new ServiceInfo { Id = id };//создание объекта-заглушки
			var result = ServiceInfoDb.Remove(ServiceInfo);
			await ServiceInfoDb.SaveChangesAsync(cancellationToken);
			if (result != null)
			{
				return Ok();
			}
			else
				return NotFound();

		}
	}
}