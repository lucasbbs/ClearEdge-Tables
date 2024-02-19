using group_web_application_security.Data;
using group_web_application_security.Models;
using group_web_application_security.Repository.IRepository;
using System.Linq.Expressions;
namespace group_web_application_security.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly group_web_application_securityContext _context;
        public ShoppingCartRepository(group_web_application_securityContext context) :base(context)
        {
            _context = context;
        }
        public void Update(ShoppingCart shoppingCart)
        {
            _context.ShoppingCart.Update(shoppingCart);
        }
    }
}
