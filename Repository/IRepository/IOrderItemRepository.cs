using ClearEdge_Tables.Models;

namespace ClearEdge_Tables.Repository.IRepository
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        void Update(OrderItem orderItem);
    }
}
