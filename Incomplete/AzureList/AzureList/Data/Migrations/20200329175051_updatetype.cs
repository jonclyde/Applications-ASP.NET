using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureList.Data.Migrations
{
    public partial class updatetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceType_ResourceCategory_ResourceProviderId",
                table: "ResourceType");

            migrationBuilder.AddColumn<int>(
                name: "ResourceCategoryId",
                table: "ResourceType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceType_ResourceCategoryId",
                table: "ResourceType",
                column: "ResourceCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceType_ResourceCategory_ResourceCategoryId",
                table: "ResourceType",
                column: "ResourceCategoryId",
                principalTable: "ResourceCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceType_ResourceProvider_ResourceProviderId",
                table: "ResourceType",
                column: "ResourceProviderId",
                principalTable: "ResourceProvider",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceType_ResourceCategory_ResourceCategoryId",
                table: "ResourceType");

            migrationBuilder.DropForeignKey(
                name: "FK_ResourceType_ResourceProvider_ResourceProviderId",
                table: "ResourceType");

            migrationBuilder.DropIndex(
                name: "IX_ResourceType_ResourceCategoryId",
                table: "ResourceType");

            migrationBuilder.DropColumn(
                name: "ResourceCategoryId",
                table: "ResourceType");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceType_ResourceCategory_ResourceProviderId",
                table: "ResourceType",
                column: "ResourceProviderId",
                principalTable: "ResourceCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
