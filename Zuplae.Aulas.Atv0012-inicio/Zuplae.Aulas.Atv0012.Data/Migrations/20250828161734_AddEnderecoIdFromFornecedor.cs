using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zuplae.Aulas.Atv0012.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEnderecoIdFromFornecedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Enderecos_EnderecoId",
                table: "Fornecedores");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Fornecedores",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Enderecos_EnderecoId",
                table: "Fornecedores",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Enderecos_EnderecoId",
                table: "Fornecedores");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Fornecedores",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Enderecos_EnderecoId",
                table: "Fornecedores",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
