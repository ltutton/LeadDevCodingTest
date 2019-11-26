using Microsoft.EntityFrameworkCore.Migrations;

namespace UserList.Api.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "FamilyName", "FirstName" },
                values: new object[] { "FBloggs99", "Bloggs", "Fred" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "FamilyName", "FirstName" },
                values: new object[] { "BSmith", "Smith", "Bob" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "FamilyName", "FirstName" },
                values: new object[] { "Billy99", "Smith", "Billy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Billy99");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "BSmith");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "FBloggs99");
        }
    }
}
