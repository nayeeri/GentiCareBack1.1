using Microsoft.EntityFrameworkCore.Migrations;

namespace GentilCareBack.Models.Migrations
{
    public partial class TableServiciosOpcionales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Farmacos_FarmacosId",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Signosvitales_SignosvitalesId",
                table: "Servicios");

            migrationBuilder.AlterColumn<long>(
                name: "SignosvitalesId",
                table: "Servicios",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "FarmacosId",
                table: "Servicios",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Farmacos_FarmacosId",
                table: "Servicios",
                column: "FarmacosId",
                principalTable: "Farmacos",
                principalColumn: "FarmacosId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Signosvitales_SignosvitalesId",
                table: "Servicios",
                column: "SignosvitalesId",
                principalTable: "Signosvitales",
                principalColumn: "SignosvitalesId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Farmacos_FarmacosId",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Signosvitales_SignosvitalesId",
                table: "Servicios");

            migrationBuilder.AlterColumn<long>(
                name: "SignosvitalesId",
                table: "Servicios",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FarmacosId",
                table: "Servicios",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Farmacos_FarmacosId",
                table: "Servicios",
                column: "FarmacosId",
                principalTable: "Farmacos",
                principalColumn: "FarmacosId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Signosvitales_SignosvitalesId",
                table: "Servicios",
                column: "SignosvitalesId",
                principalTable: "Signosvitales",
                principalColumn: "SignosvitalesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
