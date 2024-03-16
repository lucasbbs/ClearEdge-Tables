namespace ClearEdge_Tables.Models.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<OrderItem> OrderItem { get; set; }

    }
}
