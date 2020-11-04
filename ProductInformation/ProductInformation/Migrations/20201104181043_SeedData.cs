using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductInformation.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "ID", "CategoryID", "Name" },
                values: new object[] { -4, -3, "Staff of Light" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "ID",
                keyValue: -4);
        }
    }
}
