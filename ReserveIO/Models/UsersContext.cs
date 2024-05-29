using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;

namespace ReserveIO.Models
{
	//Промежуточный класс для сопоставления модели с базой данных
	public class UsersContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<UserRole> UserRoles { get; set; }

		public DbSet<Service> Services { get; set; }

		public DbSet<SummaryTable> SummaryTables { get; set; }

		public DbSet<Room> Rooms { get; set; }

		public DbSet<UserLogPass> UserLogPasses { get; set; }

		public DbSet<ServiceInfo> ServiceInfos { get; set; }

		public DbSet<UserRoom> UserRooms { get; set; }

		public DbSet<CostHour> CostHours { get; set; }

		public UsersContext(DbContextOptions<UsersContext> options)
			: base(options)
		{
			//Database.EnsureDeleted();
			//Database.EnsureCreated(); //вызов этого метода при использовании миграции вызовет ошибку

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}

		public IEnumerable<IEnumerable<object>> GetCollection()
		{
			//внимательно смотрите на порядок сущностей
			IEnumerable<IEnumerable<object>> db = new List<IEnumerable<object>>()
			{
				CostHours.ToList(),
				UserRooms.ToList(),
				ServiceInfos.ToList(),
				UserLogPasses.ToList(),
				Rooms.ToList(),
				SummaryTables.ToList(),
				Services.ToList(),
				UserRoles.ToList(),
				Roles.ToList(),
				Users.ToList()
			};
			return db;
		}

		public List<string> GetTableNamesCollection()
		{
			//внимательно смотрите на порядок сущностей
			List<string> tableNames = new List<string>()
			{
				CostHours.EntityType.GetTableName(),
				UserRooms.EntityType.GetTableName(),
				ServiceInfos.EntityType.GetTableName(),
				UserLogPasses.EntityType.GetTableName(),
				Rooms.EntityType.GetTableName(),
				SummaryTables.EntityType.GetTableName(),
				Services.EntityType.GetTableName(),
				UserRoles.EntityType.GetTableName(),
				Roles.EntityType.GetTableName(),
				Users.EntityType.GetTableName()
			};
			return tableNames;
		}
		public List<IEnumerable<IProperty>> GetTablePropertyNamesCollection()
		{
			//внимательно смотрите на порядок сущностей
			List<IEnumerable<IProperty>> tableNames = new List<IEnumerable<IProperty>>()
			{
				CostHours.EntityType.GetProperties(),
				UserRooms.EntityType.GetProperties(),
				ServiceInfos.EntityType.GetProperties(),
				UserLogPasses.EntityType.GetProperties(),
				Rooms.EntityType.GetProperties(),
				SummaryTables.EntityType.GetProperties(),
				Services.EntityType.GetProperties(),
				UserRoles.EntityType.GetProperties(),
				Roles.EntityType.GetProperties(),
				Users.EntityType.GetProperties()
			};
			return tableNames;
		}
	}
}



