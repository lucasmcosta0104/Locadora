using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Migrations
{
    /// <inheritdoc />
    public partial class Cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_LocadoraModelo_LocadoraModeloId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IdLocadora",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "LocadoraModeloId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_LocadoraModelo_LocadoraModeloId",
                table: "Cliente",
                column: "LocadoraModeloId",
                principalTable: "LocadoraModelo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_LocadoraModelo_LocadoraModeloId",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "LocadoraModeloId",
                table: "Cliente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdLocadora",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_LocadoraModelo_LocadoraModeloId",
                table: "Cliente",
                column: "LocadoraModeloId",
                principalTable: "LocadoraModelo",
                principalColumn: "Id");
        }
    }
}
