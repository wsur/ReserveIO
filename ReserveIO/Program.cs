
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ReserveIO.Models;

namespace ReserveIO
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//----------���������� ������������ appsettings.json----------------------//
			var builder_config = new ConfigurationBuilder();
			builder_config.SetBasePath(Directory.GetCurrentDirectory());
			builder_config.AddJsonFile("appsettings.json");//��������� ����� ������������
			var config = builder_config.Build();
			//string con = "Server=(localdb)\\mssqllocaldb;Database=usersdbstore;Trusted_Connection=True;";
			//var connectionStringMS = config.GetConnectionString("MSSqlDB");
			var connectionStringPG = config.GetConnectionString("PGDB");
			//-----------------------------------------------------------------------//


			// Add services to the container.
			builder.Services.AddControllers();//���������� ����������� ��� �������������
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Reserve IO API",
					Description = "WEB-API ��� ���������� ReserveIO",
				}
				);
				var basePath = AppContext.BaseDirectory;

				var xmlPath = Path.Combine(basePath, "ReserveIO.xml");
				options.IncludeXmlComments(xmlPath);
			});
			//builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connectionString));//����� �������� ����������
			builder.Services.AddDbContext<UsersContext>(options => options.UseNpgsql(connectionStringPG));//����� �������� ����������

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
				});
			}
			app.UseDeveloperExceptionPage();

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
