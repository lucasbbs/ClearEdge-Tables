namespace ClearEdge_Tables.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITableRepository Table { get; }
        IShoppingCartRepository ShoppingCart { get; }
        ICustomerRepository Customer { get; }
        IOrderRepository Order { get; }
        IOrderItemRepository OrderItem { get; }
        void Save();
    }
}
