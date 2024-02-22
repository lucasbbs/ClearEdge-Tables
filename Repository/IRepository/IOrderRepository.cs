using ClearEdge_Tables.Models;

namespace ClearEdge_Tables.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order order);
    }
}
