﻿using System;
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
        iApplicationUserRepository ApplicationUser { get; }
        iOrderDetailRepository OrderDetail { get; }
        iOrderHeaderRepository OrderHeader { get; }
        iProductImageRepository ProductImage { get; }

        void Save();
    }
}
