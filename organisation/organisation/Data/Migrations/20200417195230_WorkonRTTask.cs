using Microsoft.EntityFrameworkCore.Migrations;

namespace organisation.Data.Migrations
{
    public partial class WorkonRTTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RunthroughTask_RunthroughTaskSections_RTTaskSectionId",
                table: "RunthroughTask");

            migrationBuilder.DropForeignKey(
                name: "FK_RunthroughTask_RunthroughTaskStatuses_RTTaskStatusId",
                table: "RunthroughTask");

            migrationBuilder.DropForeignKey(
                name: "FK_RunthroughTask_RunthroughTaskTypes_RTTaskTypeId",
                table: "RunthroughTask");

            migrationBuilder.AlterColumn<int>(
                name: "RTTaskTypeId",
                table: "RunthroughTask",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RTTaskStatusId",
                table: "RunthroughTask",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RTTaskSectionId",
                table: "RunthroughTask",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RunthroughTask_RunthroughTaskSections_RTTaskSectionId",
                table: "RunthroughTask",
                column: "RTTaskSectionId",
                principalTable: "RunthroughTaskSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RunthroughTask_RunthroughTaskStatuses_RTTaskStatusId",
                table: "RunthroughTask",
                column: "RTTaskStatusId",
                principalTable: "RunthroughTaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RunthroughTask_RunthroughTaskTypes_RTTaskTypeId",
                table: "RunthroughTask",
                column: "RTTaskTypeId",
                principalTable: "RunthroughTaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RunthroughTask_RunthroughTaskSections_RTTaskSectionId",
                table: "RunthroughTask");

            migrationBuilder.DropForeignKey(
                name: "FK_RunthroughTask_RunthroughTaskStatuses_RTTaskStatusId",
                table: "RunthroughTask");

            migrationBuilder.DropForeignKey(
                name: "FK_RunthroughTask_RunthroughTaskTypes_RTTaskTypeId",
                table: "RunthroughTask");

            migrationBuilder.AlterColumn<int>(
                name: "RTTaskTypeId",
                table: "RunthroughTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RTTaskStatusId",
                table: "RunthroughTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RTTaskSectionId",
                table: "RunthroughTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_RunthroughTask_RunthroughTaskSections_RTTaskSectionId",
                table: "RunthroughTask",
                column: "RTTaskSectionId",
                principalTable: "RunthroughTaskSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RunthroughTask_RunthroughTaskStatuses_RTTaskStatusId",
                table: "RunthroughTask",
                column: "RTTaskStatusId",
                principalTable: "RunthroughTaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RunthroughTask_RunthroughTaskTypes_RTTaskTypeId",
                table: "RunthroughTask",
                column: "RTTaskTypeId",
                principalTable: "RunthroughTaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
