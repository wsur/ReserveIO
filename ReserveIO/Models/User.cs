
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using System.ComponentModel.DataAnnotations;

namespace ReserveIO.Models
{
	//[EntityTypeConfiguration(typeof(UserConfiguration))]
	public class User
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public int Age { get; set; }
	}
}
