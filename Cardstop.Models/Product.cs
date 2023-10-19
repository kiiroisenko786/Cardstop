using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardstop.Models
{
    public class Product
    {
        // ID of product
        [Key]
        public int Id { get; set; }
        // Product name
        [Required]
        public string Name { get; set; }
        // Product description
        [Required]
        public string Description { get; set; }
        [Required]
        [DisplayName("List Price")]
        [Range(0.01, Double.MaxValue, ErrorMessage = "List price must be more than £0.00")]
        public int ListPrice { get; set; }


    }
}
