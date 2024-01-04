using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroManager.Migrations
{
    /// <inheritdoc />
    public partial class employeesStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_Customer_Id",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "Customer_Id",
                table: "Carts",
                newName: "Employee_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_Customer_Id",
                table: "Carts",
                newName: "IX_Carts_Employee_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Employees_Employee_Id",
                table: "Carts",
                column: "Employee_Id",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Employees_Employee_Id",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "Employee_Id",
                table: "Carts",
                newName: "Customer_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_Employee_Id",
                table: "Carts",
                newName: "IX_Carts_Customer_Id");

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
