using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace group_web_application_security.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnImageToTableTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Table",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Table");
        }
    }
}
