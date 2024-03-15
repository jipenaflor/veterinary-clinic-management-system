using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeterinaryClinicManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class FourthModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Owner_OwnerId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Veterinarian_Pets_PetId",
                table: "Veterinarian");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veterinarian",
                table: "Veterinarian");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owner",
                table: "Owner");

            migrationBuilder.RenameTable(
                name: "Veterinarian",
                newName: "Veterinarians");

            migrationBuilder.RenameTable(
                name: "Owner",
                newName: "Owners");

            migrationBuilder.RenameIndex(
                name: "IX_Veterinarian_PetId",
                table: "Veterinarians",
                newName: "IX_Veterinarians_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veterinarians",
                table: "Veterinarians",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Owners_OwnerId",
                table: "Pets",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veterinarians_Pets_PetId",
                table: "Veterinarians",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Owners_OwnerId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Veterinarians_Pets_PetId",
                table: "Veterinarians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veterinarians",
                table: "Veterinarians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.RenameTable(
                name: "Veterinarians",
                newName: "Veterinarian");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "Owner");

            migrationBuilder.RenameIndex(
                name: "IX_Veterinarians_PetId",
                table: "Veterinarian",
                newName: "IX_Veterinarian_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veterinarian",
                table: "Veterinarian",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owner",
                table: "Owner",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Owner_OwnerId",
                table: "Pets",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veterinarian_Pets_PetId",
                table: "Veterinarian",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }
    }
}
