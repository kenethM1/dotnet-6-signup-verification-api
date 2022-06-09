using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class isSelledValueProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Cards_CardId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_CardId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Sale");

            migrationBuilder.AddColumn<int>(
                name: "SaleId1",
                table: "SaleDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelled",
                table: "Products",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_SaleId1",
                table: "SaleDetail",
                column: "SaleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetail_Sale_SaleId1",
                table: "SaleDetail",
                column: "SaleId1",
                principalTable: "Sale",
                principalColumn: "SaleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetail_Sale_SaleId1",
                table: "SaleDetail");

            migrationBuilder.DropIndex(
                name: "IX_SaleDetail_SaleId1",
                table: "SaleDetail");

            migrationBuilder.DropColumn(
                name: "SaleId1",
                table: "SaleDetail");

            migrationBuilder.DropColumn(
                name: "IsSelled",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyId",
                table: "Sale",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CardId",
                table: "Sale",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Cards_CardId",
                table: "Sale",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
