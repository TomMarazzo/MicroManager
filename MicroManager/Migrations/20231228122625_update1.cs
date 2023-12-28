using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Crops_Crop_Id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Crop_Id",
                table: "Products",
                newName: "Seed_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Crop_Id",
                table: "Products",
                newName: "IX_Products_Seed_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Seeds_Seed_Id",
                table: "Products",
                column: "Seed_Id",
                principalTable: "Seeds",
                principalColumn: "SeedId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Seeds_Seed_Id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Seed_Id",
                table: "Products",
                newName: "Crop_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Seed_Id",
                table: "Products",
                newName: "IX_Products_Crop_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Crops_Crop_Id",
                table: "Products",
                column: "Crop_Id",
                principalTable: "Crops",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
