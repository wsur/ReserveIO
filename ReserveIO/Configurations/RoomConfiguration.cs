using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Configurations
{
	/// <summary>
	/// Конфигурация для помещений
	/// </summary>
	public class RoomConfiguration : IEntityTypeConfiguration<Room>
	{
		/// <inheritdoc/>
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Room> builder)
		{
/*			builder.HasData(
				new Room[]
				{
					new() { RoomId = 1, RoomName = "Plank", OnOff = true, ServiceOn = true },
					new() { RoomId = 2, RoomName = "Newtone", OnOff = true, ServiceOn = true },
					new() { RoomId = 3, RoomName = "Einstein", OnOff = true, ServiceOn = true },
					new() { RoomId = 4, RoomName = "Gilbert", OnOff = true, ServiceOn = true }
				});*/
			builder.HasKey(x => x.RoomId);
			builder.HasMany<SummaryTable>()
			.WithOne();
			builder.HasMany<CostHour>()
			.WithOne();
			builder.HasMany<UserRoom>()
			.WithOne();
		}
	}
}
