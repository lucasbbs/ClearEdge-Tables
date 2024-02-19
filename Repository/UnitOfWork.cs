using group_web_application_security.Data;
using group_web_application_security.Models;
using group_web_application_security.Repository.IRepository;

namespace group_web_application_security.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private group_web_application_securityContext _context;
        public ITableRepository Table { get; private set; }
        public ICustomerRepository Customer {  get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IOrderItemRepository OrderItem { get; private set; }
        public UnitOfWork(group_web_application_securityContext context)
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
