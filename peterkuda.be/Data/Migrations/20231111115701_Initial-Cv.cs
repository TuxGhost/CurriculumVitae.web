using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurriculumVitae.Data.Migrations
{
    public partial class InitialCv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "computerVaardigheiden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Omschrijving = table.Column<string>(type: "TEXT", nullable: false),
                    Niveau = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_computerVaardigheiden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Taal = table.Column<string>(type: "TEXT", nullable: false),
                    Niveau = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talen", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "computerVaardigheiden");

            migrationBuilder.DropTable(
                name: "Talen");
        }
    }
}
