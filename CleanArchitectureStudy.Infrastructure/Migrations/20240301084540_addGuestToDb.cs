using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitectureStudy.Infrastructure.Migrations
{
    public partial class addGuestToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "passWord", "userEmail", "userName" },
                values: new object[] { 101, "12345678", "guest1@gmail.com", "guest1" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "passWord", "userEmail", "userName" },
                values: new object[] { 102, "12345678", "guest2@gmail.com", "guest2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: 102);
        }
    }
}
