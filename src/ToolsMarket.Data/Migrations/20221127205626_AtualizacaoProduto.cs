using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolsMarket.Data.Migrations
{
    public partial class AtualizacaoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "ItensPedido",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "ItensPedido");
        }
    }
}
