using group_web_application_security.Models;

namespace group_web_application_security.Repository.IRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public void Update(Customer customer);
    }
}
