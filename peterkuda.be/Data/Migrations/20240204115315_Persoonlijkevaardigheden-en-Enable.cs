using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurriculumVitae.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersoonlijkevaardighedenenEnable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "WerkErvaringen",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Talen",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Taak",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Profielen",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "computerVaardigheiden",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PersoonlijkeVaardigheden",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersoonlijkeVaardigheden", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersoonlijkeVaardigheden");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "WerkErvaringen");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Talen");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Taak");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Profielen");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "computerVaardigheiden");
        }
    }
}
