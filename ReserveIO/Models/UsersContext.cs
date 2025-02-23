using Microsoft.EntityFrameworkCore;

namespace ReserveIO.Models
{
	/// <summary>
	/// Контекст данных пользователей
	/// </summary>
	public class UsersContext : DbContext
	{
		/// <summary>
		/// Пользователи
		/// </summary>
		public DbSet<User> Users { get; set; }
		/// <summary>
		/// Конструктор контекста данных пользователей
		/// </summary>
		/// <param name="options"></param>
		public UsersContext(DbContextOptions<UsersContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
		/// <summary>
		/// Настройки при создании контекста данных
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().HasData(
				[
					new() { Id=1, Name="Tom", Age = 23},
					new() { Id = 2, Name = "Alice", Age = 26 },
					new() { Id = 3, Name = "Sam", Age = 28 }
				]);
			base.OnModelCreating(modelBuilder);
		}
	}
}
