using Microsoft.EntityFrameworkCore;
using UserManagementApp.Server.Models;

namespace UserManagementApp.Server.Data
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Role Data
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 5, Name = "manager" }
            );

            // Seed Contact Data
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    Phone = "+41023658",
                    Address = "Banani",
                    City = "Dhaka",
                    Country = "Bangladesh"
                }
            );

            // Seed User Data
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Shibli",
                    LastName = "Arafat",
                    Active = true,
                    Company = "SoftwarePeople",
                    Sex = "M",
                    ContactId = 1, // Reference to Contact
                    RoleId = 5     // Reference to Role
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
