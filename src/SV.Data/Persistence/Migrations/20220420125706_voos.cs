using Microsoft.EntityFrameworkCore.Migrations;

namespace SV.Data.Persistence.Migrations
{
    public partial class voos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoPiloto",
                table: "Voos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Voos",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Piloto",
                table: "Voos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoPiloto",
                table: "Voos");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Voos");

            migrationBuilder.DropColumn(
                name: "Piloto",
                table: "Voos");
        }
    }
}
