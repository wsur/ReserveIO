using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveIO.Models;
using System.Reflection.Emit;

namespace ReserveIO.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasData(
				new User[]
				{
					new() { Id=1, Name="Tom", Age = 23},
					new() { Id = 2, Name = "Alice", Age = 26 },
					new() { Id = 3, Name = "Sam", Age = 28 },
					new() { Id = 4, Name = "Eugene", Age = 24 }
				});
		}
	}
}
