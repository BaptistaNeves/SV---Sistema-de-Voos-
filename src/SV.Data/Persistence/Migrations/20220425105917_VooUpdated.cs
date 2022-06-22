using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SV.Data.Persistence.Migrations
{
    public partial class VooUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assentos_Aeronaves_AeronaveId",
                table: "Assentos");

            migrationBuilder.AlterColumn<Guid>(
                name: "AeronaveId",
                table: "Assentos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "VooId",
                table: "Assentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Assentos_VooId",
                table: "Assentos",
                column: "VooId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assentos_Aeronaves_AeronaveId",
                table: "Assentos",
                column: "AeronaveId",
                principalTable: "Aeronaves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assentos_Voos_VooId",
                table: "Assentos",
                column: "VooId",
                principalTable: "Voos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assentos_Aeronaves_AeronaveId",
                table: "Assentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Assentos_Voos_VooId",
                table: "Assentos");

            migrationBuilder.DropIndex(
                name: "IX_Assentos_VooId",
                table: "Assentos");

            migrationBuilder.DropColumn(
                name: "VooId",
                table: "Assentos");

            migrationBuilder.AlterColumn<Guid>(
                name: "AeronaveId",
                table: "Assentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assentos_Aeronaves_AeronaveId",
                table: "Assentos",
                column: "AeronaveId",
                principalTable: "Aeronaves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
