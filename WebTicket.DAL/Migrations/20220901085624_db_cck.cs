using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTicket.DAL.Migrations
{
    public partial class db_cck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductColor",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductSize",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductColor",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ProductSize",
                table: "Carts");
        }
    }
}
