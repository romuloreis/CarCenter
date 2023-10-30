using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCenter.Migrations
{
    public partial class tentativa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Cliente_CompradorId",
                table: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_Nota_CompradorId",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "CompradorId",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "IdCarro",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Nota");

            migrationBuilder.RenameColumn(
                name: "IdVendedor",
                table: "Nota",
                newName: "ClienteId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEmissao",
                table: "Nota",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_ClienteId",
                table: "Nota",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Cliente_ClienteId",
                table: "Nota",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Cliente_ClienteId",
                table: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_Nota_ClienteId",
                table: "Nota");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Nota",
                newName: "IdVendedor");

            migrationBuilder.AlterColumn<string>(
                name: "DataEmissao",
                table: "Nota",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CompradorId",
                table: "Nota",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCarro",
                table: "Nota",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Nota",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nota_CompradorId",
                table: "Nota",
                column: "CompradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Cliente_CompradorId",
                table: "Nota",
                column: "CompradorId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
