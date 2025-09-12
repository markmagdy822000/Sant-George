using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sant_George.Migrations
{
    /// <inheritdoc />
    public partial class v16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StarteDate",
                table: "Exams",
                newName: "StartDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Exams",
                newName: "StarteDate");
        }
    }
}
