using Microsoft.EntityFrameworkCore.Migrations;

namespace VATUClothesShop.Migrations
{
    public partial class EditRelationshipOderAndShoppingCartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AccountCustomerId1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_AccountCustomerId1",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_AccountCustomerId1",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AccountCustomerId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AccountCustomerId1",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "AccountCustomerId1",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "AccountCustomerId",
                table: "ShoppingCarts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AccountCustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_AccountCustomerId",
                table: "ShoppingCarts",
                column: "AccountCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountCustomerId",
                table: "Orders",
                column: "AccountCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AccountCustomerId",
                table: "Orders",
                column: "AccountCustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_AccountCustomerId",
                table: "ShoppingCarts",
                column: "AccountCustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AccountCustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_AccountCustomerId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_AccountCustomerId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AccountCustomerId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "AccountCustomerId",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountCustomerId1",
                table: "ShoppingCarts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountCustomerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountCustomerId1",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_AccountCustomerId1",
                table: "ShoppingCarts",
                column: "AccountCustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountCustomerId1",
                table: "Orders",
                column: "AccountCustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AccountCustomerId1",
                table: "Orders",
                column: "AccountCustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_AccountCustomerId1",
                table: "ShoppingCarts",
                column: "AccountCustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
