using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoVendas.Migrations
{
    public partial class DepartamentoForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedore_Departamento_DepartamentoId",
                table: "Vendedore");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Vendedore",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Vendedore",
                newName: "Email");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendedore",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedore_Departamento_DepartamentoId",
                table: "Vendedore",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedore_Departamento_DepartamentoId",
                table: "Vendedore");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Vendedore",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Vendedore",
                newName: "email");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendedore",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedore_Departamento_DepartamentoId",
                table: "Vendedore",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
