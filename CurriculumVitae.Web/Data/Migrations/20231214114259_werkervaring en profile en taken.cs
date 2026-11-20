using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurriculumVitae.Data.Migrations
{
    public partial class werkervaringenprofileentaken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profielen",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Beschrijving = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profielen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WerkErvaringen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Functie = table.Column<string>(type: "TEXT", nullable: false),
                    Bedrijf = table.Column<string>(type: "TEXT", nullable: false),
                    DatumVan = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DatumTot = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WerkErvaringen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taak",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bechrijving = table.Column<string>(type: "TEXT", nullable: false),
                    WerkErvaringId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taak_WerkErvaringen_WerkErvaringId",
                        column: x => x.WerkErvaringId,
                        principalTable: "WerkErvaringen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taak_WerkErvaringId",
                table: "Taak",
                column: "WerkErvaringId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profielen");

            migrationBuilder.DropTable(
                name: "Taak");

            migrationBuilder.DropTable(
                name: "WerkErvaringen");
        }
    }
}
