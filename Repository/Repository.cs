using group_web_application_security.Data;
using group_web_application_security.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace group_web_application_security.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly group_web_application_securityContext _context;
        internal DbSet<T> Set;
        public Repository(group_web_application_securityContext context)
        {
            _context = context;
            this.Set = _context.Set<T>();
        }

        public void Add(T entity)
        {
            Set.Add(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>>? filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query = Set;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }
 
        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> ? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = Set;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var include in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            Set.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            Set.RemoveRange(entity);
        }
    }
}
