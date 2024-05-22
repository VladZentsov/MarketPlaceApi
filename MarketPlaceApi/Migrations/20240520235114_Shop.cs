using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPlaceApi.Migrations
{
    /// <inheritdoc />
    public partial class Shop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                schema: "mp",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Shop",
                schema: "mp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ShopId",
                schema: "mp",
                table: "Product",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Shop_ShopId",
                schema: "mp",
                table: "Product",
                column: "ShopId",
                principalSchema: "mp",
                principalTable: "Shop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Shop_ShopId",
                schema: "mp",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Shop",
                schema: "mp");

            migrationBuilder.DropIndex(
                name: "IX_Product_ShopId",
                schema: "mp",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ShopId",
                schema: "mp",
                table: "Product");
        }
    }
}
