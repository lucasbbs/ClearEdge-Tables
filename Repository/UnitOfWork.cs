using ClearEdge_Tables.Data;
using ClearEdge_Tables.Models;
using ClearEdge_Tables.Repository.IRepository;

namespace ClearEdge_Tables.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ClearEdge_TablesContext _context;
        public ITableRepository Table { get; private set; }
        public ICustomerRepository Customer {  get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IOrderItemRepository OrderItem { get; private set; }
        public UnitOfWork(ClearEdge_TablesContext context)
        {
            _context = context;
            ShoppingCart = new ShoppingCartRepository(_context);
            Table = new TableRepository(_context);
            Customer = new CustomerRepository(_context);
            Order = new OrderRepository(_context);
            OrderItem = new OrderItemRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
