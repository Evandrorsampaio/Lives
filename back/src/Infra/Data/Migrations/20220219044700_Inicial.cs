using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PESSOA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    instagram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dtNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "INSCRITO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pessoaId = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSCRITO", x => x.id);
                    table.ForeignKey(
                        name: "FK_INSCRITO_PESSOA_pessoaId",
                        column: x => x.pessoaId,
                        principalTable: "PESSOA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INSTRUTOR",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pessoaId = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSTRUTOR", x => x.id);
                    table.ForeignKey(
                        name: "FK_INSTRUTOR_PESSOA_pessoaId",
                        column: x => x.pessoaId,
                        principalTable: "PESSOA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LIVE",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtHrInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duracaoMin = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    idInstrutor = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIVE", x => x.id);
                    table.ForeignKey(
                        name: "FK_LIVE_INSTRUTOR_idInstrutor",
                        column: x => x.idInstrutor,
                        principalTable: "INSTRUTOR",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "INSCRICAO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    situacao = table.Column<int>(type: "int", nullable: false),
                    idLive = table.Column<int>(type: "int", nullable: false),
                    idInscrito = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSCRICAO", x => x.id);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_INSCRITO_idInscrito",
                        column: x => x.idInscrito,
                        principalTable: "INSCRITO",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_INSCRICAO_LIVE_idLive",
                        column: x => x.idLive,
                        principalTable: "LIVE",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_INSCRICAO_idInscrito",
                table: "INSCRICAO",
                column: "idInscrito");

            migrationBuilder.CreateIndex(
                name: "IX_INSCRICAO_idLive",
                table: "INSCRICAO",
                column: "idLive");

            migrationBuilder.CreateIndex(
                name: "IX_INSCRITO_pessoaId",
                table: "INSCRITO",
                column: "pessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_INSTRUTOR_pessoaId",
                table: "INSTRUTOR",
                column: "pessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_LIVE_idInstrutor",
                table: "LIVE",
                column: "idInstrutor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INSCRICAO");

            migrationBuilder.DropTable(
                name: "INSCRITO");

            migrationBuilder.DropTable(
                name: "LIVE");

            migrationBuilder.DropTable(
                name: "INSTRUTOR");

            migrationBuilder.DropTable(
                name: "PESSOA");
        }
    }
}
