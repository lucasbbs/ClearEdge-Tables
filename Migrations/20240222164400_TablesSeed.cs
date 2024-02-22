using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClearEdge_Tables.Migrations
{
    /// <inheritdoc />
    public partial class TablesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Table",
                columns: new[] { "Id", "Category", "Color", "Description", "Dimensions", "ImageUrl", "Manufacturer", "Material", "Name", "Origin_Country", "Price", "StockQuantity", "Weight" },
                values: new object[,]
                {
                    { 1, "Office Desk", "Brown", "Modern office desk with wooden finish", "48x24x30", "https://th.bing.com/th/id/R.c294eea134f31d6be8df066eecbd9d1f?rik=5tiwzsNCCGjbJQ&pid=ImgRaw&r=0", "Office Furn.", "Wood", "Beautiful Office Desk", "USA", 199.99000000000001, 20, 40.0 },
                    { 2, "Dining Table", "White", "Elegant dining table with glass top", "60x36x30", "https://images.globalindustrial.com/images/pdp/TRADITIONS7PCSW6-alt1.webp?t=1707866000006", "Elegant Furn.", "Glass", "Nice Dining Table", "ITA", 399.99000000000001, 15, 60.0 },
                    { 3, "Coffe Table", "Black", "Contemporary coffee table with metal legs", "36x24x18", "https://menterarchitects.com/wp-content/uploads/2017/09/elegant-stylish-round-coffee-table-with-storage-dark-brown-finish-throughout-round-coffee-tables-with-drawers.jpg", "Moda Furn.", "Metal", "Round Coffee Table", "CHN", 149.99000000000001, 25, 30.0 },
                    { 4, "Side Table", "Cherry", "Compact bedside table with drawer", "20x18x24", "https://th.bing.com/th/id/OIP.ryxkLB0B32IV3CNKfs1RKgHaFj?rs=1&pid=ImgDetMain", "Home Basics", "Wood", "Compact Side Table", "USA", 79.989999999999995, 30, 25.0 },
                    { 5, "Console Table", "Oak", "Modern console table with storage shelves", "48x16x30", "https://th.bing.com/th?id=OPHS.amh4zdZ11NPffQ474C474&w=592&h=550&o=5&dpr=1.5&pid=21.1", "Trendy Designs", "Metal/Wood", "Console Table with Storage", "CAN", 299.99000000000001, 10, 35.0 },
                    { 6, "Dining Table", "Walnut", "Space-saving dining table that can be folded", "42x42x30", "https://assets.wfcdn.com/im/65618480/compr-r85/1711/171159538/47-rectangular-folding-dining-table.jpg", "SpaceSaver", "Wood", "Foldable Dining Table", "GBR", 299.99000000000001, 10, 50.0 },
                    { 7, "Office Desk", "Silver", "Desk with adjustable height for ergonomic comfort", "60x30x28", "https://i5.walmartimages.com/asr/b92290d2-6409-495a-8ed1-82bb15c7e8ce.bd4d752f4ee48044b2df33b48504b511.jpeg", "ErgoFurn", "Metal/Wood", "Adjustable Height Desk", "DEU", 249.99000000000001, 15, 45.0 },
                    { 8, "Picnic Table", "Green", "Sturdy picnic table for outdoor gatherings", "72x60x28", "https://barcoproducts.sirv.com/magento/catalog/product/P/T/PT-54.jpg?q=80&canvas.width=100.0000%25&canvas.height=100.0000%25&canvas.color=ffffff&w=500&h=0&scale.option=fill", "Outdoor Essentials", "Plastic", "Outdoor Picnic Table", "FRA", 199.99000000000001, 8, 70.0 },
                    { 9, "Coffee Table", "Chrome", "Sleek coffee table with minimalist design", "40x24x18", "https://th.bing.com/th/id/OIP.vmkIrsWljBavb1l5zb4U2AHaHa?rs=1&pid=ImgDetMain", "ModernLiving", "Metal/Glass", "Modern Coffee Table", "ESP", 179.99000000000001, 20, 35.0 },
                    { 10, "Dining Table", "Distressed White", "Rustic farmhouse dining table with distressed finish", "72x42x30", "https://assets.wfcdn.com/im/40787303/resize-h445%5Ecompr-r85/1225/122579962/Alena+Extendable+Dining+Table.jpg", "Rustic Charm", "Wood", "Rustic Farmhouse Table", "CAN", 449.99000000000001, 12, 80.0 }

                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
