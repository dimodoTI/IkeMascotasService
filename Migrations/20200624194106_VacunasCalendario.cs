using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotasApi.Migrations
{
    public partial class VacunasCalendario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotasTipoId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Enfermedades = table.Column<string>(nullable: true),
                    Optativa = table.Column<bool>(nullable: false),
                    Cachorro = table.Column<bool>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendario_MascotasTipo_MascotasTipoId",
                        column: x => x.MascotasTipoId,
                        principalTable: "MascotasTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacunas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MascotasVacunas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaId = table.Column<int>(nullable: false),
                    VacunaId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Realizada = table.Column<bool>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MascotasVacunas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MascotasVacunas_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MascotasVacunas_Vacunas_VacunaId",
                        column: x => x.VacunaId,
                        principalTable: "Vacunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_MascotasTipoId",
                table: "Calendario",
                column: "MascotasTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_MascotasVacunas_MascotaId",
                table: "MascotasVacunas",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_MascotasVacunas_VacunaId",
                table: "MascotasVacunas",
                column: "VacunaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendario");

            migrationBuilder.DropTable(
                name: "MascotasVacunas");

            migrationBuilder.DropTable(
                name: "Vacunas");
        }
    }
}
