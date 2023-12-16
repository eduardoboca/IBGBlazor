using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IBGBlazor.Migrations
{
    /// <inheritdoc />
    public partial class mudanca_nome_tabela_ibge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.CreateTable(
                name: "IBGE",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(7)", nullable: false),
                    State = table.Column<string>(type: "char(2)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IBGE", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IBGE");

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(7)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    State = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                });
        }
    }
}
