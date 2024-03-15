using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinaryClinicManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class VaccineModelAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vaccinations",
                table: "Pets");

            migrationBuilder.CreateTable(
                name: "Vaccine",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateAdministered = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccine");

            migrationBuilder.AddColumn<string>(
                name: "Vaccinations",
                table: "Pets",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "");
        }
    }
}
