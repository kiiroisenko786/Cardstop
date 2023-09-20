using CardstopRazor_Temp.Data;
using CardstopRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardstopRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        // Create applicationdbcontext
        private readonly ApplicationDbContext _db;
        // Create category list
        public List<Category> CategoryList { get; set; }
        // Assign db to local variable to use
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            // Add all db categories to list and assign
            CategoryList = _db.Categories.ToList();
        }
    }
}
