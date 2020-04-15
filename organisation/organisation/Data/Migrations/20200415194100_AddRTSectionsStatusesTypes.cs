using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace organisation.Data.Migrations
{
    public partial class AddRTSectionsStatusesTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RunthroughTaskSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunthroughTaskSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunthroughTaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunthroughTaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunthroughTaskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunthroughTaskTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunthroughTaskSections");

            migrationBuilder.DropTable(
                name: "RunthroughTaskStatuses");

            migrationBuilder.DropTable(
                name: "RunthroughTaskTypes");
        }
    }
}
