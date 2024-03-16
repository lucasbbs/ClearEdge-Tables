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

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var order = _context.Order.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                order.Status = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    order.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentId(int id, string sessionId, string stripePaymentId)
        {
            var order = _context.Order.FirstOrDefault(o => o.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
            {
                order.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(stripePaymentId))
            {
                order.PaymentDate = DateTime.Now;
                order.PaymentIntentId = stripePaymentId;
            }
        }
    }
}
