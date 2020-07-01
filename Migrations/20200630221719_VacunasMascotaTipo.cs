using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotasApi.Migrations
{
    public partial class VacunasMascotaTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MascotaTipoId",
                table: "Vacunas",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Vacunas_MascotaTipoId",
                table: "Vacunas",
                column: "MascotaTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacunas_MascotasTipo_MascotaTipoId",
                table: "Vacunas",
                column: "MascotaTipoId",
                principalTable: "MascotasTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacunas_MascotasTipo_MascotaTipoId",
                table: "Vacunas");

            migrationBuilder.DropIndex(
                name: "IX_Vacunas_MascotaTipoId",
                table: "Vacunas");

            migrationBuilder.DropColumn(
                name: "MascotaTipoId",
                table: "Vacunas");
        }
    }
}
