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
            // _db.Categories is basically the same as dbSet
            // Category field will automatically be populated when it retrieves the products via the foreign key relation
            _db.Products.Include(u => u.Category).Include(u=>u.CategoryId);

        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            // Assign dbSet to query
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }

            // Assign query to query with a where condition with filter
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            // Return single category back
            return query.FirstOrDefault();
        }

        // Nullable variable to include properties in the query
        // If there are more than 1 props to include our repository is dynamic to handle it as a comma separated list
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null)
        {
            // Assign dbSet to query
            IQueryable<T> query = dbSet;
            if(filter!=null) { query = query.Where(filter); }
            // Check if includeProperties is null or empty (are we including props in the query)
            if(!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                { 
                    query = query.Include(includeProp);
                }
            }
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
