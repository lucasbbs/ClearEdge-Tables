using ClearEdge_Tables.Data;
using ClearEdge_Tables.Models;
using ClearEdge_Tables.Repository.IRepository;
using System.Linq.Expressions;
namespace ClearEdge_Tables.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ClearEdge_TablesContext _context;
        public ShoppingCartRepository(ClearEdge_TablesContext context) :base(context)
        {
            _context = context;
        }
        public void Update(ShoppingCart shoppingCart)
        {
            _context.ShoppingCart.Update(shoppingCart);
        }
    }
}
