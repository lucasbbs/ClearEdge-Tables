using group_web_application_security.Data;
using group_web_application_security.Models;
using group_web_application_security.Repository.IRepository;
using System.Linq.Expressions;
namespace group_web_application_security.Repository
{
    public class TableRepository : Repository<Table>, ITableRepository
    {
        private readonly group_web_application_securityContext _context;
        public TableRepository(group_web_application_securityContext context) :base(context)
        {
            _context = context;
        }
        public void Update(Table table)
        {
            _context.Table.Update(table);
        }
    }
}
