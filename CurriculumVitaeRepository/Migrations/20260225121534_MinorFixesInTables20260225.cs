using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurriculumVitaeRepository.Migrations
{
    /// <inheritdoc />
    public partial class MinorFixesInTables20260225 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bechrijving",
                table: "Tasks",
                newName: "Beschrijving");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumTot",
                table: "Workexperiences",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Beschrijving",
                table: "Tasks",
                newName: "Bechrijving");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumTot",
                table: "Workexperiences",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
