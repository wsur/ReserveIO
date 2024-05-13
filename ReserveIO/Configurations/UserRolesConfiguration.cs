using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveIO.Models;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using ReserveIO.Models;
namespace ReserveIO.Configurations
{
	public class UserRolesConfiguration : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			builder.HasData(
				new UserRole[]
				{
					new() { UserId = 1, RoleId = 1 },
					new() { UserId = 2, RoleId = 1 },
					new() { UserId = 3, RoleId = 2 },
					//new() { UserId = 4, RoleId = 3 }
				});
			builder
			.HasKey(k => new { k.UserId, k.RoleId });
			builder
			.HasOne<Role>()
			.WithMany()
			.HasForeignKey(e => e.RoleId);
			builder
			.HasOne<User>()
			.WithMany()
			.HasForeignKey(e => e.UserId);
		}
	}
}
