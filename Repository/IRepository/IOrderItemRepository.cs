using group_web_application_security.Models;

namespace group_web_application_security.Repository.IRepository
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        void Update(OrderItem orderItem);
    }
}
