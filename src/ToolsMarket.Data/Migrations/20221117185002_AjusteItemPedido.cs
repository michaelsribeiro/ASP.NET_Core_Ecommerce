using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolsMarket.Data.Migrations
{
    public partial class AjusteItemPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Produtos_ProdutoId",
                table: "ItensPedido");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedido_ProdutoId",
                table: "ItensPedido");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemPedidoId",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ItemPedidoId",
                table: "Produtos",
                column: "ItemPedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ItensPedido_ItemPedidoId",
                table: "Produtos",
                column: "ItemPedidoId",
                principalTable: "ItensPedido",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ItensPedido_ItemPedidoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_ItemPedidoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ItemPedidoId",
                table: "Produtos");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_ProdutoId",
                table: "ItensPedido",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Produtos_ProdutoId",
                table: "ItensPedido",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}
