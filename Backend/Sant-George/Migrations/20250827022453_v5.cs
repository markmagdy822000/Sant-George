using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sant_George.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "Address", "Class", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber" },
                values: new object[] { "Cairo", 1, "markmagdy822000@gmail.com", "MARKMAGDY822000@GMAIL.COM", "MARKMAGDY", "AQAAAAIAAYagAAAAELAuHLEmnacMfvBy8EUxy+aaeeAEV0pxzidHD7MJJJ5dW+z57LMTXdcmrr+l5im14w==", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "Address", "Class", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber" },
                values: new object[] { "102 El-Qubai St. El-Zaher", 2000, "markmagdyamin@gmail.com", null, null, "123A", "01284417081" });
        }
    }
}
