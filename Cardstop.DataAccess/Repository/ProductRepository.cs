using Cardstop.DataAccess.Data;
using Cardstop.DataAccess.Repository.iRepository;
using Cardstop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cardstop.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, iProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            // As the update method will update the imageurl again even if it already exists, it can be helpful, though not necessary to be explicit so it only updates imageurl if imageurl is null
            // First retrieve object by Id received
            var objFromDb = _db.Products.FirstOrDefault(u=>u.Id == obj.Id);
            // Check if the object is not null
            if (objFromDb != null)
            {
                // Manually update each field
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.ProductCode = obj.ProductCode;
                objFromDb.ProductStock = obj.ProductStock;
                // Then check if imageurl is not null
                if (obj.ImageUrl != null)
                {
                    // Only then update imageurl so it isn't updated when its unchanged
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
