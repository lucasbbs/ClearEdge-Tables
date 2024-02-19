using group_web_application_security.Models;

namespace group_web_application_security.Models.ViewModels
{
    public class ShoppingCartViewModel 
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }

        public Order Order { get; set; }
    }
}