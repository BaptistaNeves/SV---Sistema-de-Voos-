using Microsoft.EntityFrameworkCore.Migrations;

namespace SV.Data.Persistence.Migrations
{
    public partial class ForeignKeyReservaVoo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VooId",
                table: "Reservas",
                column: "VooId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Voos_VooId",
                table: "Reservas",
                column: "VooId",
                principalTable: "Voos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Voos_VooId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_VooId",
                table: "Reservas");
        }
    }
}
