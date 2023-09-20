using CardstopRazor_Temp.Data;
using CardstopRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardstopRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        // Create category since we will be working with a single category
        public Category Category { get; set; }
        // Assign db to local variable to use
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(Category.Id);
            // If category is null
            if (obj == null)
            {
                // Return NotFound
                return NotFound();
            }
            // Otherwise remove the obj from categories
            _db.Categories.Remove(obj);
            // Save changes to db
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
