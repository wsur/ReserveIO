
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using System.ComponentModel.DataAnnotations;

namespace ReserveIO.Models
{
	//[EntityTypeConfiguration(typeof(UserConfiguration))]
	public class User
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Age { get; set; }
		
		public bool Delete { get; set; }//состояние удалён ли пользователь или нет
	}
}
