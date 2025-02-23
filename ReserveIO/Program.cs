
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;
using Microsoft.Extensions.Configuration;

namespace ReserveIO
{
	/// <summary>
	/// Основной класс программы
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Метод, с которого начинается выполнение программы
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//----------Переменные конфигурации appsettings.json----------------------//
			var builder_config = new ConfigurationBuilder();
			builder_config.SetBasePath(Directory.GetCurrentDirectory());
			builder_config.AddJsonFile("appsettings.json");//установка файла конфигурации
			var config = builder_config.Build();
			//string con = "Server=(localdb)\\mssqllocaldb;Database=usersdbstore;Trusted_Connection=True;";
			var connectionString = config.GetConnectionString("MSSqlDB");
			//-----------------------------------------------------------------------//


			// Add services to the container.
			builder.Services.AddControllers();//используем контроллеры без представлений
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connectionString));//задаём контекст приложению

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseDeveloperExceptionPage();

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
