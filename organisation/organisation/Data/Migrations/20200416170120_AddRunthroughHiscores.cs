using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace organisation.Data.Migrations
{
    public partial class AddRunthroughHiscores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RunthroughHiscores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    ResourceManual = table.Column<int>(nullable: false),
                    ResourceARMManual = table.Column<int>(nullable: false),
                    ResourceDevOpsv0_1 = table.Column<int>(nullable: false),
                    ResourceDevOpsv0_2 = table.Column<int>(nullable: false),
                    ResourceDevOpsTotal = table.Column<int>(nullable: false),
                    ResourceTotal = table.Column<int>(nullable: false),
                    TaskTotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunthroughHiscores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunthroughHiscores");
        }
    }
}
