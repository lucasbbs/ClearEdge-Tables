namespace group_web_application_security.Repository.IRepository
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
