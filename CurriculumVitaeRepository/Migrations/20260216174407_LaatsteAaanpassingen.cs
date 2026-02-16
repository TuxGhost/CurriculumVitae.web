using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurriculumVitaeRepository.Migrations
{
    /// <inheritdoc />
    public partial class LaatsteAaanpassingen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComputerSkills_Profiles_profielId",
                table: "ComputerSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonnalSkills_Profiles_profielId",
                table: "PersonnalSkills");

            migrationBuilder.RenameColumn(
                name: "profielId",
                table: "PersonnalSkills",
                newName: "ProfielId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonnalSkills_profielId",
                table: "PersonnalSkills",
                newName: "IX_PersonnalSkills_ProfielId");

            migrationBuilder.RenameColumn(
                name: "profielId",
                table: "ComputerSkills",
                newName: "ProfielId");

            migrationBuilder.RenameIndex(
                name: "IX_ComputerSkills_profielId",
                table: "ComputerSkills",
                newName: "IX_ComputerSkills_ProfielId");

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Profiles",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerSkills_Profiles_ProfielId",
                table: "ComputerSkills",
                column: "ProfielId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonnalSkills_Profiles_ProfielId",
                table: "PersonnalSkills",
                column: "ProfielId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComputerSkills_Profiles_ProfielId",
                table: "ComputerSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonnalSkills_Profiles_ProfielId",
                table: "PersonnalSkills");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "ProfielId",
                table: "PersonnalSkills",
                newName: "profielId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonnalSkills_ProfielId",
                table: "PersonnalSkills",
                newName: "IX_PersonnalSkills_profielId");

            migrationBuilder.RenameColumn(
                name: "ProfielId",
                table: "ComputerSkills",
                newName: "profielId");

            migrationBuilder.RenameIndex(
                name: "IX_ComputerSkills_ProfielId",
                table: "ComputerSkills",
                newName: "IX_ComputerSkills_profielId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerSkills_Profiles_profielId",
                table: "ComputerSkills",
                column: "profielId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonnalSkills_Profiles_profielId",
                table: "PersonnalSkills",
                column: "profielId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
