using ClearEdge_Tables.Data;
using ClearEdge_Tables.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClearEdge_Tables.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ClearEdge_TablesContext _context;
        internal DbSet<T> Set;
        public Repository(ClearEdge_TablesContext context)
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
