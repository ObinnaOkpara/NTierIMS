using Microsoft.EntityFrameworkCore.Migrations;

namespace NTierIMS.UI.Migrations
{
    public partial class dbUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_InventoryItems_InventoryItemCreatedId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_CreatedBy",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Removals_EmployeeId",
                table: "Removals");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_EmployeeId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_InventoryItemCreatedId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InventoryItemCreatedId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "InventoryItems",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_CreatedBy",
                table: "Warehouses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Removals_EmployeeId",
                table: "Removals",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_CreatedBy",
                table: "InventoryItems",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_EmployeeId",
                table: "Deliveries",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_AspNetUsers_CreatedBy",
                table: "InventoryItems",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_AspNetUsers_CreatedBy",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_CreatedBy",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Removals_EmployeeId",
                table: "Removals");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_CreatedBy",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_EmployeeId",
                table: "Deliveries");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryItemCreatedId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_CreatedBy",
                table: "Warehouses",
                column: "CreatedBy",
                unique: true,
                filter: "[CreatedBy] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Removals_EmployeeId",
                table: "Removals",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_EmployeeId",
                table: "Deliveries",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_InventoryItemCreatedId",
                table: "AspNetUsers",
                column: "InventoryItemCreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_InventoryItems_InventoryItemCreatedId",
                table: "AspNetUsers",
                column: "InventoryItemCreatedId",
                principalTable: "InventoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
