using Microsoft.EntityFrameworkCore;

namespace ReserveIO.Models
{
	public class RolesContext : DbContext
	{
		public DbSet<Role> Roles { get; set; }

		public RolesContext(DbContextOptions<RolesContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Role>().HasData(
				new Role[]
				{
					new Role { Role_ID = 1, Role_Name="Lessee", },
					new Role { Role_ID = 2, Role_Name="Lessor", },
					new Role { Role_ID = 3, Role_Name = "App_Owner"}
				});
			base.OnModelCreating(modelBuilder);
		}
	}
}
