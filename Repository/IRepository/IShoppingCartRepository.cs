using ClearEdge_Tables.Models;

namespace ClearEdge_Tables.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart shoppingCart);
    }
}
