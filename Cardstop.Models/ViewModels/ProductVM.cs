using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardstop.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        // CategoryList is the same as in the product controller
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
