using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTicket.DAL.Migrations
{
    public partial class db_vvk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Siparisler");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Siparisler");

            migrationBuilder.RenameColumn(
                name: "ProductTotal",
                table: "Siparisler",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "ProductSize",
                table: "Siparisler",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "ProductQuantity",
                table: "Siparisler",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "Siparisler",
                newName: "Adres");

            migrationBuilder.RenameColumn(
                name: "ProductPicture",
                table: "Siparisler",
                newName: "Phone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Siparisler",
                newName: "ProductSize");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Siparisler",
                newName: "ProductPicture");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Siparisler",
                newName: "ProductQuantity");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Siparisler",
                newName: "ProductTotal");

            migrationBuilder.RenameColumn(
                name: "Adres",
                table: "Siparisler",
                newName: "ProductPrice");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Siparisler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
