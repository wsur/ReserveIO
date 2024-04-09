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
			//Database.EnsureDeleted();//Странная вещь. Зачем это нужно, чтобы каждый раз новую создавать? В чём смысл?
			Database.EnsureCreated();
/*			if (!Users.Any())
			{
				Users.Add(new User { Name = "Tom", Age = 26 });
				Users.Add(new User { Name = "Alice", Age = 31 });
				SaveChanges();
			}*/

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
