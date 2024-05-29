
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReserveIO.Models;
using System.Text;

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

			//���������� ������� ��������������
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)  // ����� �������������� - � ������� jwt-�������
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					// ���������, ����� �� �������������� �������� ��� ��������� ������
					ValidateIssuer = true,
					// ������, �������������� ��������
					ValidIssuer = AuthOptions.ISSUER,
					// ����� �� �������������� ����������� ������
					ValidateAudience = true,
					// ��������� ����������� ������
					ValidAudience = AuthOptions.AUDIENCE,
					// ����� �� �������������� ����� �������������
					ValidateLifetime = true,
					// ��������� ����� ������������
					IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
					// ��������� ����� ������������
					ValidateIssuerSigningKey = true,
				};
			});      // ����������� �������������� � ������� jwt (JSON web token)
			builder.Services.AddAuthorization();
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

				OpenApiSecurityScheme openApiSecurityScheme = new OpenApiSecurityScheme
				{
					Description = "JWT Authorization using the Bearer scheme. Put only JWT token in the field below.",
					Name = "JWT Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "Bearer",
					Reference = new OpenApiReference
					{
						Id = "Bearer",
						Type = ReferenceType.SecurityScheme
					}
				};
				options.AddSecurityDefinition(openApiSecurityScheme.Reference.Id, openApiSecurityScheme);
				options.AddSecurityRequirement(new OpenApiSecurityRequirement {
				{
					openApiSecurityScheme,
					Array.Empty<string>()
				} });
			});
			//builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connectionString));//����� �������� ����������
			builder.Services.AddDbContext<UsersContext>(options => options.UseNpgsql(connectionStringPG));//����� �������� ����������

			var app = builder.Build();

			app.UseAuthentication();
			app.UseAuthorization();
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

			app.MapControllers();

			app.Run();
		}
	}
	public class AuthOptions
	{
		public const string ISSUER = "MyAuthServer"; // �������� ������
		public const string AUDIENCE = "MyAuthClient"; // ����������� ������
		const string KEY = "mysupersecret_secretsecretsecretkey!123";   // ���� ��� ��������
		public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
	}
}
