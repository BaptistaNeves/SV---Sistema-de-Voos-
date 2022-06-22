using Microsoft.EntityFrameworkCore.Migrations;

namespace SV.Data.Persistence.Migrations
{
    public partial class ColumnStatusAddedToAssentosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Assentos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Assentos");
        }
    }
}
