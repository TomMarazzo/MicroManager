using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageDescription",
                table: "Packages");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductSize_Id",
                table: "Packages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ProductSize_Id",
                table: "Packages",
                column: "ProductSize_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_ProductSizes_ProductSize_Id",
                table: "Packages",
                column: "ProductSize_Id",
                principalTable: "ProductSizes",
                principalColumn: "ProductSizeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_ProductSizes_ProductSize_Id",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ProductSize_Id",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ProductSize_Id",
                table: "Packages");

            migrationBuilder.AddColumn<string>(
                name: "PackageDescription",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
