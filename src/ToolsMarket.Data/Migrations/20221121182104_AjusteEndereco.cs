using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolsMarket.Data.Migrations
{
    public partial class AjusteEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUser_Enderecos_EnderecoId",
                table: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_EnderecoId",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "ApplicationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UsuarioId",
                table: "Enderecos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_ApplicationUser_UsuarioId",
                table: "Enderecos",
                column: "UsuarioId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_ApplicationUser_UsuarioId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_UsuarioId",
                table: "Enderecos");

            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "ApplicationUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_EnderecoId",
                table: "ApplicationUser",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUser_Enderecos_EnderecoId",
                table: "ApplicationUser",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }
    }
}
