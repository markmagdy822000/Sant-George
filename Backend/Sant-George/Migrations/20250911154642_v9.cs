using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sant_George.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "Class", "Email", "Location", "NormalizedEmail", "PasswordHash" },
                values: new object[] { 2000, "markmagdy@gmail.com", "", "MARKMAGDY@GMAIL.COM", "AQAAAAIAAYagAAAAEPcrEYTAjgSZAVIsmv+n5O2GXtUfnEF1OdR2LFZBKP3nVhlwnvj/MkZt/cbLTZlDPA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "Class", "Email", "NormalizedEmail", "PasswordHash" },
                values: new object[] { 1, "markmagdy822000@gmail.com", "MARKMAGDY822000@GMAIL.COM", "AQAAAAIAAYagAAAAEIGNJmDYCXgbjEfhYxHzHuprZ7oZqCkRSS8njQI5MknzmZDzFBiABkkzz85gQwXFkw==" });
        }
    }
}
