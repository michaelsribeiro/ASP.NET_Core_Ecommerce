using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolsMarket.App.Migrations
{
    public partial class UsuarioEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoViewModel_AspNetUsers_UsuarioId1",
                table: "EnderecoViewModel");

            migrationBuilder.DropIndex(
                name: "IX_EnderecoViewModel_UsuarioId1",
                table: "EnderecoViewModel");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "EnderecoViewModel");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "EnderecoViewModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "EnderecoViewModel",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "EnderecoViewModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoViewModel_UsuarioId1",
                table: "EnderecoViewModel",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoViewModel_AspNetUsers_UsuarioId1",
                table: "EnderecoViewModel",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
