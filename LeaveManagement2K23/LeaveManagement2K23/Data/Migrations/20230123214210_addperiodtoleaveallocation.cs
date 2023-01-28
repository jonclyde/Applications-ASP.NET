using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement2K23.Data.Migrations
{
    /// <inheritdoc />
    public partial class addperiodtoleaveallocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "915c2592-291a-40eb-b7cd-8197fac675cc", "AQAAAAIAAYagAAAAEJ/PAEg+LaKyli7n4xuFeCj6eHUSV+9nI0MsVuqek6dKiTpBibl/7f95bwpOAPIibw==", "4adeddc5-126a-4359-90fb-e8901ce7c290" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f00d76db-a886-4981-a19c-ba0302195b94", "AQAAAAIAAYagAAAAEAi7jWZJtu2orf9zV/3RNR2K6M79j81IYJjs0eSba49R4aFwq82qztjqJdM1MC7ltg==", "9d147b64-2acc-43fd-bc44-cf07d9439495" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0eb1c18e-2b07-415b-a25b-a03a7c41a14d", "AQAAAAIAAYagAAAAELG0JuknuJ4XBDNn99qKF4Atoa1gCgAl6jOfJoHiKZrE3DGW2Oipqb3N8GTuKICWhg==", "d7ea5b08-4b46-4cdd-8d93-3acb9c7dd0bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f091005-a0bf-4c46-b989-9bece42b072e", "AQAAAAIAAYagAAAAEEWtqQN547iHivqYq3ZcIhJxbdT1yM6r4oWOdwOlbLrYoDctDQPuHXVOegknKxPiRQ==", "e43235ec-92fa-4c62-b5f5-f6b3e1681a1f" });
        }
    }
}
