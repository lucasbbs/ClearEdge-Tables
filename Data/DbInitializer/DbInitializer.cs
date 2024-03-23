using ClearEdge_Tables.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClearEdge_Tables.Data.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ClearEdge_TablesContext _context;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ClearEdge_TablesContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0) {
                    _context.Database.Migrate();
                }
            }catch (Exception ex)
            {}

            if (!_roleManager.RoleExistsAsync("User").GetAwaiter().GetResult() )
            {
                _roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            }
            _userManager.CreateAsync(new Customer
            {
                UserName = "admin@example.com",
                Email = "admin@example.com",
                Name = "Admin",
                PhoneNumber = "+1 (226) 724 7739",
                StreetAddress = "2741, Sierra Drive",
                State = "Ontario",
                PostalCode = "23422",
                City = "Windsor"
            }, "Secret123@").GetAwaiter().GetResult();

            Customer user = _context.Customer.FirstOrDefault(c => c.Email == "admin@example.com");
             _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();

            return;
        }
    }
}
