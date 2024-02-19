using group_web_application_security.Models;

namespace group_web_application_security.Repository.IRepository
{
    public interface ITableRepository: IRepository<Table>
    {
        void Update(Table table);
    }
}
