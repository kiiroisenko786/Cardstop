﻿using Cardstop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardstop.DataAccess.Repository.iRepository
{
    public interface iCompanyRepository : iRepository<Company>
    {
        void Update(Company company);
    }
}
