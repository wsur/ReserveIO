
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReserveIO.Models;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Rewrite; // Пакет с middleware URL Rewriting

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
			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appSettings.json", false)
				.Build();
			builder.Services.AddSingleton<IConfiguration>(configuration);
			builder_config.SetBasePath(Directory.GetCurrentDirectory());
			builder_config.AddJsonFile("appsettings.json");//установка файла конфигурации
			var config = builder_config.Build();
			//string con = "Server=(localdb)\\mssqllocaldb;Database=usersdbstore;Trusted_Connection=True;";
			//var connectionStringMS = config.GetConnectionString("MSSqlDB");
			var connectionStringPG = configuration.GetConnectionString("PGDB");
			//var tokenLifeTime = configuration.GetConnectionString("TokeLifeTime");
			//-----------------------------------------------------------------------//

			//добавление сервиса аутентификации
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)  // схема аутентификации - с помощью jwt-токенов
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					// указывает, будет ли валидироваться издатель при валидации токена
					ValidateIssuer = true,
					// строка, представляющая издателя
					ValidIssuer = AuthOptions.ISSUER,
					// будет ли валидироваться потребитель токена
					ValidateAudience = true,
					// установка потребителя токена
					ValidAudience = AuthOptions.AUDIENCE,
					// будет ли валидироваться время существования
					ValidateLifetime = true,
					// установка ключа безопасности
					IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
					// валидация ключа безопасности
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
					Description = "WEB-API для приложения ReserveIO",
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
			//builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connectionString));//задаём контекст приложения
			builder.Services.AddDbContext<UsersContext>(options => options.UseNpgsql(connectionStringPG));//задаём контекст приложения

			var app = builder.Build();

			ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
			ILogger logger = loggerFactory.CreateLogger<Program>();


			//errorHandling
			app.Use(async (context, next) =>
			{
				await next.Invoke(context);
				Console.WriteLine("Path: " + context.Request.Path);
			});
			app.UseExceptionHandler("/error");//обработка ошибок приложения переадресует на /error
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
			// middleware, которое обрабатывает исключение
			app.Map("/error", app => app.Run(async context =>
			{
				logger.LogError($"Ошибка по маршруту: {context.Request.Path.ToString()}");
/*				// подключаем URL Rewriting
				//подменяем неккоректный адрес на стартовую страницу приложения
				var options = new RewriteOptions()
							.AddRedirect("(.*)/$", "$1")
							.AddRewrite(context.Request.Path, "/swagger/index.html", skipRemainingRules: false);*/
			})

			);

			app.Run();
		}
	}
	public class AuthOptions
	{
		public const string ISSUER = "MyAuthServer"; // издатель токена
		public const string AUDIENCE = "MyAuthClient"; // потребитель токена
		const string KEY = "mysupersecret_secretsecretsecretkey!123";   // ключ для шифрации
		public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
	}
}
