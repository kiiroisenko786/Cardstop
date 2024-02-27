using Cardstop.DataAccess.Data;
using Cardstop.DataAccess.Repository.iRepository;
using Cardstop.Models;
using Cardstop.Models.ViewModels;
using Cardstop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.Generic;

namespace Cardstop.Controllers
{
    // To tell the controller that it belongs to a specific area
    // we use the Area attribute tag
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        // Changed now that iCompanyRepository is being used
        private readonly iUnitOfWork _unitOfWork;

        // Assign implementation of ApplicationDbContext to
        // local variable to be used in other action methods
        // Rather than applicationdbcontext, we want an implementation of category repository
        // and ask dependency injection to provide that implementation
        public CompanyController(iUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            // Create category object list of database categories
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            // Return the list to the index view, when returning view, can only
            // pass one arg 
            return View(objCompanyList);
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
            
            // If there is no id -> Create
            if (id==null || id == 0)
            {
                return View(new Company());
            } else
            {
                // Update because id is present
                // Retrieve Company using Get + LINQ operation
                Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }
        }

        // HTTPPOST invoked for POST operations (form sending)
        // Create method is given Company obj from the form
        // Also changed to Upsert
        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            // Check if the category modelstate is valid
            if (ModelState.IsValid)
            {
                // To determine if we are adding or updating a Company, we check if the ID is present
                if (CompanyObj.Id == 0)
                {
                    // Add obj to Company unitofwork
                    _unitOfWork.Company.Add(CompanyObj);
                    TempData["success"] = "Company created successfully";
                } else
                {
                    // Else update the Company
                    _unitOfWork.Company.Update(CompanyObj);
                    TempData["success"] = "Company updated successfully";
                }
                // Save changes to db
                _unitOfWork.Save();
                // Redirect user to Index
                return RedirectToAction("Index");
            } else
            {
                return View(CompanyObj);
            }  
        }

        // Explicit declaration of this endpoints action name is "delete" despite method name
        // being different, to differentiate it from the GET action method
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            // Find category (can be nullable)
            Company? obj = _unitOfWork.Company.Get(u=>u.Id==id);
            // If category is null
            if (obj == null)
            {
                // Return NotFound
                return NotFound();
            }
            // Otherwise remove the obj from categories
            _unitOfWork.Company.Remove(obj);
            // Save changes to db
            _unitOfWork.Save();
            // Save tempdata message for successful Company deletion
            TempData["success"] = "Company deleted successfully";
            // Redirect user to index
            return RedirectToAction("Index");
        }

        // API call area
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new {data = objCompanyList});
        }

        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);

            if (CompanyToBeDeleted == null)
            {
                return Json(new {success = false, message = "Error white deleting"});
            }

            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion

    }
}
