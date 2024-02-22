using ClearEdge_Tables.Models;

namespace ClearEdge_Tables.Models.ViewModels
{
    public class ShoppingCartViewModel 
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }

        public Order Order { get; set; }
    }
}