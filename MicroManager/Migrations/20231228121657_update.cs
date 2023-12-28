using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Product_ProductId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Product_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Crops_CropId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Crops_Crop_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductSize_ProductSize_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_ProductSize_ProductSizeId1",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_ProductSize_ProductSizeId1",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductSizeId1",
                table: "ProductSize");

            migrationBuilder.RenameTable(
                name: "ProductSize",
                newName: "ProductSizes");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductSize_Id",
                table: "Products",
                newName: "IX_Products_ProductSize_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CropId",
                table: "Products",
                newName: "IX_Products_CropId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Crop_Id",
                table: "Products",
                newName: "IX_Products_Crop_Id");

            migrationBuilder.AddColumn<string>(
                name: "PackageDescription",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSizes",
                table: "ProductSizes",
                column: "ProductSizeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_ProductId",
                table: "Carts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Crops_CropId",
                table: "Products",
                column: "CropId",
                principalTable: "Crops",
                principalColumn: "CropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Crops_Crop_Id",
                table: "Products",
                column: "Crop_Id",
                principalTable: "Crops",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSizes_ProductSize_Id",
                table: "Products",
                column: "ProductSize_Id",
                principalTable: "ProductSizes",
                principalColumn: "ProductSizeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Crops_CropId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Crops_Crop_Id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSizes_ProductSize_Id",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSizes",
                table: "ProductSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PackageDescription",
                table: "Packages");

            migrationBuilder.RenameTable(
                name: "ProductSizes",
                newName: "ProductSize");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductSize_Id",
                table: "Product",
                newName: "IX_Product_ProductSize_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CropId",
                table: "Product",
                newName: "IX_Product_CropId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Crop_Id",
                table: "Product",
                newName: "IX_Product_Crop_Id");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductSizeId1",
                table: "ProductSize",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize",
                column: "ProductSizeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductSizeId1",
                table: "ProductSize",
                column: "ProductSizeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Product_ProductId",
                table: "Carts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Product_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Crops_CropId",
                table: "Product",
                column: "CropId",
                principalTable: "Crops",
                principalColumn: "CropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Crops_Crop_Id",
                table: "Product",
                column: "Crop_Id",
                principalTable: "Crops",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductSize_ProductSize_Id",
                table: "Product",
                column: "ProductSize_Id",
                principalTable: "ProductSize",
                principalColumn: "ProductSizeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_ProductSize_ProductSizeId1",
                table: "ProductSize",
                column: "ProductSizeId1",
                principalTable: "ProductSize",
                principalColumn: "ProductSizeId");
        }
    }
}
