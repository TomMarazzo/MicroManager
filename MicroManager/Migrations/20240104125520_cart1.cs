using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class cart1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_Customer_Id",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_Customer_Id",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "Carts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Customer_Id",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Carts_Customer_Id",
                table: "Carts",
                column: "Customer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_Customer_Id",
                table: "Carts",
                column: "Customer_Id",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
