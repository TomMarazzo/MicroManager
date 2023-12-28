using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class InventoryCategoryTypes1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryCategory",
                columns: table => new
                {
                    InventoryCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryCategoryType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryCategory", x => x.InventoryCategoryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryCategory");
        }
    }
}
