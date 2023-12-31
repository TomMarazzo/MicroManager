using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class productCategory1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "ProductCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductCategory_Id",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategory_Id",
                table: "Products",
                column: "ProductCategory_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategory_Id",
                table: "Products",
                column: "ProductCategory_Id",
                principalTable: "ProductCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategory_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategory_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategory_Id",
                table: "Products");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
