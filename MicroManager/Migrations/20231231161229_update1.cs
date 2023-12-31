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
                name: "FK_Carts_Products_Product_Id",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_CustomerOrders_CustomerOrder_Id",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_Product_Id",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_InventoryCategories_InventoryCategory_Id",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_ProductId",
                table: "Carts",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_CustomerOrderId",
                table: "OrderDetails",
                column: "CustomerOrder_Id",
                principalTable: "CustomerOrders",
                principalColumn: "CustomerOrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_InventoryCategoryId",
                table: "Products",
                column: "InventoryCategory_Id",
                principalTable: "InventoryCategories",
                principalColumn: "InventoryCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_ProductId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_CustomerOrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_InventoryCategoryId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_Product_Id",
                table: "Carts",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_CustomerOrders_CustomerOrder_Id",
                table: "OrderDetails",
                column: "CustomerOrder_Id",
                principalTable: "CustomerOrders",
                principalColumn: "CustomerOrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_Product_Id",
                table: "OrderDetails",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_InventoryCategories_InventoryCategory_Id",
                table: "Products",
                column: "InventoryCategory_Id",
                principalTable: "InventoryCategories",
                principalColumn: "InventoryCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
