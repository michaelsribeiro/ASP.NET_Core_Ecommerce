using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolsMarket.App.Migrations
{
    public partial class AjusteClassApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Genero",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "AspNetUsers",
                type: "varchar(100)",
                nullable: true);
        }
    }
}
