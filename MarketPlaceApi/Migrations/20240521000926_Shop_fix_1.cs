using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlaceApi.Migrations
{
    /// <inheritdoc />
    public partial class Shop_fix_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                schema: "mp",
                table: "Shop",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_OwnerId",
                schema: "mp",
                table: "Shop",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_AspNetUsers_OwnerId",
                schema: "mp",
                table: "Shop",
                column: "OwnerId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shop_AspNetUsers_OwnerId",
                schema: "mp",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Shop_OwnerId",
                schema: "mp",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "mp",
                table: "Shop");
        }
    }
}
