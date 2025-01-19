using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "City", "Country", "Phone" },
                values: new object[] { 1, "Banani", "Dhaka", "Bangladesh", "+41023658" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "manager" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Company", "ContactId", "FirstName", "LastName", "RoleId", "Sex" },
                values: new object[] { 1, true, "SoftwarePeople", 1, "Shibli", "Arafat", 5, "M" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
