using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class updates1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrowMedias_GrowMediaTypes_SupplierId",
                table: "GrowMedias");

            migrationBuilder.CreateIndex(
                name: "IX_GrowMedias_GMTypeId",
                table: "GrowMedias",
                column: "GMTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrowMedias_GrowMediaTypes_GMTypeId",
                table: "GrowMedias",
                column: "GMTypeId",
                principalTable: "GrowMediaTypes",
                principalColumn: "GMTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrowMedias_GrowMediaTypes_GMTypeId",
                table: "GrowMedias");

            migrationBuilder.DropIndex(
                name: "IX_GrowMedias_GMTypeId",
                table: "GrowMedias");

            migrationBuilder.AddForeignKey(
                name: "FK_GrowMedias_GrowMediaTypes_SupplierId",
                table: "GrowMedias",
                column: "SupplierId",
                principalTable: "GrowMediaTypes",
                principalColumn: "GMTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
