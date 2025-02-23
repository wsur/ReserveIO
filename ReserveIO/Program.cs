
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;
using Microsoft.Extensions.Configuration;

namespace ReserveIO
{
	/// <summary>
	/// �������� ����� ���������
	/// </summary>
	public class Program
	{
		/// <summary>
		/// �����, � �������� ���������� ���������� ���������
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//----------���������� ������������ appsettings.json----------------------//
			var builder_config = new ConfigurationBuilder();
			builder_config.SetBasePath(Directory.GetCurrentDirectory());
			builder_config.AddJsonFile("appsettings.json");//��������� ����� ������������
			var config = builder_config.Build();
			//string con = "Server=(localdb)\\mssqllocaldb;Database=usersdbstore;Trusted_Connection=True;";
			var connectionString = config.GetConnectionString("MSSqlDB");
			//-----------------------------------------------------------------------//


			// Add services to the container.
			builder.Services.AddControllers();//���������� ����������� ��� �������������
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connectionString));//����� �������� ����������

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
