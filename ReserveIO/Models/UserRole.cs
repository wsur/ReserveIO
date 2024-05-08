using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace ReserveIO.Models
{
	public class UserRole
	{
		public int UserId { get; set; }

		public int RoleId { get; set; }
	}
}
