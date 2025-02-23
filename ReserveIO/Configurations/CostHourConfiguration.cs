using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveIO.Models;

namespace ReserveIO.Configurations
{
	/// <summary>
	/// Конфигурация для сущности CostHour
	/// </summary>
	public class CostHourConfiguration : IEntityTypeConfiguration<CostHour>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<CostHour> builder)
		{
			builder.HasKey(x => x.CostId);
/*			builder.HasData(
				new CostHour[]
				{
					new() { CostId = 1, CostRoomId = 1, TimeStampTZ = DateTime.Now, Cost = 2500 },
					new() { CostId = 2, CostRoomId = 1, TimeStampTZ = DateTime.Now, Cost = 2500 },
					new() { CostId = 3, CostRoomId = 2, TimeStampTZ = DateTime.Now, Cost = 2500 },
					new() { CostId = 4, CostRoomId = 3, TimeStampTZ = DateTime.Now, Cost = 2500 }
				});*/
			builder.HasOne<Room>()
			.WithMany()
			.HasForeignKey(x => x.CostRoomId);
		}
	}
}
