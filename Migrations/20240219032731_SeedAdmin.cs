using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClearEdge_Tables.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "State", "StreetAddress", "TwoFactorEnabled", "UserName", "isAdmin" },
            //    values: new object[] { "61e5296d-058a-4ea2-a283-69c8a93a407a", 0, null, "917c3a46-725f-4387-a20f-1aeef9226244", "Customer", "admin@example.com", true, false, null, "Admin", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAELH/LNhcKFdxA2oMpcX84EcSPJEEXFFY83pzZMxptYOqSX542oEzIqL6M6MGNRMDFA==", null, false, null, "", null, null, false, "admin@example.com", true });

            //migrationBuilder.InsertData(
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[] { "1", "61e5296d-058a-4ea2-a283-69c8a93a407a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "1", "61e5296d-058a-4ea2-a283-69c8a93a407a" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "61e5296d-058a-4ea2-a283-69c8a93a407a");
        }
    }
}
