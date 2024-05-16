using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Configurations
{
	public class ServiceConfiguration : IEntityTypeConfiguration<Service>
	{
		public void Configure(EntityTypeBuilder<Service> builder)
		{
			//на 1 сервис приходится 1 владелец. Если менять так, что на каждый сервис может быть несколько владельцев и наоборот, то лучше это делать через промежуточную таблицу
			builder.HasData(
				new Service[]
				{
					new() { ServiceId = 1, UserId=2, ServiceName="аренда офисного помещения 30 кв под митапы", ServiceCost = 3000 },
					new() { ServiceId = 2, UserId=2, ServiceName="Аренда магазинной площади под городское мероприятие 400 кв", ServiceCost=10000 },
					new() { ServiceId = 3, UserId =3, ServiceName = "тест моего помещения", ServiceCost=10000}
				});
			builder.HasKey(x => x.ServiceId);
			builder.HasOne<User>()
			.WithMany()
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.ClientNoAction);
			builder.HasMany<ServiceInfo>()
			.WithOne()
			.OnDelete(DeleteBehavior.ClientNoAction);

		}
	}
}
