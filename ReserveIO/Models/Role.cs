using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Exchange.WebServices.Data;

namespace ReserveIO.Models
{
	//[EntityTypeConfiguration(typeof(RoleConfiguration))]
	public class Role
	{
		[Key]
		public int Role_ID { get; set; }
		[Required]
		public string Role_Name { get; set; }
	}
}
