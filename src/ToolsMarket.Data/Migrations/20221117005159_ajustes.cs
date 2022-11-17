using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolsMarket.Data.Migrations
{
    public partial class ajustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Carrinhos_CarrinhoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CarrinhoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Carrinhos_PedidoId",
                table: "Carrinhos");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Carrinhos");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Pedidos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "Carrinhos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_PedidoId",
                table: "Carrinhos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_ProdutoId",
                table: "Carrinhos",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinhos_Produtos_ProdutoId",
                table: "Carrinhos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinhos_Produtos_ProdutoId",
                table: "Carrinhos");

            migrationBuilder.DropIndex(
                name: "IX_Carrinhos_PedidoId",
                table: "Carrinhos");

            migrationBuilder.DropIndex(
                name: "IX_Carrinhos_ProdutoId",
                table: "Carrinhos");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Carrinhos");

            migrationBuilder.AddColumn<Guid>(
                name: "CarrinhoId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Carrinhos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CarrinhoId",
                table: "Produtos",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_PedidoId",
                table: "Carrinhos",
                column: "PedidoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Carrinhos_CarrinhoId",
                table: "Produtos",
                column: "CarrinhoId",
                principalTable: "Carrinhos",
                principalColumn: "Id");
        }
    }
}
