using ClearEdge_Tables.Models;

namespace ClearEdge_Tables.Repository.IRepository
{
    public interface ITableRepository: IRepository<Table>
    {
        void Update(Table table);
    }
}
