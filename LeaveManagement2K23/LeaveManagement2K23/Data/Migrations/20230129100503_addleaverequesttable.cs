using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement2K23.Data.Migrations
{
    /// <inheritdoc />
    public partial class addleaverequesttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa2dd901-7637-4538-b3db-3000704d82a4", "AQAAAAIAAYagAAAAEJ7JcMr0GmBJq8JkC1Ol/ZsMfPeUO/JrBYtimnVUNM4dqYo62ENQLNy/DonMJDgGxQ==", "36e9ca2c-c5b3-4188-9090-5c60e2e8ccb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f37b4d54-fd00-4b5c-8588-88b06301176c", "AQAAAAIAAYagAAAAEJ27aZch9WpJ8KAiVnxvNITxcLcywqLaLfmfTA40nhwuhv06u8NElvpiyyQhlSVNCg==", "1fe14178-f69c-461d-a557-38bac4041d18" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e9b6fd2-ec48-4ebd-8f6b-88afd2155dde", "AQAAAAIAAYagAAAAECDGNhHuf07HKOdnjfR6ufC+yEasJtqaBXxVsONY4vcF3yO8kq0d+Sa5FxR8lRSqNg==", "b2f0744c-f374-421e-9417-68d6c89b0654" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2a51899-de39-4440-a3fa-d22844909058", "AQAAAAIAAYagAAAAEMDYV8zM+TsXD2l3vFIEBoufbR3ItLFBSpjkKEMVko6TGDrGEuuQb7NfHe2sCGD7eQ==", "fb1fa5d0-0bfb-44d7-a5ad-441a44612270" });
        }
    }
}
