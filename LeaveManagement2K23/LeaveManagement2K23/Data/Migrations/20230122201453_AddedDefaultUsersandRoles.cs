using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagement2K23.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultUsersandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9100d999-9b07-4670-993c-67eb83cbdccc", null, "User", "USER" },
                    { "9169e2cc-9228-4d8f-b89c-0ca78e26ce18", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataJoined", "DataOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "016f515f-3567-4529-bfa1-da42b0e9ed1a", 0, "121d93e5-d08e-4b23-89ad-28b1e7867ef2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@test.com", false, "System", "Admin", false, null, "ADMIN@TEST.COM", null, "AQAAAAIAAYagAAAAEDU3iCee/ME5u3l07oozd3PGV5RV/RbJDbe5YkPnPU0kBP3yt3MJKQAfOwTiYz0mPQ==", null, false, "93116aa1-7275-449b-9cfd-61699535ef50", null, false, null },
                    { "016f515f-3567-4529-bfa1-da42b0e9ed1b", 0, "9a305f49-cfb7-448f-acc3-0fa40d84bad3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@test.com", false, "System", "User", false, null, "USER@TEST.COM", null, "AQAAAAIAAYagAAAAEGusHe1ieSG1t4dVE0Dj+n/ZbnhANymuxrlvXi8rh3k3MTBxYdmPjrjzCyPOtBcwWw==", null, false, "93b91d45-22c3-4fdf-82dc-f61de58af2ad", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9169e2cc-9228-4d8f-b89c-0ca78e26ce18", "016f515f-3567-4529-bfa1-da42b0e9ed1a" },
                    { "9100d999-9b07-4670-993c-67eb83cbdccc", "016f515f-3567-4529-bfa1-da42b0e9ed1b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9169e2cc-9228-4d8f-b89c-0ca78e26ce18", "016f515f-3567-4529-bfa1-da42b0e9ed1a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9100d999-9b07-4670-993c-67eb83cbdccc", "016f515f-3567-4529-bfa1-da42b0e9ed1b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9100d999-9b07-4670-993c-67eb83cbdccc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9169e2cc-9228-4d8f-b89c-0ca78e26ce18");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "016f515f-3567-4529-bfa1-da42b0e9ed1a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "016f515f-3567-4529-bfa1-da42b0e9ed1b");
        }
    }
}
