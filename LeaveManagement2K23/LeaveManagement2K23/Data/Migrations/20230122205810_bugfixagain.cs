using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagement2K23.Data.Migrations
{
    /// <inheritdoc />
    public partial class bugfixagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin12-f7bb-4448-baaf-1add431ccbbf", "6d77d78b9d7d-1c3e-449d-f66e1234" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user12-f7bb-4448-baaf-1acd431ddbbf", "f66e1234-1c3e-449d-80c7-6d77d7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin12-f7bb-4448-baaf-1add431ccbbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user12-f7bb-4448-baaf-1acd431ddbbf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d77d78b9d7d-1c3e-449d-f66e1234");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e1234-1c3e-449d-80c7-6d77d7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "r120303a-bf81-4802-bd34-a90f17ac61ca", null, "Administrator", "ADMINISTRATOR" },
                    { "r220303a-bf81-4802-bd34-a90f17ac61ca", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataJoined", "DataOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a1e4d073-2b6a-4ad1-9fb2-3ab393b62f46", 0, "0eb1c18e-2b07-415b-a25b-a03a7c41a14d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@test.com", true, "System", "Admin", false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAELG0JuknuJ4XBDNn99qKF4Atoa1gCgAl6jOfJoHiKZrE3DGW2Oipqb3N8GTuKICWhg==", null, false, "d7ea5b08-4b46-4cdd-8d93-3acb9c7dd0bb", null, false, "admin@test.com" },
                    { "u1e4d073-2b6a-4ad1-9fb2-3ab393b62f46", 0, "1f091005-a0bf-4c46-b989-9bece42b072e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@test.com", true, "System", "User", false, null, "USER@TEST.COM", "USER@TEST.COM", "AQAAAAIAAYagAAAAEEWtqQN547iHivqYq3ZcIhJxbdT1yM6r4oWOdwOlbLrYoDctDQPuHXVOegknKxPiRQ==", null, false, "e43235ec-92fa-4c62-b5f5-f6b3e1681a1f", null, false, "user@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "r120303a-bf81-4802-bd34-a90f17ac61ca", "a1e4d073-2b6a-4ad1-9fb2-3ab393b62f46" },
                    { "r220303a-bf81-4802-bd34-a90f17ac61ca", "u1e4d073-2b6a-4ad1-9fb2-3ab393b62f46" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "r120303a-bf81-4802-bd34-a90f17ac61ca", "a1e4d073-2b6a-4ad1-9fb2-3ab393b62f46" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "r220303a-bf81-4802-bd34-a90f17ac61ca", "u1e4d073-2b6a-4ad1-9fb2-3ab393b62f46" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "r120303a-bf81-4802-bd34-a90f17ac61ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "r220303a-bf81-4802-bd34-a90f17ac61ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1e4d073-2b6a-4ad1-9fb2-3ab393b62f46");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1e4d073-2b6a-4ad1-9fb2-3ab393b62f46");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin12-f7bb-4448-baaf-1add431ccbbf", null, "Administrator", "ADMINISTRATOR" },
                    { "user12-f7bb-4448-baaf-1acd431ddbbf", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataJoined", "DataOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d77d78b9d7d-1c3e-449d-f66e1234", 0, "0a2e4945-5af4-464f-a2b2-d70c7dc5a457", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@test.com", true, "System", "Admin", false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEEoAP5oKJ4xEN4w9sMWkJF3Q6/YNBGFT1sdQTC8Rnb5Bw36Gir5oTRpva0LbbEioRg==", null, false, "4eadecd5-22d1-4c4f-9c28-d3fcaf993850", null, false, "admin@test.com" },
                    { "f66e1234-1c3e-449d-80c7-6d77d7", 0, "9160538a-eded-4aed-a3c4-4c02d02d6e70", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@test.com", true, "System", "User", false, null, "USER@TEST.COM", "USER@TEST.COM", "AQAAAAIAAYagAAAAENZEnOiTHjzHeit3QCjpCxYCkef8HTF1/Q4TSQpoIEh0LAKDydnhiiyAG19FdFhTDA==", null, false, "4e8af1bc-17a4-4b43-adb4-0c6b426e2a35", null, false, "user@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "admin12-f7bb-4448-baaf-1add431ccbbf", "6d77d78b9d7d-1c3e-449d-f66e1234" },
                    { "user12-f7bb-4448-baaf-1acd431ddbbf", "f66e1234-1c3e-449d-80c7-6d77d7" }
                });
        }
    }
}
