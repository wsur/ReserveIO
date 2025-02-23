using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveIO.Models;

namespace ReserveIO.Configurations
{
	/// <summary>
	/// Конфигурация для логинов и паролей пользователей
	/// </summary>
	public class UserLogPassConfiguration : IEntityTypeConfiguration<UserLogPass>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<UserLogPass> builder)
		{
/*			builder.HasData(
			new UserLogPass[]
			{
				new() { UserId = 1, Login = "Tom1", Password = "123" },
				new() { UserId = 2, Login = "Alice1", Password = "123" },
				new() { UserId = 3, Login = "Sam1", Password = "123" },
				new() { UserId = 4, Login = "Eugene1", Password = "123" }
			});*/
			builder.HasKey(x => x.UserId);
			builder
			.HasOne<User>()
			.WithOne()
			.HasForeignKey<UserLogPass>(x => x.UserId)
			.IsRequired()
			.OnDelete(DeleteBehavior.ClientNoAction);
		}
	}
}
