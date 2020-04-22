using Microsoft.EntityFrameworkCore.Migrations;

namespace Azure_List.Data.Migrations
{
    public partial class azVnetsandSubnets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "azVnets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    resourceGroup = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    addressSpace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_azVnets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "azVnetSubnets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    addressRange = table.Column<string>(nullable: true),
                    securityGroup = table.Column<string>(nullable: true),
                    routeTable = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_azVnetSubnets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "azVnets");

            migrationBuilder.DropTable(
                name: "azVnetSubnets");
        }
    }
}
