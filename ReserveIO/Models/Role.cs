using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Exchange.WebServices.Data;

namespace ReserveIO.Models
{
	//[EntityTypeConfiguration(typeof(RoleConfiguration))]
	public class Role
	{
		public int RoleId { get; set; }

		public string RoleName { get; set; }
	}
}
