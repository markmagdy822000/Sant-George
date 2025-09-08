using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sant_George_Website.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Class", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "91d316c6-4b7b-4a88-b2f5-e170d82e8576", 0, "102 El-Qubai St. El-Zaher", 2000, "39a6071f-88f1-4c9c-8afa-802a46b974d7", "markmagdyamin@gmail.com", true, 0, false, null, null, null, "123A", "01284417081", false, "e102d61c-cb23-4206-84cc-7a3b4b391a4c", false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91d316c6-4b7b-4a88-b2f5-e170d82e8576");
        }
    }
}
