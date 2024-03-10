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
	}
}
