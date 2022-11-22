using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolsMarket.App.Migrations
{
    public partial class AjusteEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoViewModel_ProdutoViewModel_produtoId",
                table: "PedidoViewModel");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "EnderecoViewModel",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaProduto",
                columns: table => new
                {
                    CategoriasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProduto", x => new { x.CategoriasId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_CategoriaProduto_Categoria_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoriaProduto_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FornecedorProduto",
                columns: table => new
                {
                    FornecedoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorProduto", x => new { x.FornecedoresId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_FornecedorProduto_Fornecedor_FornecedoresId",
                        column: x => x.FornecedoresId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FornecedorProduto_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoViewModel_UsuarioId1",
                table: "EnderecoViewModel",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaProduto_ProdutosId",
                table: "CategoriaProduto",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorProduto_ProdutosId",
                table: "FornecedorProduto",
                column: "ProdutosId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoViewModel_AspNetUsers_UsuarioId1",
                table: "EnderecoViewModel",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoViewModel_Produto_produtoId",
                table: "PedidoViewModel",
                column: "produtoId",
                principalTable: "Produto",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoViewModel_AspNetUsers_UsuarioId1",
                table: "EnderecoViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoViewModel_Produto_produtoId",
                table: "PedidoViewModel");

            migrationBuilder.DropTable(
                name: "CategoriaProduto");

            migrationBuilder.DropTable(
                name: "FornecedorProduto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_EnderecoViewModel_UsuarioId1",
                table: "EnderecoViewModel");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "EnderecoViewModel");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoViewModel_ProdutoViewModel_produtoId",
                table: "PedidoViewModel",
                column: "produtoId",
                principalTable: "ProdutoViewModel",
                principalColumn: "Id");
        }
    }
}
