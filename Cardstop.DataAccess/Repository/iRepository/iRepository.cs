using System;
using System.Collections.Generic;
using System.Linq;
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
    internal interface iRepository<T> where T : class
    {

    }
}
