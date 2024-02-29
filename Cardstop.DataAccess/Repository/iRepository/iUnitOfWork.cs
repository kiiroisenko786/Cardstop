using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardstop.DataAccess.Repository.iRepository
{
    public interface iUnitOfWork
    {
        iCategoryRepository Category { get; }
        iProductRepository Product { get; }
        iCompanyRepository Company { get; }
        iShoppingCartRepository ShoppingCart { get; }

        void Save();
    }
}
