using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CardstopRazor_Temp.Models
{
    public class Category
    {
        // Create Id as primary key
        [Key]
        public int Id { get; set; }

        // Create Name to display category name
        [Required]
        [MaxLength(50)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        // Create display order with range validation
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
