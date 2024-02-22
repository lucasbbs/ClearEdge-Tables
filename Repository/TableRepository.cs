using ClearEdge_Tables.Data;
using ClearEdge_Tables.Models;
using ClearEdge_Tables.Repository.IRepository;
using System.Linq.Expressions;
namespace ClearEdge_Tables.Repository
{
    public class TableRepository : Repository<Table>, ITableRepository
    {
        private readonly ClearEdge_TablesContext _context;
        public TableRepository(ClearEdge_TablesContext context) :base(context)
        {
            _context = context;
        }
        public void Update(Table table)
        {
            _context.Table.Update(table);
        }
    }
}
