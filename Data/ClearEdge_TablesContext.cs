using ClearEdge_Tables.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClearEdge_Tables.Data
{
    public class ClearEdge_TablesContext : IdentityDbContext
    {
        public ClearEdge_TablesContext (DbContextOptions<ClearEdge_TablesContext> options)
            : base(options)
        {
        }

        public DbSet<ClearEdge_Tables.Models.Table> Table { get; set; } = default!;
        public DbSet<ClearEdge_Tables.Models.Order> Order { get; set; } = default!;
        public DbSet<ClearEdge_Tables.Models.Customer> Customer { get; set; }
        public DbSet<ClearEdge_Tables.Models.ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ClearEdge_Tables.Models.OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
            );

            modelBuilder.Entity<Table>().HasData(
                new Table
                {
                    Id = 1,
                    Name = "Beautiful Office Desk",
                    Category = "Office Desk",
                    Description = "Modern office desk with wooden finish",
                    Price = 199.99,
                    StockQuantity = 20,
                    Material = "Wood",
                    Color = "Brown",
                    Dimensions = "48x24x30",
                    Weight = 40,
                    Manufacturer = "Office Furn.",
                    Origin_Country = "USA",
                    ImageUrl = "https://th.bing.com/th/id/R.c294eea134f31d6be8df066eecbd9d1f?rik=5tiwzsNCCGjbJQ&pid=ImgRaw&r=0"
                },
                new Table
                {
                    Id = 2,
                    Name = "Nice Dining Table",
                    Category = "Dining Table",
                    Description = "Elegant dining table with glass top",
                    Price = 399.99,
                    StockQuantity = 15,
                    Material = "Glass",
                    Color = "White",
                    Dimensions = "60x36x30",
                    Weight = 60,
                    Manufacturer = "Elegant Furn.",
                    Origin_Country = "ITA",
                    ImageUrl = "https://images.globalindustrial.com/images/pdp/TRADITIONS7PCSW6-alt1.webp?t=1707866000006"
                },
                new Table
                {
                    Id = 3,
                    Name = "Round Coffee Table",
                    Category = "Coffe Table",
                    Description = "Contemporary coffee table with metal legs",
                    Price = 149.99,
                    StockQuantity = 25,
                    Material = "Metal",
                    Color = "Black",
                    Dimensions = "36x24x18",
                    Weight = 30,
                    Manufacturer = "Moda Furn.",
                    Origin_Country = "CHN",
                    ImageUrl = "https://menterarchitects.com/wp-content/uploads/2017/09/elegant-stylish-round-coffee-table-with-storage-dark-brown-finish-throughout-round-coffee-tables-with-drawers.jpg"
                },
                    new Table
                {
                    Id = 4,
                    Name = "Compact Side Table",
                    Category = "Side Table",
                    Description = "Compact bedside table with drawer",
                    Price = 79.99,
                    StockQuantity = 30,
                    Material = "Wood",
                    Color = "Cherry",
                    Dimensions = "20x18x24",
                    Weight = 25,
                    Manufacturer = "Home Basics",
                    Origin_Country = "USA",
                    ImageUrl = "https://th.bing.com/th/id/OIP.ryxkLB0B32IV3CNKfs1RKgHaFj?rs=1&pid=ImgDetMain"
                    },
                new Table
                {
                    Id = 5,
                    Name = "Console Table with Storage",
                    Category = "Console Table",
                    Description = "Modern console table with storage shelves",
                    Price = 299.99,
                    StockQuantity = 10,
                    Material = "Metal/Wood",
                    Color = "Oak",
                    Dimensions = "48x16x30",
                    Weight = 35,
                    Manufacturer = "Trendy Designs",
                    Origin_Country = "CAN",
                    ImageUrl = "https://th.bing.com/th?id=OPHS.amh4zdZ11NPffQ474C474&w=592&h=550&o=5&dpr=1.5&pid=21.1"
                }
            );

            var hasher = new PasswordHasher<Customer>();
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Name = "Admin",
                    Id = "61e5296d-058a-4ea2-a283-69c8a93a407a",
                    UserName = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "secret"),
                    SecurityStamp = string.Empty
                });

            // Assign the admin role to the first admin user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "1", UserId = "61e5296d-058a-4ea2-a283-69c8a93a407a" });
        }
    }
    
}
