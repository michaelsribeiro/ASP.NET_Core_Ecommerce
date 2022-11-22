using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolsMarket.Data.Migrations
{
    public partial class AjusteEndereco1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Produtos_ProdutoId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Produtos_ProdutoId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_ProdutoId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_ProdutoId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Categorias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "Fornecedores",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "Categorias",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_ProdutoId",
                table: "Fornecedores",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ProdutoId",
                table: "Categorias",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Produtos_ProdutoId",
                table: "Categorias",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Produtos_ProdutoId",
                table: "Fornecedores",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}
