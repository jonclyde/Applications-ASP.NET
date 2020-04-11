using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _3D_Printing_Service.Data.Migrations
{
    public partial class removePickupDateandTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickUpTime",
                table: "OrderHeader");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PickUpTime",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
