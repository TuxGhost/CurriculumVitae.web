using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurriculumVitaeRepository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCVDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Beschrijving = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    profielId = table.Column<uint>(type: "INTEGER", nullable: false),
                    Omschrijving = table.Column<string>(type: "TEXT", nullable: false),
                    Niveau = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputerSkills_Profiles_profielId",
                        column: x => x.profielId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    profielId = table.Column<uint>(type: "INTEGER", nullable: false),
                    TaalOmschrijving = table.Column<string>(type: "TEXT", nullable: false),
                    Niveau = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Profiles_profielId",
                        column: x => x.profielId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonnalSkills",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    profielId = table.Column<uint>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnalSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnalSkills_Profiles_profielId",
                        column: x => x.profielId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workexperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    profielId = table.Column<uint>(type: "INTEGER", nullable: false),
                    Functie = table.Column<string>(type: "TEXT", nullable: false),
                    Bedrijf = table.Column<string>(type: "TEXT", nullable: false),
                    DatumVan = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DatumTot = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workexperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workexperiences_Profiles_profielId",
                        column: x => x.profielId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WerkErvaringId = table.Column<int>(type: "INTEGER", nullable: false),
                    Bechrijving = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Workexperiences_WerkErvaringId",
                        column: x => x.WerkErvaringId,
                        principalTable: "Workexperiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerSkills_profielId",
                table: "ComputerSkills",
                column: "profielId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_profielId",
                table: "Languages",
                column: "profielId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnalSkills_profielId",
                table: "PersonnalSkills",
                column: "profielId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_WerkErvaringId",
                table: "Tasks",
                column: "WerkErvaringId");

            migrationBuilder.CreateIndex(
                name: "IX_Workexperiences_profielId",
                table: "Workexperiences",
                column: "profielId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerSkills");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "PersonnalSkills");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Workexperiences");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
