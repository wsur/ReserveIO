using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveIO.Models;

namespace ReserveIO.Configurations
{
	public class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasData(
				new Role[]
				{
					new() { RoleId = 1, RoleName="Lessee" },
					new() { RoleId = 2, RoleName="Lessor" },
					new() { RoleId = 3, RoleName = "App_Owner"}
				});
		}
	}
}
