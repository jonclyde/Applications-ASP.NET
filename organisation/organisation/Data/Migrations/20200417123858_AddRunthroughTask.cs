using Microsoft.EntityFrameworkCore.Migrations;

namespace organisation.Data.Migrations
{
    public partial class AddRunthroughTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RunthroughTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    RTTaskSectionId = table.Column<int>(nullable: true),
                    RTTaskStatusId = table.Column<int>(nullable: true),
                    RTTaskTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunthroughTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunthroughTask_RunthroughTaskSections_RTTaskSectionId",
                        column: x => x.RTTaskSectionId,
                        principalTable: "RunthroughTaskSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RunthroughTask_RunthroughTaskStatuses_RTTaskStatusId",
                        column: x => x.RTTaskStatusId,
                        principalTable: "RunthroughTaskStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RunthroughTask_RunthroughTaskTypes_RTTaskTypeId",
                        column: x => x.RTTaskTypeId,
                        principalTable: "RunthroughTaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RunthroughTask_RTTaskSectionId",
                table: "RunthroughTask",
                column: "RTTaskSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_RunthroughTask_RTTaskStatusId",
                table: "RunthroughTask",
                column: "RTTaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RunthroughTask_RTTaskTypeId",
                table: "RunthroughTask",
                column: "RTTaskTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunthroughTask");
        }
    }
}
