using ClearEdge_Tables.Data;
using ClearEdge_Tables.Models;
using ClearEdge_Tables.Repository.IRepository;
using System.Linq.Expressions;
namespace ClearEdge_Tables.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ClearEdge_TablesContext _context;
        public CustomerRepository(ClearEdge_TablesContext context) :base(context)
        {
            _context = context;
        }

        public void Update(Customer customer)
        {
            _context.Update(customer);
        }
    }
}
