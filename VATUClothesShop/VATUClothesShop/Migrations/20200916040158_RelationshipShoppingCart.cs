using Microsoft.EntityFrameworkCore.Migrations;

namespace VATUClothesShop.Migrations
{
    public partial class RelationshipShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountCustomerId",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AccountCustomerId1",
                table: "ShoppingCarts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ShoppingCartDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "ShoppingCartDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_AccountCustomerId1",
                table: "ShoppingCarts",
                column: "AccountCustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartDetails_ProductId",
                table: "ShoppingCartDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartDetails_ShoppingCartId",
                table: "ShoppingCartDetails",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartDetails_Products_ProductId",
                table: "ShoppingCartDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartDetails_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartDetails",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_AccountCustomerId1",
                table: "ShoppingCarts",
                column: "AccountCustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartDetails_Products_ProductId",
                table: "ShoppingCartDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartDetails_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_AccountCustomerId1",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_AccountCustomerId1",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartDetails_ProductId",
                table: "ShoppingCartDetails");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartDetails_ShoppingCartId",
                table: "ShoppingCartDetails");

            migrationBuilder.DropColumn(
                name: "AccountCustomerId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "AccountCustomerId1",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ShoppingCartDetails");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ShoppingCartDetails");
        }
    }
}
