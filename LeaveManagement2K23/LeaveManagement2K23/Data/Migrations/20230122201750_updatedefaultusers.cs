using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement2K23.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedefaultusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "016f515f-3567-4529-bfa1-da42b0e9ed1a",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "cfdf1924-bca2-4afd-84e1-deed6f1ed3e0", "ADMIN@TEST.COM", "AQAAAAIAAYagAAAAEKipAnI+yz6+3Zabvlm/vFxUUw6YFMdUG0fTduUMyuMnjrOlqJMM71OyVFvq5y0qnQ==", "e7e546b0-6977-4bf2-b3ce-e0a029c304c0", "admin@test.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "016f515f-3567-4529-bfa1-da42b0e9ed1b",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3fbac8d6-bb91-42e6-9c3b-2fa87f75b16a", "USER@TEST.COM", "AQAAAAIAAYagAAAAEAn9QsrMtQlsbNQ4WxtRgTSjy/lu21wMfpQZsz1s154Clw36SbfKlJkbPJ+nJlJPqw==", "ad2948e9-76ff-4557-bc19-ba0826b884c3", "user@test.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "016f515f-3567-4529-bfa1-da42b0e9ed1a",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "121d93e5-d08e-4b23-89ad-28b1e7867ef2", null, "AQAAAAIAAYagAAAAEDU3iCee/ME5u3l07oozd3PGV5RV/RbJDbe5YkPnPU0kBP3yt3MJKQAfOwTiYz0mPQ==", "93116aa1-7275-449b-9cfd-61699535ef50", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "016f515f-3567-4529-bfa1-da42b0e9ed1b",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9a305f49-cfb7-448f-acc3-0fa40d84bad3", null, "AQAAAAIAAYagAAAAEGusHe1ieSG1t4dVE0Dj+n/ZbnhANymuxrlvXi8rh3k3MTBxYdmPjrjzCyPOtBcwWw==", "93b91d45-22c3-4fdf-82dc-f61de58af2ad", null });
        }
    }
}
