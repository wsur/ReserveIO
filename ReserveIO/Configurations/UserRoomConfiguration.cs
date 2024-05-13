using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveIO.Models;

namespace ReserveIO.Configurations
{
	public class UserRoomConfiguration : IEntityTypeConfiguration<UserRoom>
	{
		public void Configure(EntityTypeBuilder<UserRoom> builder)
		{
			builder.HasData(
				new UserRoom[]
				{
					new() { UserId = 1, RoomId = 1 },
					new() { UserId = 2, RoomId = 1 },
					new() { UserId = 3, RoomId = 2 },
					new() { UserId = 4, RoomId = 3 }
				});
			builder.HasKey(x => new { x.UserId, x.RoomId});
			builder.HasOne<User>()
			.WithMany()
			.HasForeignKey(x => x.UserId);
			builder.HasOne<Room>()
			.WithMany()
			.HasForeignKey(x => x.RoomId);
		}
	}
}
