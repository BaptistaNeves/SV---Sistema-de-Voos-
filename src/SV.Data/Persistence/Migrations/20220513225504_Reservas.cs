using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SV.Data.Persistence.Migrations
{
    public partial class Reservas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Aeronaves",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Modelo = table.Column<string>(type: "varchar(50)", nullable: false),
            //        Fabricante = table.Column<string>(type: "varchar(50)", nullable: false),
            //        TotalDeAssentos = table.Column<int>(type: "int", nullable: false),
            //        Activo = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Aeronaves", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        NomeDeUtilizador = table.Column<string>(type: "varchar(100)", nullable: true),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CategoriasFuncionario",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Nome = table.Column<string>(type: "varchar(50)", nullable: false),
            //        Descricao = table.Column<string>(type: "varchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CategoriasFuncionario", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Cidades",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Nome = table.Column<string>(type: "varchar(50)", nullable: false),
            //        Pais = table.Column<string>(type: "varchar(50)", nullable: false),
            //        Descricao = table.Column<string>(type: "varchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cidades", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Classes",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Descricao = table.Column<string>(type: "varchar(50)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Classes", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VooId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(222)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "varchar(20)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "varchar(225)", nullable: false),
                    Email = table.Column<string>(type: "varchar(225)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(500)", nullable: false),
                    Sexo = table.Column<string>(type: "varchar(10)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });
        }
    }
}

//            migrationBuilder.CreateTable(
//                name: "TiposDeVoo",
//                columns: table => new
//                {
//                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
//                    Descricao = table.Column<string>(type: "varchar(max)", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_TiposDeVoo", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "AspNetRoleClaims",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
//                        column: x => x.RoleId,
//                        principalTable: "AspNetRoles",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "AspNetUserClaims",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "AspNetUserLogins",
//                columns: table => new
//                {
//                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
//                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
//                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
//                    table.ForeignKey(
//                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "AspNetUserRoles",
//                columns: table => new
//                {
//                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
//                    table.ForeignKey(
//                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
//                        column: x => x.RoleId,
//                        principalTable: "AspNetRoles",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "AspNetUserTokens",
//                columns: table => new
//                {
//                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
//                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
//                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
//                    table.ForeignKey(
//                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
//                        column: x => x.UserId,
//                        principalTable: "AspNetUsers",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "Funcionarios",
//                columns: table => new
//                {
//                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    CategoriaFuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
//                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    Naturalidade = table.Column<string>(type: "varchar(50)", nullable: false),
//                    Nacionalidade = table.Column<string>(type: "varchar(50)", nullable: false),
//                    Documento = table.Column<string>(type: "varchar(50)", nullable: false),
//                    NumeroDocumento = table.Column<string>(type: "varchar(50)", nullable: false),
//                    NivelAcademico = table.Column<string>(type: "varchar(50)", nullable: true),
//                    AreaAcademica = table.Column<string>(type: "varchar(50)", nullable: true),
//                    Telefone = table.Column<string>(type: "varchar(50)", nullable: false),
//                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
//                    Endereco = table.Column<string>(type: "varchar(500)", nullable: false),
//                    Sexo = table.Column<string>(type: "varchar(30)", nullable: false),
//                    EstadoCivil = table.Column<string>(type: "varchar(30)", nullable: false),
//                    Imagem = table.Column<string>(type: "varchar(255)", nullable: false),
//                    Ativo = table.Column<bool>(type: "bit", nullable: false),
//                    Observacao = table.Column<string>(type: "varchar(max)", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Funcionarios_CategoriasFuncionario_CategoriaFuncionarioId",
//                        column: x => x.CategoriaFuncionarioId,
//                        principalTable: "CategoriasFuncionario",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "Aeroportos",
//                columns: table => new
//                {
//                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
//                    CidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    Activo = table.Column<bool>(type: "bit", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Aeroportos", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Aeroportos_Cidades_CidadeId",
//                        column: x => x.CidadeId,
//                        principalTable: "Cidades",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateTable(
//                name: "Voos",
//                columns: table => new
//                {
//                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    TipoDeVooId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    AeroportoDeOrigem = table.Column<string>(type: "varchar(100)", nullable: false),
//                    AeroportoDestino = table.Column<string>(type: "varchar(100)", nullable: false),
//                    PrecoCusto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
//                    Descricao = table.Column<string>(type: "varchar(255)", nullable: false),
//                    Piloto = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    CoPiloto = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    Imagem = table.Column<string>(type: "varchar(255)", nullable: false),
//                    DataDePartida = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    HoraDePartida = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    PrevisaoDeChegada = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    PrevisaoDeChegadaAoDestino = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    Estado = table.Column<bool>(type: "bit", nullable: false),
//                    AeroportoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Voos", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Voos_Aeronaves_AeronaveId",
//                        column: x => x.AeronaveId,
//                        principalTable: "Aeronaves",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_Voos_Aeroportos_AeroportoId",
//                        column: x => x.AeroportoId,
//                        principalTable: "Aeroportos",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                    table.ForeignKey(
//                        name: "FK_Voos_TiposDeVoo_TipoDeVooId",
//                        column: x => x.TipoDeVooId,
//                        principalTable: "TiposDeVoo",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateTable(
//                name: "Assentos",
//                columns: table => new
//                {
//                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    Numero = table.Column<int>(type: "int", nullable: false),
//                    VooId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    ClasseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    Status = table.Column<bool>(type: "bit", nullable: false),
//                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Assentos", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Assentos_Aeronaves_AeronaveId",
//                        column: x => x.AeronaveId,
//                        principalTable: "Aeronaves",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                    table.ForeignKey(
//                        name: "FK_Assentos_Classes_ClasseId",
//                        column: x => x.ClasseId,
//                        principalTable: "Classes",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                    table.ForeignKey(
//                        name: "FK_Assentos_Voos_VooId",
//                        column: x => x.VooId,
//                        principalTable: "Voos",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_Aeroportos_CidadeId",
//                table: "Aeroportos",
//                column: "CidadeId");

