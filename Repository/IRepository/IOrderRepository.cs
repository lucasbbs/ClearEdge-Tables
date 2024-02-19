using group_web_application_security.Models;

namespace group_web_application_security.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order order);
    }
}
