using group_web_application_security.Data;
using group_web_application_security.Models;
using group_web_application_security.Repository.IRepository;
using System.Linq.Expressions;
namespace group_web_application_security.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly group_web_application_securityContext _context;
        public OrderRepository(group_web_application_securityContext context) :base(context)
        {
            _context = context;
        }
        public void Update(Order order)
        {
            _context.Order.Update(order);
        }
    }
}
