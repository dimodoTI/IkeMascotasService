using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotasApi.Migrations
{
    public partial class CambioTablaMascotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idMascotaTipo",
                table: "Mascotas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idMascotaTipo",
                table: "Mascotas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
