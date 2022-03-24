using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SV.Data.Persistence.Migrations
{
    public partial class FirstMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaFuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Naturalidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nacionalidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(50)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "varchar(50)", nullable: false),
                    NivelAcademico = table.Column<string>(type: "varchar(50)", nullable: true),
                    AreaAcademica = table.Column<string>(type: "varchar(50)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(500)", nullable: false),
                    Sexo = table.Column<string>(type: "varchar(30)", nullable: false),
                    EstadoCivil = table.Column<string>(type: "varchar(30)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(255)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_CategoriasFuncionario_CategoriaFuncionarioId",
                        column: x => x.CategoriaFuncionarioId,
                        principalTable: "CategoriasFuncionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CategoriaFuncionarioId",
                table: "Funcionarios",
                column: "CategoriaFuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "CategoriasFuncionario");
        }
    }
}
