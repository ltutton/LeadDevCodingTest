using Microsoft.EntityFrameworkCore.Migrations;

namespace UserList.Api.Migrations
{
    public partial class Seed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "FamilyName", "FirstName" },
                values: new object[] { "Prince", "Prince", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Prince");
        }
    }
}
