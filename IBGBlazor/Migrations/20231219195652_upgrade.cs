using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBGBlazor.Migrations
{
    /// <inheritdoc />
    public partial class upgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Estados_EstadoCodigo_UF",
                table: "Municipios");

            migrationBuilder.DropTable(
                name: "IBGE");

            migrationBuilder.RenameColumn(
                name: "EstadoCodigo_UF",
                table: "Municipios",
                newName: "Codigo_UF");

            migrationBuilder.RenameIndex(
                name: "IX_Municipios_EstadoCodigo_UF",
                table: "Municipios",
                newName: "IX_Municipios_Codigo_UF");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Estados_Codigo_UF",
                table: "Municipios",
                column: "Codigo_UF",
                principalTable: "Estados",
                principalColumn: "Codigo_UF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Estados_Codigo_UF",
                table: "Municipios");

            migrationBuilder.RenameColumn(
                name: "Codigo_UF",
                table: "Municipios",
                newName: "EstadoCodigo_UF");

            migrationBuilder.RenameIndex(
                name: "IX_Municipios_Codigo_UF",
                table: "Municipios",
                newName: "IX_Municipios_EstadoCodigo_UF");

            migrationBuilder.CreateTable(
                name: "IBGE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(7)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    State = table.Column<string>(type: "char(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IBGE", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Estados_EstadoCodigo_UF",
                table: "Municipios",
                column: "EstadoCodigo_UF",
                principalTable: "Estados",
                principalColumn: "Codigo_UF");
        }
    }
}
