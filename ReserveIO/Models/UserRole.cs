﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ReserveIO.Models
{
	public class UserRole
	{
		/// <summary>
		/// ID пользователя
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Id одной из ролей
		/// </summary>
		public int RoleId { get; set; }
	}
}
