using Cardstop.DataAccess.Data;
using Cardstop.DataAccess.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardstop.DataAccess.Repository
{
    public class UnitOfWork : iUnitOfWork
    {
        private ApplicationDbContext _db;
        public iCategoryRepository Category { get; private set; }
        public iProductRepository Product { get; private set; }
        public iCompanyRepository Company{ get; private set; }

        public iShoppingCartRepository ShoppingCart { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
        }

        /* The save method which was previously in CategoryRepository would have been in all the individual repositories down the road, like product/order but the save functionality
         * is not relevant to the repository or the model. It is a global method that is being used, and so it is correct to have it in this separate class known as UnitOfWork, but is not always required, but gives a cleaner approach.
         */
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
