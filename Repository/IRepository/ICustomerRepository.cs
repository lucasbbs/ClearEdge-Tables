using ClearEdge_Tables.Models;

namespace ClearEdge_Tables.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public void Update(Customer customer);
    }
}
