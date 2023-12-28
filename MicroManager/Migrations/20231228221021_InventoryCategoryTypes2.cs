using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class InventoryCategoryTypes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InventoryCategory_Id",
                table: "Lights",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "InventoryCategory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lights_InventoryCategory_Id",
                table: "Lights",
                column: "InventoryCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCategory_SupplierId",
                table: "InventoryCategory",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryCategory_Suppliers_SupplierId",
                table: "InventoryCategory",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lights_InventoryCategory_InventoryCategory_Id",
                table: "Lights",
                column: "InventoryCategory_Id",
                principalTable: "InventoryCategory",
                principalColumn: "InventoryCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryCategory_Suppliers_SupplierId",
                table: "InventoryCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Lights_InventoryCategory_InventoryCategory_Id",
                table: "Lights");

            migrationBuilder.DropIndex(
                name: "IX_Lights_InventoryCategory_Id",
                table: "Lights");

            migrationBuilder.DropIndex(
                name: "IX_InventoryCategory_SupplierId",
                table: "InventoryCategory");

            migrationBuilder.DropColumn(
                name: "InventoryCategory_Id",
                table: "Lights");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "InventoryCategory");
        }
    }
}
