using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveIO.Models;

namespace ReserveIO.Configurations
{
	public class ServiceInfoConfiguration : IEntityTypeConfiguration<ServiceInfo>
	{

	public void Configure(EntityTypeBuilder<ServiceInfo> builder)
		{
/*			builder.HasData(
			new ServiceInfo[]
			{
						new () {Id = 1, ServiceId = 1, ReserveId = 1},
						new () {Id = 2, ServiceId = 2, ReserveId = 2},
						new () {Id = 3, ServiceId = 3, ReserveId = 3},
						//new () {Id = 4,ServiceId = 3, ReserveId = 4}
			});*/
			builder.HasKey(x => x.Id);
			builder.HasOne<Service>() 
			.WithMany()
			.HasForeignKey(x => x.ServiceId)
			.OnDelete(DeleteBehavior.ClientNoAction);
			builder.HasOne<SummaryTable>()
			.WithMany()
			.HasForeignKey(x => x.ReserveId);
		}
	}
}
