using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskList.Data.Migrations
{
    public partial class updatetasksintdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskCategory_CategoryId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CategoryId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskCategoryId",
                table: "Tasks",
                column: "TaskCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskCategory_TaskCategoryId",
                table: "Tasks",
                column: "TaskCategoryId",
                principalTable: "TaskCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskCategory_TaskCategoryId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskCategoryId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoryId",
                table: "Tasks",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskCategory_CategoryId",
                table: "Tasks",
                column: "CategoryId",
                principalTable: "TaskCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
