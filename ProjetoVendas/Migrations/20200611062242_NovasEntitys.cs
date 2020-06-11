using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoVendas.Migrations
{
    public partial class NovasEntitys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendedore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    DataDeNascimento = table.Column<DateTime>(nullable: false),
                    Salario = table.Column<double>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendedore_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoDeVenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    VendedorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoDeVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoDeVenda_Vendedore_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoDeVenda_VendedorId",
                table: "HistoricoDeVenda",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedore_DepartamentoId",
                table: "Vendedore",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoDeVenda");

            migrationBuilder.DropTable(
                name: "Vendedore");
        }
    }
}
