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

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add CORS policy to allow the Angular app
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", builder =>
                {
                    builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });

            // Default to appsettings.json value for DataSource
            string defaultDataSource = builder.Configuration["DataSource"] ?? "SQL";

            // Add a singleton to hold the selected data source
            builder.Services.AddSingleton<DataSourceProvider>(new DataSourceProvider(defaultDataSource));

            // Register services based on DataSourceProvider
            builder.Services.AddScoped<IDataProvider>(serviceProvider =>
            {
                var dataSourceProvider = serviceProvider.GetRequiredService<DataSourceProvider>();
                return dataSourceProvider.DataSource switch
                {
                    "SQL" => new SQLDataProvider(serviceProvider.GetRequiredService<SQLContext>()),
                    "JSON" => new JSONDataProvider(),
                    _ => throw new Exception("Invalid data source")
                };
            });

            // Add DbContext
            builder.Services.AddDbContext<SQLContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register repository and service layers
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAngularApp");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }

    // DataSourceProvider to manage the selected data source
    public class DataSourceProvider
    {
        public string DataSource { get; private set; }

        public DataSourceProvider(string defaultDataSource)
        {
            DataSource = defaultDataSource;
        }

        public void SetDataSource(string dataSource)
        {
            DataSource = dataSource;
        }
    }
}
