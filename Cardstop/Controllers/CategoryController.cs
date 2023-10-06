using Cardstop.DataAccess.Data;
using Cardstop.DataAccess.Repository.iRepository;
using Cardstop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cardstop.Controllers
{
    public class CategoryController : Controller
    {
        // Changed now that iCategoryRepository is being used
        private readonly iCategoryRepository _categoryRepo;
        
        // Assign implementation of ApplicationDbContext to
        // local variable to be used in other action methods
        // Rather than applicationdbcontext, we want an implementation of category repository
        // and ask dependency injection to provide that implementation
        public CategoryController(iCategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            // Create category object list of database categories
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            // Return the list to the index view
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        // HTTPPOST invoked for POST operations (form sending)
        // Create method is given Category obj from the form
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.name == obj.displayorder.tostring())
            //{
            //    modelstate.addmodelerror("name", "the name cannot match the display order");
            //}

            // Check if the category modelstate is valid
            if (ModelState.IsValid)
            {
                // Add obj to DbSet of categories
                _categoryRepo.Add(obj);
                // Save changes to db
                _categoryRepo.Save();
                // Create tempdata message for successful category creation
                TempData["success"] = "Category created successfully";
                // Redirect user to Index
                return RedirectToAction("Index");
            }
            return View();
        }

        // Create action method for edit, taking the id of the category
        // Int ID can be nullable, as it will be validated
        public IActionResult Edit(int? id)
        {
            // Check if null or 0 (min ID is 1)
            if(id==null ||  id==0)
            {
                // Return not found
                return NotFound();
            }
            
            // Find category in _db categories using Find method to find by ID
            // Category can be nullable as it will be validated
            Category? categoryFromDb = _categoryRepo.Get(u=>u.Id==id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            // Check if category is null
            if (categoryFromDb == null)
            {
                // Return not found
                return NotFound();
            }
            // Return view with the category retrieved from the db
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                // This time to update, the Update method is used to update the given category
                _categoryRepo.Update(obj);
                //  Save changes to db
                _categoryRepo.Save();
                // Save tempdata message for successful category update
                TempData["success"] = "Category updated successfully";
                // Return to index
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u=>u.Id==id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // Explicit declaration of this endpoints action name is "delete" despite method name
        // being different, to differentiate it from the GET action method
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            // Find category (can be nullable)
            Category? obj = _categoryRepo.Get(u=>u.Id==id);
            // If category is null
            if (obj == null)
            {
                // Return NotFound
                return NotFound();
            }
            // Otherwise remove the obj from categories
            _categoryRepo.Remove(obj);
            // Save changes to db
            _categoryRepo.Save();
            // Save tempdata message for successful category deletion
            TempData["success"] = "Category deleted successfully";
            // Redirect user to index
            return RedirectToAction("Index");
        }
    }
}
