using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveIO.Models;

namespace ReserveIO.Configurations
{
	public class SummaryTableConfiguration : IEntityTypeConfiguration<SummaryTable>
	{
		public void Configure(EntityTypeBuilder<SummaryTable> builder)
		{
/*			builder.HasData(
				new SummaryTable[]
				{
					new() { SummaryId = 1, LesseeId = 2, RoomId = 2, Datetime = DateTime.Now, EndTime = DateTime.Parse("13.05.2024 16:30:00")},
					new() { SummaryId = 2, LesseeId = 2, RoomId = 1, Datetime = DateTime.Now, EndTime = DateTime.Parse("13.05.2024 16:40:00")},
					new() { SummaryId = 3, LesseeId = 3, RoomId = 3, Datetime = DateTime.Now, EndTime = DateTime.Parse("13.05.2024 16:50:00")},
				});*/
			builder.HasKey(x => x.SummaryId);

			builder.HasOne<User>()
			.WithMany()
			.HasForeignKey(x => x.LesseeId);
			builder.HasOne<Room>()
			.WithMany()
			.HasForeignKey(x => x.RoomId);
			builder.HasMany<ServiceInfo>()
			.WithOne();

		}
	}
}
