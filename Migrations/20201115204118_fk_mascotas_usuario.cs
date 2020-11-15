using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotasApi.Migrations
{
    public partial class fk_mascotas_usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_UsuariosId",
                table: "Mascotas",
                column: "idUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Usuarios_UsuariosId",
                table: "Mascotas",
                column: "idUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Usuarios_UsuariosId",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_UsuariosId",
                table: "Mascotas");

        }
    }
}
