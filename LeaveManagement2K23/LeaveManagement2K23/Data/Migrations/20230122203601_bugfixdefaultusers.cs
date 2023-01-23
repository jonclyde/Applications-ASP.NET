using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagement2K23.Data.Migrations
{
    /// <inheritdoc />
    public partial class bugfixdefaultusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "9100d999-9b07-4670-993c-67eb83cbdccc", null, "User", "USER" },
                    { "9169e2cc-9228-4d8f-b89c-0ca78e26ce18", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataJoined", "DataOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "016f515f-3567-4529-bfa1-da42b0e9ed1a", 0, "cfdf1924-bca2-4afd-84e1-deed6f1ed3e0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@test.com", false, "System", "Admin", false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEKipAnI+yz6+3Zabvlm/vFxUUw6YFMdUG0fTduUMyuMnjrOlqJMM71OyVFvq5y0qnQ==", null, false, "e7e546b0-6977-4bf2-b3ce-e0a029c304c0", null, false, "admin@test.com" },
                    { "016f515f-3567-4529-bfa1-da42b0e9ed1b", 0, "3fbac8d6-bb91-42e6-9c3b-2fa87f75b16a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@test.com", false, "System", "User", false, null, "USER@TEST.COM", "USER@TEST.COM", "AQAAAAIAAYagAAAAEAn9QsrMtQlsbNQ4WxtRgTSjy/lu21wMfpQZsz1s154Clw36SbfKlJkbPJ+nJlJPqw==", null, false, "ad2948e9-76ff-4557-bc19-ba0826b884c3", null, false, "user@test.com" }
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
    }
}
