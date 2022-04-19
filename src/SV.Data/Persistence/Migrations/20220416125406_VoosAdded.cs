using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SV.Data.Persistence.Migrations
{
    public partial class VoosAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposDeVoo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeVoo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDeVooId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AeroportoDeOrigem = table.Column<string>(type: "varchar(100)", nullable: false),
                    AeroportoDestino = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", nullable: false),
                    DataDePartida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraDePartida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrevisaoDeChegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrevisaoDeChegadaAoDestino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    AeroportoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voos_Aeronaves_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "Aeronaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voos_Aeroportos_AeroportoId",
                        column: x => x.AeroportoId,
                        principalTable: "Aeroportos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voos_TiposDeVoo_TipoDeVooId",
                        column: x => x.TipoDeVooId,
                        principalTable: "TiposDeVoo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voos_AeronaveId",
                table: "Voos",
                column: "AeronaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_AeroportoId",
                table: "Voos",
                column: "AeroportoId");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_TipoDeVooId",
                table: "Voos",
                column: "TipoDeVooId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voos");

            migrationBuilder.DropTable(
                name: "TiposDeVoo");
        }
    }
}
