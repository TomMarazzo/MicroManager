using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class addProductSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductSize_ProductSizeId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_ProductSize_ProductSizeId1",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize");

            migrationBuilder.RenameTable(
                name: "ProductSize",
                newName: "ProductSize_1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_ProductSizeId1",
                table: "ProductSize_1",
                newName: "IX_ProductSize_1_ProductSizeId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSize_1",
                table: "ProductSize_1",
                column: "ProductSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductSize_1_ProductSizeId",
                table: "Product",
                column: "ProductSizeId",
                principalTable: "ProductSize_1",
                principalColumn: "ProductSizeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_1_ProductSize_1_ProductSizeId1",
                table: "ProductSize_1",
                column: "ProductSizeId1",
                principalTable: "ProductSize_1",
                principalColumn: "ProductSizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductSize_1_ProductSizeId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_1_ProductSize_1_ProductSizeId1",
                table: "ProductSize_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSize_1",
                table: "ProductSize_1");

            migrationBuilder.RenameTable(
                name: "ProductSize_1",
                newName: "ProductSize");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_1_ProductSizeId1",
                table: "ProductSize",
                newName: "IX_ProductSize_ProductSizeId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize",
                column: "ProductSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductSize_ProductSizeId",
                table: "Product",
                column: "ProductSizeId",
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
