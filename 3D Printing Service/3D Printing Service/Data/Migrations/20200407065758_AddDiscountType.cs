using Microsoft.EntityFrameworkCore.Migrations;

namespace _3D_Printing_Service.Data.Migrations
{
    public partial class AddDiscountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscountType",
                table: "Discount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "Discount");
        }
    }
}
