using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Ultility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(string? SearchString = null) //Method that make a list of items and shows on the Index page
        {
            List<Company> CompanysList = _unitOfWork.Company.GetAll().ToList();
            return View(CompanysList);
        }

        [HttpPost]
        public IActionResult Refresh()
        {
            List<Company> CompanysList = _unitOfWork.Company.GetAll(includeProperties: "Category").ToList();

            return RedirectToAction("Index", CompanysList);
        }
        public IActionResult CreateOrUpdate(int? id) //Method that shows the page
        {
            //Creating CompanyVM so we can pass several parameters from different classes.

            if (id == null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                Company company = _unitOfWork.Company.Get(p => p.Id == id);
                return View(company);
            }
        }

        [HttpPost] //Method that shows the page
        public IActionResult CreateOrUpdate(Company company)
        {
            if (company.Id == 0)
            {
                _unitOfWork.Company.Add(company);
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                _unitOfWork.Company.Update(company);
                _unitOfWork.Save();
                TempData["success"] = "Company updated successfully";
                return RedirectToAction("Index");
            }

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var CompanyFromDb = _unitOfWork.Company.Get(p => p.Id == id);

            if (CompanyFromDb != null)
            {
                _unitOfWork.Company.Remove(CompanyFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Company deleted successfully";

                return Json(new { success = true, message = "Company deleted successfully" });

            }
            else
            {
                return View(CompanyFromDb);

            }
        }

        #region API Calls
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Company> Companys = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = Companys });
        }

        #endregion
    }
}
