
using Microsoft.EntityFrameworkCore;
using UserManagementApp.Server.Data.Repository;
using UserManagementApp.Server.Data;
using UserManagementApp.Server.Services;

namespace UserManagementApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", builder =>
                {
                    builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });

          


            builder.Services.AddDbContext<SQLContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var dataSource = builder.Configuration["DataSource"];
            if (dataSource == "SQL")
            {
                builder.Services.AddScoped<IDataProvider, SQLDataProvider>(); // Placeholder for SQL implementation
            }
            else if (dataSource == "JSON")
            {
                builder.Services.AddScoped<IDataProvider, JSONDataProvider>();
            }

            // Register repository and service layers
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();


            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAngularApp");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
