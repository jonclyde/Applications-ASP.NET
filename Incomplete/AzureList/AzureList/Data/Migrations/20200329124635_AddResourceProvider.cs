using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureList.Data.Migrations
{
    public partial class AddResourceProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResourceProvider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ResourceCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceProvider_ResourceCategory_ResourceCategoryId",
                        column: x => x.ResourceCategoryId,
                        principalTable: "ResourceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceProvider_ResourceCategoryId",
                table: "ResourceProvider",
                column: "ResourceCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceProvider");
        }
    }
}
