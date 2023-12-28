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
                name: "FK_Packages_ProductSizes_ProductSize_Id",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSizes_ProductSize_Id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductSize_Id",
                table: "Products",
                newName: "Product_ProductSize_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductSize_Id",
                table: "Products",
                newName: "IX_Products_Product_ProductSize_Id");

            migrationBuilder.RenameColumn(
                name: "ProductSize_Id",
                table: "Packages",
                newName: "Package_ProductSize_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_ProductSize_Id",
                table: "Packages",
                newName: "IX_Packages_Package_ProductSize_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_ProductSizes_Package_ProductSize_Id",
                table: "Packages",
                column: "Package_ProductSize_Id",
                principalTable: "ProductSizes",
                principalColumn: "ProductSizeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSizes_Product_ProductSize_Id",
                table: "Products",
                column: "Product_ProductSize_Id",
                principalTable: "ProductSizes",
                principalColumn: "ProductSizeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_ProductSizes_Package_ProductSize_Id",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSizes_Product_ProductSize_Id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Product_ProductSize_Id",
                table: "Products",
                newName: "ProductSize_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Product_ProductSize_Id",
                table: "Products",
                newName: "IX_Products_ProductSize_Id");

            migrationBuilder.RenameColumn(
                name: "Package_ProductSize_Id",
                table: "Packages",
                newName: "ProductSize_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_Package_ProductSize_Id",
                table: "Packages",
                newName: "IX_Packages_ProductSize_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_ProductSizes_ProductSize_Id",
                table: "Packages",
                column: "ProductSize_Id",
                principalTable: "ProductSizes",
                principalColumn: "ProductSizeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSizes_ProductSize_Id",
                table: "Products",
                column: "ProductSize_Id",
                principalTable: "ProductSizes",
                principalColumn: "ProductSizeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
