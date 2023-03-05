using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactBook.Server.Migrations
{
    public partial class UpdateContactTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNo1",
                table: "Contacts",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo2",
                table: "Contacts",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNo1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PhoneNo2",
                table: "Contacts");
        }
    }
}
