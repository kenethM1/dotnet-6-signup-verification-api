using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class addforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetail_Products_ProductId",
                table: "SaleDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetail_Sale_SaleId",
                table: "SaleDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_SellerForm_Accounts_IdAccount",
                table: "SellerForm");

            migrationBuilder.DropIndex(
                name: "IX_SellerForm_IdAccount",
                table: "SellerForm");

            migrationBuilder.DropIndex(
                name: "IX_SaleDetail_ProductId",
                table: "SaleDetail");

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "SaleDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "SaleId1",
                table: "SaleDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_ProductId",
                table: "SaleDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_SaleId1",
                table: "SaleDetail",
                column: "SaleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetail_Products_ProductId",
                table: "SaleDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetail_Sale_SaleId1",
                table: "SaleDetail",
                column: "SaleId1",
                principalTable: "Sale",
                principalColumn: "SaleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
