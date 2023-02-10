using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement2K23.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedrequestcomments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6ce8205-b011-474c-8f7a-e80f0a1148b4", "AQAAAAIAAYagAAAAEGwMyE/rHrDJmqcWGp5+QXJAMBjYw3/hdHlUa/ZPUAO89P75ClqlY9v4KsGlOhTWTw==", "05c26068-08ff-41c9-8d64-cdd82a50ad5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85695ba8-ad32-4ac7-86b1-f79a1a6285f5", "AQAAAAIAAYagAAAAEC/DY4/KFal67tJuY9YbCeknywoVcDOlvzYZU1uhzutrJ0dPlntNTJF4jNeU6M/IIw==", "0ab8e553-f75d-4a86-ac9c-a9560800ef04" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
