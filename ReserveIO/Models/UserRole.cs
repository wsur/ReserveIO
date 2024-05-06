using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ReserveIO.Models
{
	public class UserRole
	{
		[Key]
		[Required]
		public int User_ID { get; set; }

		[Required]
		public int Role_ID { get; set; }
	}
}
