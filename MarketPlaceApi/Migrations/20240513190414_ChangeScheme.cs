using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlaceApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeScheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                schema: "identity",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                schema: "identity",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                schema: "identity",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatusChanges_Orders_OrderId",
                schema: "identity",
                table: "OrderStatusChanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                schema: "identity",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStatusChanges",
                schema: "identity",
                table: "OrderStatusChanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                schema: "identity",
                table: "Orders");

            migrationBuilder.EnsureSchema(
                name: "mp");

            migrationBuilder.RenameTable(
                name: "OrderProducts",
                schema: "identity",
                newName: "OrderProducts",
                newSchema: "mp");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "identity",
                newName: "Product",
                newSchema: "mp");

            migrationBuilder.RenameTable(
                name: "OrderStatusChanges",
                schema: "identity",
                newName: "OrderStatusChange",
                newSchema: "mp");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "identity",
                newName: "Order",
                newSchema: "mp");

            migrationBuilder.RenameIndex(
                name: "IX_OrderStatusChanges_OrderId",
                schema: "mp",
                table: "OrderStatusChange",
                newName: "IX_OrderStatusChange_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                schema: "mp",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                schema: "mp",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStatusChange",
                schema: "mp",
                table: "OrderStatusChange",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                schema: "mp",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                schema: "mp",
                table: "Order",
                column: "UserId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Order_OrderId",
                schema: "mp",
                table: "OrderProducts",
                column: "OrderId",
                principalSchema: "mp",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Product_ProductId",
                schema: "mp",
                table: "OrderProducts",
                column: "ProductId",
                principalSchema: "mp",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatusChange_Order_OrderId",
                schema: "mp",
                table: "OrderStatusChange",
                column: "OrderId",
                principalSchema: "mp",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                schema: "mp",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Order_OrderId",
                schema: "mp",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Product_ProductId",
                schema: "mp",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatusChange_Order_OrderId",
                schema: "mp",
                table: "OrderStatusChange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                schema: "mp",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStatusChange",
                schema: "mp",
                table: "OrderStatusChange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                schema: "mp",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "OrderProducts",
                schema: "mp",
                newName: "OrderProducts",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "mp",
                newName: "Products",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "OrderStatusChange",
                schema: "mp",
                newName: "OrderStatusChanges",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "Order",
                schema: "mp",
                newName: "Orders",
                newSchema: "identity");

            migrationBuilder.RenameIndex(
                name: "IX_OrderStatusChange_OrderId",
                schema: "identity",
                table: "OrderStatusChanges",
                newName: "IX_OrderStatusChanges_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                schema: "identity",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                schema: "identity",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStatusChanges",
                schema: "identity",
                table: "OrderStatusChanges",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                schema: "identity",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                schema: "identity",
                table: "OrderProducts",
                column: "OrderId",
                principalSchema: "identity",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                schema: "identity",
                table: "OrderProducts",
                column: "ProductId",
                principalSchema: "identity",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                schema: "identity",
                table: "Orders",
                column: "UserId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatusChanges_Orders_OrderId",
                schema: "identity",
                table: "OrderStatusChanges",
                column: "OrderId",
                principalSchema: "identity",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
