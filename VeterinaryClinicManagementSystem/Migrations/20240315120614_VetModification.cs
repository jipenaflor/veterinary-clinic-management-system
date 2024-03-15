using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinaryClinicManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class VetModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veterinarians_Pets_PetId",
                table: "Veterinarians");

            migrationBuilder.DropIndex(
                name: "IX_Veterinarians_PetId",
                table: "Veterinarians");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Veterinarians");

            migrationBuilder.AddColumn<int>(
                name: "VeterinarianId",
                table: "Pets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_VeterinarianId",
                table: "Pets",
                column: "VeterinarianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Veterinarians_VeterinarianId",
                table: "Pets",
                column: "VeterinarianId",
                principalTable: "Veterinarians",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Veterinarians_VeterinarianId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_VeterinarianId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "VeterinarianId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Veterinarians",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarians_PetId",
                table: "Veterinarians",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veterinarians_Pets_PetId",
                table: "Veterinarians",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }
    }
}
