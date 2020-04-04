using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureList.Data.Migrations
{
    public partial class AddResourceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResourceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ResourceProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceType_ResourceCategory_ResourceProviderId",
                        column: x => x.ResourceProviderId,
                        principalTable: "ResourceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceType_ResourceProviderId",
                table: "ResourceType",
                column: "ResourceProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceType");
        }
    }
}
