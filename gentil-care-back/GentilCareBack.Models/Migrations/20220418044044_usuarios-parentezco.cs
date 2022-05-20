using Microsoft.EntityFrameworkCore.Migrations;

namespace GentilCareBack.Models.Migrations
{
    public partial class usuariosparentezco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "parentezco",
                table: "Users",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "parentezco",
                table: "Users");
        }
    }
}
