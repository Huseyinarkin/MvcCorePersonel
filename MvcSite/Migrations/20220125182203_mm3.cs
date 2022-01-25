using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcSite.Migrations
{
    public partial class mm3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "ID", "Kullanici", "Sifre" },
                values: new object[] { 1, "a", "a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
