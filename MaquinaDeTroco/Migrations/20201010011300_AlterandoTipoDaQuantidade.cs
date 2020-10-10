using Microsoft.EntityFrameworkCore.Migrations;

namespace MaquinaDeTroco.Migrations
{
    public partial class AlterandoTipoDaQuantidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantidade",
                table: "Saldos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Saldos",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
