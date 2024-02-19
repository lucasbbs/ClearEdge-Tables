using group_web_application_security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace group_web_application_security.Data
{
    public class group_web_application_securityContext : IdentityDbContext
    {
        public group_web_application_securityContext (DbContextOptions<group_web_application_securityContext> options)
            : base(options)
        {
        }

        public DbSet<group_web_application_security.Models.Table> Table { get; set; } = default!;
        public DbSet<group_web_application_security.Models.Order> Order { get; set; } = default!;
        public DbSet<group_web_application_security.Models.Customer> Customer { get; set; }
        public DbSet<group_web_application_security.Models.ShoppingCart> ShoppingCart { get; set; }
        public DbSet<group_web_application_security.Models.OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
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
