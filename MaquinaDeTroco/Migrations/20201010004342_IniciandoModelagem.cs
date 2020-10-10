using Microsoft.EntityFrameworkCore.Migrations;

namespace MaquinaDeTroco.Migrations
{
    public partial class IniciandoModelagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caixas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: true),
                    Email = table.Column<string>(type: "varchar(250)", nullable: true),
                    Senha = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saldos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaixaId = table.Column<int>(nullable: false),
                    MoedaId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saldos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saldos_Caixas_CaixaId",
                        column: x => x.CaixaId,
                        principalTable: "Caixas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Moeda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(250)", nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    SaldoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moeda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moeda_Saldos_SaldoId",
                        column: x => x.SaldoId,
                        principalTable: "Saldos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sangrias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(nullable: false),
                    MoedaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    CaixaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sangrias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sangrias_Caixas_CaixaId",
                        column: x => x.CaixaId,
                        principalTable: "Caixas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sangrias_Moeda_MoedaId",
                        column: x => x.MoedaId,
                        principalTable: "Moeda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sangrias_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Moeda",
                columns: new[] { "Id", "Descricao", "SaldoId", "Valor" },
                values: new object[,]
                {
                    { 1, "Um centavo", null, 0.10000000000000001 },
                    { 2, "Cinco centavos", null, 0.5 },
                    { 3, "Dez centavos", null, 0.10000000000000001 },
                    { 4, "Vinte e Cinco centavos", null, 0.25 },
                    { 5, "Cinquenta centavos", null, 0.5 },
                    { 6, "Um real", null, 1.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moeda_SaldoId",
                table: "Moeda",
                column: "SaldoId");

            migrationBuilder.CreateIndex(
                name: "IX_Saldos_CaixaId",
                table: "Saldos",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sangrias_CaixaId",
                table: "Sangrias",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sangrias_MoedaId",
                table: "Sangrias",
                column: "MoedaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sangrias_UsuarioId",
                table: "Sangrias",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sangrias");

            migrationBuilder.DropTable(
                name: "Moeda");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Saldos");

            migrationBuilder.DropTable(
                name: "Caixas");
        }
    }
}
