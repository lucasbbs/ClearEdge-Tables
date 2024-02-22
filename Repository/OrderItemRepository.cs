using ClearEdge_Tables.Data;
using ClearEdge_Tables.Models;
using ClearEdge_Tables.Repository.IRepository;
using System.Linq.Expressions;
namespace ClearEdge_Tables.Repository
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly ClearEdge_TablesContext _context;
        public OrderItemRepository(ClearEdge_TablesContext context) :base(context)
        {
            _context = context;
        }
        public void Update(OrderItem orderItem)
        {
            _context.OrderItem.Update(orderItem);
        }
    }
}
