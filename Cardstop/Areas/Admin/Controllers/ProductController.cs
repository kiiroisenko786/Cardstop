using Cardstop.DataAccess.Data;
using Cardstop.DataAccess.Repository.iRepository;
using Cardstop.Models;
using Cardstop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        // Assign implementation of ApplicationDbContext to
        // local variable to be used in other action methods
        // Rather than applicationdbcontext, we want an implementation of category repository
        // and ask dependency injection to provide that implementation
        public ProductController(iUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            // Create category object list of database categories
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();
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
                // Get wwwroot path
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                // Check if file is null
                if (file != null)
                {
                    // Generate random name for file + get files extension
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    // Get path inside product folder where file will be saved
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    // If imageurl is not null or empty, there is image url we are uploading a new image because file is not null
                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        // Delete old image
                        // Get path of old image
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));

                        // Check if file exists
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            var defaultPath = Path.Combine(wwwRootPath, @"images\product\awaiting-image.jpg");
                            if (defaultPath != oldImagePath)
                            // Delete file
                            System.IO.File.Delete(oldImagePath);
                        }

                        using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        productVM.Product.ImageUrl = @"\images\product\" + fileName;
                    };
                } else
                {
                    // If imageurl is null, make sure the product doesn't already have an image so it doesn't get replaced by a placeholder
                    // Get path of old image
                    var defaultPath = Path.Combine(wwwRootPath, @"images\product\awaiting-image.jpg");

                    // Line 122 returns null, find a way to prevent this for smooth debugging, otherwise works as intended
                    try
                    {
                        string oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                    }
                    catch (NullReferenceException)
                    {
                        productVM.Product.ImageUrl = @"\images\product\awaiting-image.jpg";
                    }
                }

                // To determine if we are adding or updating a product, we check if the ID is present
                if (productVM.Product.Id == 0)
                {
                    // Add obj to product unitofwork
                    _unitOfWork.Product.Add(productVM.Product);
                    TempData["success"] = "Product created successfully";
                } else
                {
                    // Else update the product
                    _unitOfWork.Product.Update(productVM.Product);
                    TempData["success"] = "Product updated successfully";
                }
                // Save changes to db
                _unitOfWork.Save();
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
            // Save tempdata message for successful product deletion
            TempData["success"] = "Product deleted successfully";
            // Redirect user to index
            return RedirectToAction("Index");
        }

        // API call area
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new {data = objProductList});
        }

        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(u => u.Id == id);

            if (productToBeDeleted == null)
            {
                return Json(new {success = false, message = "Error white deleting"});
            }

            if (productToBeDeleted.ImageUrl == null)
            {
                _unitOfWork.Product.Remove(productToBeDeleted);
            } else
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));

                // Check if file exists
                if (System.IO.File.Exists(oldImagePath))
                {
                    // Get wwwrootpath, delete image if its not the default image
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if (Path.Combine(wwwRootPath, @"images\product\awaiting-image.jpg") != oldImagePath)
                    // Delete file
                    System.IO.File.Delete(oldImagePath);
                }

                _unitOfWork.Product.Remove(productToBeDeleted);

            }

            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion

    }
}
