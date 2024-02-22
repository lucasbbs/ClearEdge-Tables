using ClearEdge_Tables.Data;
using ClearEdge_Tables.Models;
using ClearEdge_Tables.Repository.IRepository;
using System.Linq.Expressions;
namespace ClearEdge_Tables.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ClearEdge_TablesContext _context;
        public OrderRepository(ClearEdge_TablesContext context) :base(context)
        {
            _context = context;
        }
        public void Update(Order order)
        {
            _context.Order.Update(order);
        }
    }
}
