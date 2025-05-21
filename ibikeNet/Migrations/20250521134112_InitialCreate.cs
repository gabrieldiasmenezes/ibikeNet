using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ibikeNet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "patio",
                columns: table => new
                {
                    id_patio = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_patio = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Capacidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patio", x => x.id_patio);
                });

            migrationBuilder.CreateTable(
                name: "administrador",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    nm_adm = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PatioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PatioId1 = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrador", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_administrador_patio_PatioId1",
                        column: x => x.PatioId1,
                        principalTable: "patio",
                        principalColumn: "id_patio");
                });

            migrationBuilder.CreateTable(
                name: "moto",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Modelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    km_atual = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    data_ultimo_check = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PatioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PatioId1 = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moto", x => x.Placa);
                    table.ForeignKey(
                        name: "FK_moto_patio_PatioId1",
                        column: x => x.PatioId1,
                        principalTable: "patio",
                        principalColumn: "id_patio");
                });

            migrationBuilder.CreateTable(
                name: "monitoracao",
                columns: table => new
                {
                    id_monitoracao = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    tipo_evento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    data_hora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    placa_moto = table.Column<string>(type: "NVARCHAR2(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monitoracao", x => x.id_monitoracao);
                    table.ForeignKey(
                        name: "FK_monitoracao_moto_placa_moto",
                        column: x => x.placa_moto,
                        principalTable: "moto",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_administrador_PatioId1",
                table: "administrador",
                column: "PatioId1");

            migrationBuilder.CreateIndex(
                name: "IX_monitoracao_placa_moto",
                table: "monitoracao",
                column: "placa_moto");

            migrationBuilder.CreateIndex(
                name: "IX_moto_PatioId1",
                table: "moto",
                column: "PatioId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrador");

            migrationBuilder.DropTable(
                name: "monitoracao");

            migrationBuilder.DropTable(
                name: "moto");

            migrationBuilder.DropTable(
                name: "patio");
        }
    }
}
