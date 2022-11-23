using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolsMarket.Data.Migrations
{
    public partial class CadastroClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_ApplicationUser_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Pedidos",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Enderecos",
                newName: "ClienteId");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Enderecos",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Pedidos",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Enderecos",
                newName: "UsuarioId");

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_EnderecoId",
                table: "ApplicationUser",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_ApplicationUser_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");
        }
    }
}
