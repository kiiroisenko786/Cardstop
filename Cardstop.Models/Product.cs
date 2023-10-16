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
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [DisplayName("Type")]
        public string CardType { get; set; }
        public string? Attribute { get; set; }
        public string? Type1 { get; set; }
        public string? Type2 { get; set; }
        public string? Type3 { get; set; }
        [DisplayName("List Price")]
        public int ListPrice { get; set; }


    }
}
