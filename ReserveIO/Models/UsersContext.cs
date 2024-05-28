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
/*
	public static class Extensions
	{
		public static List<PropertyInfo> GetDbSetProperties(this DbContext context)
		{
			var dbSetProperties = new List<PropertyInfo>();
			var properties = context.GetType().GetProperties();

			foreach (var property in properties)
			{
				var setType = property.PropertyType;

				*//*#if EF5 || EF6
							var isDbSet = setType.IsGenericType && (typeof (IDbSet<>).IsAssignableFrom(setType.GetGenericTypeDefinition()) || setType.GetInterface(typeof (IDbSet<>).FullName) != null);
				#elif EF7*//*
				var isDbSet = setType.IsGenericType && (typeof(DbSet<>).IsAssignableFrom(setType.GetGenericTypeDefinition()));
				//#endif

				if (isDbSet)
				{
					dbSetProperties.Add(property);
				}
			}


			

			return dbSetProperties;

		}
	}
	internal static class DbHelpers
	{
		public static object GetColumnById(this object dbContext, string tableName, string columnName, object id)
		{
			var table = (IQueryable)dbContext.GetType().GetProperty(tableName).GetValue(dbContext, null);
			var row = Expression.Parameter(table.ElementType, "row");
			var filter = Expression.Lambda(Expression.Equal(Expression.Property(row, "Id"), Expression.Constant(id)), row);
			var column = Expression.Property(row, columnName);
			var selector = Expression.Lambda(column, row);
			var query = Call(Where.MakeGenericMethod(row.Type), table, filter);
			query = Call(Select.MakeGenericMethod(row.Type, column.Type), query, selector);
			var value = Call(FirstOrDefault.MakeGenericMethod(column.Type), query);
			return value;
		}
		private static readonly MethodInfo Select = GetGenericMethodDefinition<
			Func<IQueryable<object>, Expression<Func<object, object>>, IQueryable<object>>>((source, selector) =>
			Queryable.Select(source, selector));
		private static readonly MethodInfo Where = GetGenericMethodDefinition<
			Func<IQueryable<object>, Expression<Func<object, bool>>, object>>((source, predicate) =>
			Queryable.Where(source, predicate));
		private static readonly MethodInfo FirstOrDefault = GetGenericMethodDefinition<
			Func<IQueryable<object>, object>>(source =>
			Queryable.FirstOrDefault(source));
		private static MethodInfo GetGenericMethodDefinition<TDelegate>(Expression<TDelegate> e)
		{
			return ((MethodCallExpression)e.Body).Method.GetGenericMethodDefinition();
		}
		private static object Call(MethodInfo method, params object[] parameters)
		{
			return method.Invoke(null, parameters);
		}
	}*/
}



