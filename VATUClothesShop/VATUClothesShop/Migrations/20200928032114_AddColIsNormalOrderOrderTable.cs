using Microsoft.EntityFrameworkCore.Migrations;

namespace VATUClothesShop.Migrations
{
    public partial class AddColIsNormalOrderOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNormalOrder",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNormalOrder",
                table: "Orders");
        }
    }
}
