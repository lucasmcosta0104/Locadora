using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Migrations
{
    /// <inheritdoc />
    public partial class AjustesFinais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_LocadoraModelo_LocadoraModeloId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "LocadoraModeloId",
                table: "Usuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_LocadoraModelo_LocadoraModeloId",
                table: "Usuario",
                column: "LocadoraModeloId",
                principalTable: "LocadoraModelo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_LocadoraModelo_LocadoraModeloId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "LocadoraModeloId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_LocadoraModelo_LocadoraModeloId",
                table: "Usuario",
                column: "LocadoraModeloId",
                principalTable: "LocadoraModelo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
