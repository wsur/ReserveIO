using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using System.Reflection;
using System.Reflection;

namespace ReserveIO.Models
{
	//Промежуточный класс для сопоставления модели с базой данных
	public class UsersContext : DbContext
	{
		//protected abstract Assembly ConfigurationAssembly { get; }
		public DbSet<User> Users { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<UserRole> UserRoles { get; set; }


		public UsersContext(DbContextOptions<UsersContext> options)
			: base(options)
		{
			//Database.EnsureDeleted();
			//Database.EnsureCreated(); //вызов этого метода при  использовании миграции вызовет ошибку
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
	}
}
