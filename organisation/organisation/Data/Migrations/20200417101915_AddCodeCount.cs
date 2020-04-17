using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace organisation.Data.Migrations
{
    public partial class AddCodeCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeCounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    IaC_Configurationv0_1 = table.Column<int>(nullable: false),
                    IaC_ARMv0_1 = table.Column<int>(nullable: false),
                    IaC_ARMv0_2 = table.Column<int>(nullable: false),
                    IaC_Terraformv0_1 = table.Column<int>(nullable: false),
                    Apps_ASP_NET = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeCounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeCounts");
        }
    }
}
