using Microsoft.EntityFrameworkCore.Migrations;

namespace organisation.Data.Migrations
{
    public partial class AddStatustoGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "OrgGoals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrgGoals");
        }
    }
}
