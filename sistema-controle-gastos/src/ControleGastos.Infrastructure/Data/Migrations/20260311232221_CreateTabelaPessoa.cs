using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleGastos.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTabelaPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_CATEGORIAS",
                columns: table => new
                {
                    ID_CATEGORIA = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TX_DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    TX_FINALIDADE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CATEGORIAS", x => x.ID_CATEGORIA);
                });

            migrationBuilder.CreateTable(
                name: "T_PESSOAS",
                columns: table => new
                {
                    ID_PESSOA = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TX_PESSOA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QT_IDADE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PESSOAS", x => x.ID_PESSOA);
                });

            migrationBuilder.CreateTable(
                name: "T_TRANSACOES",
                columns: table => new
                {
                    ID_TRANSACAO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TX_DESCRICAO = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    QT_VALOR = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TX_TIPO_TRANSACAO = table.Column<int>(type: "int", nullable: false),
                    CATEGORIA_ID = table.Column<long>(type: "bigint", nullable: false),
                    PESSOA_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TRANSACOES", x => x.ID_TRANSACAO);
                    table.ForeignKey(
                        name: "FK_T_TRANSACOES_T_CATEGORIAS_CATEGORIA_ID",
                        column: x => x.CATEGORIA_ID,
                        principalTable: "T_CATEGORIAS",
                        principalColumn: "ID_CATEGORIA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_TRANSACOES_T_PESSOAS_PESSOA_ID",
                        column: x => x.PESSOA_ID,
                        principalTable: "T_PESSOAS",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_TRANSACOES_CATEGORIA_ID",
                table: "T_TRANSACOES",
                column: "CATEGORIA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_TRANSACOES_PESSOA_ID",
                table: "T_TRANSACOES",
                column: "PESSOA_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_TRANSACOES");

            migrationBuilder.DropTable(
                name: "T_CATEGORIAS");

            migrationBuilder.DropTable(
                name: "T_PESSOAS");
        }
    }
}
