using CardstopRazor_Temp.Data;
using CardstopRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardstopRazor_Temp.Pages.Categories
{
    /* When working with razor pages, if we want the category property to be
     available when posting, we need to use the BindProperty attribute
     BindProperties can be used for multiple properties */
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        // Create category since we will be working with a single category
        public Category Category { get; set; }
        // Assign db to local variable to use
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            /* With the Category property binded, no args are needed as it
             can be directly accessed as it will now be populated 
             When working with razor pages, we must explicitly bind properties
             that we want to access in the POST of the form */
            _db.Categories.Add(Category);
            TempData["success"] = "Category created successfully";
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
