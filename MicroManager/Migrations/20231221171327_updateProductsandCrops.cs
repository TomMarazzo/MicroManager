using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class updateProductsandCrops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CropId1",
                table: "Crops",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CropId",
                table: "Products",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_CropId1",
                table: "Crops",
                column: "CropId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Crops_CropId1",
                table: "Crops",
                column: "CropId1",
                principalTable: "Crops",
                principalColumn: "CropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Crops_CropId",
                table: "Products",
                column: "CropId",
                principalTable: "Crops",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Crops_CropId1",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Crops_CropId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CropId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Crops_CropId1",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "CropId1",
                table: "Crops");
        }
    }
}
