using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
//using System.Reflection;

namespace ReserveIO.Models
{
	//Промежуточный класс для сопоставления модели с базой данных
	public class UsersContext : DbContext
	{
		//protected Assembly ConfigurationAssembly { get; }
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserRole>  UserRoles { get; set; }

		public UsersContext(DbContextOptions<UsersContext> options/*, Assembly assembly*/)
			: base(options)
		{
			//ConfigurationAssembly = assembly;
			//Database.EnsureDeleted();
			//Database.EnsureCreated(); //вызов этого метода при  использовании миграции вызовет ошибку
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(
				new User[]
				{
					new User { Id=1, Name="Tom", Age = 23},
					new User { Id = 2, Name = "Alice", Age = 26 },
					new User { Id = 3, Name = "Sam", Age = 28 },
					new User { Id = 4, Name = "Eugene", Age = 24 }
				});
			modelBuilder.Entity<Role>().HasData(
				new Role[]
				{
					new Role { Role_ID = 1, Role_Name="Lessee" },
					new Role { Role_ID = 2, Role_Name="Lessor" },
					new Role { Role_ID = 3, Role_Name = "App_Owner"}
				});
			modelBuilder.Entity<UserRole>().HasData(
				new UserRole[]
				{
					new UserRole { User_ID = 1, Role_ID = 1 },
					new UserRole { User_ID = 2, Role_ID = 1 },
					new UserRole { User_ID = 3, Role_ID = 2 },
					new UserRole { User_ID = 4, Role_ID = 3 }
				});
			base.OnModelCreating(modelBuilder);
			//modelBuilder.ApplyConfigurationsFromAssembly(ConfigurationAssembly);
		}
	}
}
