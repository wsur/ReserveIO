using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveIO.Models;
using System.Reflection.Emit;

namespace ReserveIO.Configurations
{
	/// <summary>
	/// Конфигурация для пользователей
	/// </summary>
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.UserId);
/*			builder.HasData(
				new User[]
				{
					new() { Id = 1, Name="Tom", Age = 23, Delete = false},
					new() { Id = 2, Name = "Alice", Age = 26, Delete = false },
					new() { Id = 3, Name = "Sam", Age = 28, Delete = false },
					new() { Id = 4, Name = "Eugene", Age = 24, Delete = false }
				});*/
			builder.HasOne<UserLogPass>()
			.WithOne()
			.HasForeignKey<UserLogPass>(x=>x.UserId)
			.OnDelete(DeleteBehavior.ClientNoAction);
			builder.HasMany<UserRole>()
			.WithOne()
			.OnDelete(DeleteBehavior.ClientNoAction);
/*			builder.HasMany<Service>()
			.WithOne()
			.OnDelete(DeleteBehavior.ClientNoAction);//стандартное поведение*/
			builder.HasMany<SummaryTable>()
			.WithOne()
			.OnDelete(DeleteBehavior.ClientNoAction);//нельзя удалять инфу о заказах
			builder.HasMany<UserRoom>()
			.WithOne();
		}
	}
}
