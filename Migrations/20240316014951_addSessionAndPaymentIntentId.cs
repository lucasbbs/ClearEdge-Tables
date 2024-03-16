using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClearEdge_Tables.Migrations
{
    /// <inheritdoc />
    public partial class addSessionAndPaymentIntentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentIntentId",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentIntentId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Order");
        }
    }
}
