using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveIO.Models;

namespace ReserveIO.Configurations
{
	public class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasKey(x => x.RoleId);
			builder.HasData(
				new Role[]
				{
					new() { RoleId = 1, RoleName="Lessee", Delete = false },
					new() { RoleId = 2, RoleName="Lessor", Delete = false },
					new() { RoleId = 3, RoleName = "App_Owner",  Delete = false}
				});
			builder.HasMany<UserRole>()
			.WithOne()
			.OnDelete(DeleteBehavior.ClientNoAction);

		}
	}
}
