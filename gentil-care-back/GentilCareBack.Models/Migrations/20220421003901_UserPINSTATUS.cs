using Microsoft.EntityFrameworkCore.Migrations;

namespace GentilCareBack.Models.Migrations
{
    public partial class UserPINSTATUS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pin",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Users");
        }
    }
}
