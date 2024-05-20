
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using System.ComponentModel.DataAnnotations;

namespace ReserveIO.Models
{
	//[EntityTypeConfiguration(typeof(UserConfiguration))]
	public class User
	{
		/// <summary>
		/// ID пользователя
		/// </summary>
		[Required(ErrorMessage ="В методе POST уберите строку Id или оставьте равной 0")]
		public int Id { get; set; }

		/// <summary>
		/// Имя пользователя
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Возраст
		/// </summary>
		public int Age { get; set; }
		
		/// <summary>
		/// Удалена ли учётная запись
		/// </summary>
		public bool Delete { get; set; }//состояние удалён ли пользователь или нет
	}
}
