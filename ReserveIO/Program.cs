
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

			//----------ѕеременные конфигурации appsettings.json----------------------//
			var builder_config = new ConfigurationBuilder();
			builder_config.SetBasePath(Directory.GetCurrentDirectory());
			builder_config.AddJsonFile("appsettings.json");//установка файла конфигурации
			var config = builder_config.Build();
			//string con = "Server=(localdb)\\mssqllocaldb;Database=usersdbstore;Trusted_Connection=True;";
			//var connectionStringMS = config.GetConnectionString("MSSqlDB");
			var connectionStringPG = config.GetConnectionString("PGDB");
			//-----------------------------------------------------------------------//

			//добавление сервиса аутентификации
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)  // схема аутентификации - с помощью jwt-токенов
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					// указывает, будет ли валидироватьс€ издатель при валидации токена
					ValidateIssuer = true,
					// строка, представл€юща€ издател€
					ValidIssuer = AuthOptions.ISSUER,
					// будет ли валидироватьс€ потребитель токена
					ValidateAudience = true,
					// установка потребител€ токена
					ValidAudience = AuthOptions.AUDIENCE,
					// будет ли валидироватьс€ врем€ существовани€
					ValidateLifetime = true,
					// установка ключа безопасности
					IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
					// валидаци€ ключа безопасности
					ValidateIssuerSigningKey = true,
				};
			});      // подключение аутентификации с помощью jwt (JSON web token)
			builder.Services.AddAuthorization();
						  // Add services to the container.
			builder.Services.AddControllers();//используем контроллеры без представлений
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Reserve IO API",
					Description = "WEB-API дл€ приложени€ ReserveIO",
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
			//builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connectionString));//задаЄм контекст приложени€
			builder.Services.AddDbContext<UsersContext>(options => options.UseNpgsql(connectionStringPG));//задаЄм контекст приложени€

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
		public const string ISSUER = "MyAuthServer"; // издатель токена
		public const string AUDIENCE = "MyAuthClient"; // потребитель токена
		const string KEY = "mysupersecret_secretsecretsecretkey!123";   // ключ дл€ шифрации
		public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
	}
}
