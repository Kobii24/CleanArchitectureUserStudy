using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitectureStudy.Infrastructure.Migrations
{
    public partial class addAdminToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "passWord", "userEmail", "userName" },
                values: new object[] { 1, "123456", "admin@gmail.com", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: 1);
        }
    }
}
