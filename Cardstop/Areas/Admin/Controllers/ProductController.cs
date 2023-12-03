using Cardstop.DataAccess.Data;
using Cardstop.DataAccess.Repository.iRepository;
using Cardstop.Models;
using Cardstop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Cardstop.Controllers
{
    // To tell the controller that it belongs to a specific area
    // we use the Area attribute tag
    [Area("Admin")]
    public class ProductController : Controller
    {
        // Changed now that iProductRepository is being used
        private readonly iUnitOfWork _unitOfWork;
        
        // Assign implementation of ApplicationDbContext to
        // local variable to be used in other action methods
        // Rather than applicationdbcontext, we want an implementation of category repository
        // and ask dependency injection to provide that implementation
        public ProductController(iUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            // Create category object list of database categories
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            // Return the list to the index view, when returning view, can only
            // pass one arg 
            return View(objProductList);
        }

        // Can give any name, and the name will act as a key value where key is CategoryList and value is whatever is assigned i.e CategoryList
        //ViewBag.CategoryList = CategoryList;
        // ViewData access method differs to ViewBag
        // Typically should avoid using ViewData and ViewBag as much as possible
        // as it can get ugly when there are too many, so bind the view to the object
        // If the object is not a simple object, can make a combination of objects called ViewModel which is a model that is specific for a view
        // Create renamed to Upsert to combine Update + Insert (Create)
        // Upsert may have an Id, if creating then no Id, if updating then Id
        public IActionResult Upsert(int? id)
        {    
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            // If there is no id -> Create
            if (id==null || id == 0)
            {
                return View(productVM);
            } else
            {
                // Update because id is present
                // Retrieve product using Get + LINQ operation
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
        }

        // HTTPPOST invoked for POST operations (form sending)
        // Create method is given Product obj from the form
        // Also changed to Upsert
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            // Check if the category modelstate is valid
            if (ModelState.IsValid)
            {
                // Add obj to DbSet of categories
                _unitOfWork.Product.Add(productVM.Product);
                // Save changes to db
                _unitOfWork.Save();
                // Create tempdata message for successful category creation
                TempData["success"] = "Product created successfully";
                // Redirect user to Index
                return RedirectToAction("Index");
            } else
            {
                // Ensures population of dropdown to prevent exception screen
                // When POSTing, if errors are encountered the dropdown will not be populated, resulting in an exception
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }  
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u=>u.Id==id);
            //Product? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Product? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        // Explicit declaration of this endpoints action name is "delete" despite method name
        // being different, to differentiate it from the GET action method
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            // Find category (can be nullable)
            Product? obj = _unitOfWork.Product.Get(u=>u.Id==id);
            // If category is null
            if (obj == null)
            {
                // Return NotFound
                return NotFound();
            }
            // Otherwise remove the obj from categories
            _unitOfWork.Product.Remove(obj);
            // Save changes to db
            _unitOfWork.Save();
            // Save tempdata message for successful category deletion
            TempData["success"] = "Product deleted successfully";
            // Redirect user to index
            return RedirectToAction("Index");
        }
    }
}
