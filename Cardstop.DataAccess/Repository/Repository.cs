using Cardstop.DataAccess.Data;
using Cardstop.DataAccess.Repository.iRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cardstop.DataAccess.Repository
{
    // When implementing the generic iRepository, the class Repository needs to be
    // generic as well
    public class Repository<T> : iRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            // When we create the generic class on categories, the dbSet will be set to categories
            this.dbSet = _db.Set<T>();
            // _db.Categories == dbSet essentially
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            // Assign dbSet to query
            IQueryable<T> query = dbSet;
            // Assign query to query with a where condition with filter
            query = query.Where(filter);
            // Return single category back
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            // Assign dbSet to query
            IQueryable<T> query = dbSet;
            // Return all categories
            return query.ToList();
        }

        public void Remove(T entity)
        {
            // Remove category from dbSet
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            // Remove range of categories from dbSet
            dbSet.RemoveRange(entities);
        }
    }
}
