using Microsoft.EntityFrameworkCore;

namespace ReserveIO.Models
{
	//Промежуточный класс для сопоставления модели с базой данных
	public class UsersContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public UsersContext(DbContextOptions<UsersContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(
				new User[]
				{
					new User { Id=1, Name="Tom", Age = 23},
					new User { Id = 2, Name = "Alice", Age = 26 },
					new User { Id = 3, Name = "Sam", Age = 28 }
				});
			base.OnModelCreating(modelBuilder);
		}
	}
}
