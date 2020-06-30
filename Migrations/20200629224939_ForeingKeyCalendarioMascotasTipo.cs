using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotasApi.Migrations
{
    public partial class ForeingKeyCalendarioMascotasTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Calendario_MascotasTipoId",
                table: "Calendario");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_MascotasTipoId",
                table: "Calendario",
                column: "MascotasTipoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Calendario_MascotasTipoId",
                table: "Calendario");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_MascotasTipoId",
                table: "Calendario",
                column: "MascotasTipoId");
        }
    }
}
