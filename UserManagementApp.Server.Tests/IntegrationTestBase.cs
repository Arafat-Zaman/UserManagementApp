using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserManagementApp.Server;
using UserManagementApp.Server.Data;

public class IntegrationTestBase
{
    protected readonly WebApplicationFactory<Program> Factory;

    public IntegrationTestBase()
    {
        Factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Testing"); // Set environment to Testing
                builder.ConfigureServices(services =>
                {
                    // Remove the default SQL Server registration
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<SQLContext>));
                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    // Register the InMemoryDatabase for testing
                    services.AddDbContext<SQLContext>(options =>
                        options.UseInMemoryDatabase("TestDb"));
                });
            });
    }
}
