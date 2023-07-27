using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTicket.DAL.Migrations
{
    public partial class db_rnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductReviews",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BlogReviews",
                newName: "Picture");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ProductReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NameSurname",
                table: "ProductReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "ProductReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlogID",
                table: "BlogReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BlogReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NameSurname",
                table: "BlogReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "NameSurname",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "BlogID",
                table: "BlogReviews");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BlogReviews");

            migrationBuilder.DropColumn(
                name: "NameSurname",
                table: "BlogReviews");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "ProductReviews",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "BlogReviews",
                newName: "Name");
        }
    }
}