//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetRoleClaims_RoleId",
//                table: "AspNetRoleClaims",
//                column: "RoleId");

//            migrationBuilder.CreateIndex(
//                name: "RoleNameIndex",
//                table: "AspNetRoles",
//                column: "NormalizedName",
//                unique: true,
//                filter: "[NormalizedName] IS NOT NULL");

//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetUserClaims_UserId",
//                table: "AspNetUserClaims",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetUserLogins_UserId",
//                table: "AspNetUserLogins",
//                column: "UserId");

//            migrationBuilder.CreateIndex(
//                name: "IX_AspNetUserRoles_RoleId",
//                table: "AspNetUserRoles",
//                column: "RoleId");

//            migrationBuilder.CreateIndex(
//                name: "EmailIndex",
//                table: "AspNetUsers",
//                column: "NormalizedEmail");

//            migrationBuilder.CreateIndex(
//                name: "UserNameIndex",
//                table: "AspNetUsers",
//                column: "NormalizedUserName",
//                unique: true,
//                filter: "[NormalizedUserName] IS NOT NULL");

//            migrationBuilder.CreateIndex(
//                name: "IX_Assentos_AeronaveId",
//                table: "Assentos",
//                column: "AeronaveId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Assentos_ClasseId",
//                table: "Assentos",
//                column: "ClasseId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Assentos_VooId",
//                table: "Assentos",
//                column: "VooId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Funcionarios_CategoriaFuncionarioId",
//                table: "Funcionarios",
//                column: "CategoriaFuncionarioId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Voos_AeronaveId",
//                table: "Voos",
//                column: "AeronaveId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Voos_AeroportoId",
//                table: "Voos",
//                column: "AeroportoId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Voos_TipoDeVooId",
//                table: "Voos",
//                column: "TipoDeVooId");
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "AspNetRoleClaims");

//            migrationBuilder.DropTable(
//                name: "AspNetUserClaims");

//            migrationBuilder.DropTable(
//                name: "AspNetUserLogins");

//            migrationBuilder.DropTable(
//                name: "AspNetUserRoles");

//            migrationBuilder.DropTable(
//                name: "AspNetUserTokens");

//            migrationBuilder.DropTable(
//                name: "Assentos");

//            migrationBuilder.DropTable(
//                name: "Funcionarios");

//            migrationBuilder.DropTable(
//                name: "Reservas");

//            migrationBuilder.DropTable(
//                name: "AspNetRoles");

//            migrationBuilder.DropTable(
//                name: "AspNetUsers");

//            migrationBuilder.DropTable(
//                name: "Classes");

//            migrationBuilder.DropTable(
//                name: "Voos");

//            migrationBuilder.DropTable(
//                name: "CategoriasFuncionario");

//            migrationBuilder.DropTable(
//                name: "Aeronaves");

//            migrationBuilder.DropTable(
//                name: "Aeroportos");

//            migrationBuilder.DropTable(
//                name: "TiposDeVoo");

//            migrationBuilder.DropTable(
//                name: "Cidades");
//        }
//    }
//}
