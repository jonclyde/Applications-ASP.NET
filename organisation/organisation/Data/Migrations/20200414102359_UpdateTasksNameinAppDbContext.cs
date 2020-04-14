using Microsoft.EntityFrameworkCore.Migrations;

namespace organisation.Data.Migrations
{
    public partial class UpdateTasksNameinAppDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_UserId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "OrgTasks");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_UserId",
                table: "OrgTasks",
                newName: "IX_OrgTasks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "OrgTasks",
                newName: "IX_OrgTasks_TaskTypeId");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "OrgTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrgTasks",
                table: "OrgTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgTasks_TaskTypes_TaskTypeId",
                table: "OrgTasks",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrgTasks_AspNetUsers_UserId",
                table: "OrgTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrgTasks_TaskTypes_TaskTypeId",
                table: "OrgTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgTasks_AspNetUsers_UserId",
                table: "OrgTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrgTasks",
                table: "OrgTasks");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "OrgTasks");

            migrationBuilder.RenameTable(
                name: "OrgTasks",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_OrgTasks_UserId",
                table: "Tasks",
                newName: "IX_Tasks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrgTasks_TaskTypeId",
                table: "Tasks",
                newName: "IX_Tasks_TaskTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
