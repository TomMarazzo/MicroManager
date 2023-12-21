using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class updateCustomerCustomerType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerTypes_CustomerTypes_CustomerTypeId1",
                table: "CustomerTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Crops_CropId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_CustomerTypes_CustomerTypeId1",
                table: "CustomerTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerTypeId1",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CropId",
                table: "Product",
                newName: "IX_Product_CropId");

            migrationBuilder.AddColumn<Guid>(
                name: "CropId1",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductSizeId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Product",
                type: "float",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    ProductSizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductSizeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize", x => x.ProductSizeId);
                    table.ForeignKey(
                        name: "FK_ProductSize_ProductSize_ProductSizeId1",
                        column: x => x.ProductSizeId1,
                        principalTable: "ProductSize",
                        principalColumn: "ProductSizeId");
                });

            migrationBuilder.CreateTable(
                name: "Shelvings",
                columns: table => new
                {
                    ShelvingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Column = table.Column<int>(type: "int", nullable: false),
                    TotalGrowSpaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelvings", x => x.ShelvingId);
                    table.ForeignKey(
                        name: "FK_Shelvings_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CropId1",
                table: "Product",
                column: "CropId1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductSizeId",
                table: "Product",
                column: "ProductSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductSizeId1",
                table: "ProductSize",
                column: "ProductSizeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Shelvings_SupplierId",
                table: "Shelvings",
                column: "SupplierId");

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
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Crops_CropId1",
                table: "Product",
                column: "CropId1",
                principalTable: "Crops",
                principalColumn: "CropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductSize_ProductSizeId",
                table: "Product",
                column: "ProductSizeId",
                principalTable: "ProductSize",
                principalColumn: "ProductSizeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_Product_Crops_CropId1",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductSize_ProductSizeId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropTable(
                name: "Shelvings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CropId1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductSizeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CropId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductSizeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CropId",
                table: "Products",
                newName: "IX_Products_CropId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerTypeId1",
                table: "CustomerTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTypes_CustomerTypeId1",
                table: "CustomerTypes",
                column: "CustomerTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_ProductId",
                table: "Carts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerTypes_CustomerTypes_CustomerTypeId1",
                table: "CustomerTypes",
                column: "CustomerTypeId1",
                principalTable: "CustomerTypes",
                principalColumn: "CustomerTypeId");

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
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
