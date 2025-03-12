using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveIO.Models;
namespace ReserveIO.Configurations
{
	/// <summary>
	/// Конфигурация таблицы, связующей пользователей с ролями.
	/// </summary>
	public class UserRolesConfiguration : IEntityTypeConfiguration<UserRole>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
/*			builder.HasData(
				new UserRole[]
				{
					new() { UserId = 1, RoleId = 1 },
					new() { UserId = 2, RoleId = 1 },
					new() { UserId = 3, RoleId = 2 },
					//new() { UserId = 4, RoleId = 3 }
				});*/
			builder
			.HasKey(k => k.UserRoleId);
			builder
			.HasOne<Role>()
			.WithMany()
			.HasForeignKey(e => e.RoleId)
			.OnDelete(DeleteBehavior.ClientNoAction);
			builder
			.HasOne<User>()
			.WithMany()
			.HasForeignKey(e => e.UserId)
			.OnDelete(DeleteBehavior.ClientNoAction);
		}
	}
}
