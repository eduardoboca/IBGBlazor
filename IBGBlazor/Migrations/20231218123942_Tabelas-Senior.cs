using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBGBlazor.Migrations
{
    /// <inheritdoc />
    public partial class TabelasSenior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "IBGE",
                type: "char(2)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "IBGE",
                type: "nvarchar(80)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Codigo_UF = table.Column<string>(type: "char(2)", nullable: false),
                    Sigla_UF = table.Column<string>(type: "char(2)", nullable: false),
                    Nome_UF = table.Column<string>(type: "nvarchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Codigo_UF);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Codigo_Municipio = table.Column<string>(type: "char(7)", nullable: false),
                    Nome_Municipio = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    EstadoCodigo_UF = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Codigo_Municipio);
                    table.ForeignKey(
                        name: "FK_Municipios_Estados_EstadoCodigo_UF",
                        column: x => x.EstadoCodigo_UF,
                        principalTable: "Estados",
                        principalColumn: "Codigo_UF");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_EstadoCodigo_UF",
                table: "Municipios",
                column: "EstadoCodigo_UF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "IBGE",
                type: "char(2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(2)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "IBGE",
                type: "nvarchar(80)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)");
        }
    }
}
