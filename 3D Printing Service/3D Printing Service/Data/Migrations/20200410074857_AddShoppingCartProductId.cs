using Microsoft.EntityFrameworkCore.Migrations;

namespace _3D_Printing_Service.Data.Migrations
{
    public partial class AddShoppingCartProductId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ShoppingCart");
        }
    }
}
