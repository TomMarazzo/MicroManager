using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_InventoryCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategory_ProductCategory_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_InventoryCategory_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InventoryCategory_Id",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "InventoryCategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryCategoryId",
                table: "Products",
                column: "InventoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_InventoryCategories_InventoryCategoryId",
                table: "Products",
                column: "InventoryCategoryId",
                principalTable: "InventoryCategories",
                principalColumn: "InventoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_InventoryCategoryId",
                table: "Products",
                column: "ProductCategory_Id",
                principalTable: "ProductCategory",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_InventoryCategories_InventoryCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_InventoryCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_InventoryCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InventoryCategoryId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "InventoryCategory_Id",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryCategory_Id",
                table: "Products",
                column: "InventoryCategory_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_InventoryCategoryId",
                table: "Products",
                column: "InventoryCategory_Id",
                principalTable: "InventoryCategories",
                principalColumn: "InventoryCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategory_ProductCategory_Id",
                table: "Products",
                column: "ProductCategory_Id",
                principalTable: "ProductCategory",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
