using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cardstop.DataAccess.Repository.iRepository
{
    /* Typically when working with generics, we don't know what the class type will be,
     * so we call it a generic class T, where T will be a class.
     * So when the iRepository is implemented, we will know what type the class will be.
     * Because there is currently category, but there will be Product, and other tables,
     * which is why this is generic.
    */
    public interface iRepository<T> where T : class
    {
        // T = Category, or any other generic model on which we want to perform CRUD
        // or rather want to interact with DbContext

        // In the case of T being Category, we list the operations we need when
        // performing CRUD operations on Category

        // Get all categories
        IEnumerable<T> GetAll(string? includeProperties = null);

        // Retrieve only one category
        // Find method only works on the ID, if you want another condition, you can pass it using
        // linq
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);

        // Add Category
        void Add(T entity);

        // Update Category
        //void Update(T entity);
        // Typically the Update(obj) method like in EFCore is more complicated because
        // sometimes you may only want to update a few properties or you have some other logic
        // Because of that Update and SaveChanges are kept out of the repository and when
        // CategoryRepository implements the generic repository, on there we will have Update
        // and SaveChanges methods, so we will keep Update Category out

        // Delete Category
        void Remove(T entity);

        // Delete multiple entities in column
        void RemoveRange(IEnumerable<T> entities);
    }
}
