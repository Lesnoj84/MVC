using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index() //Method that make a list of items and shows on the Index page
        {
            List<Product> products = _unitOfWork.Product.GetAll().ToList();
            
            return View(products);
        }

        public IActionResult Create() //Method that shows the page
        {
            //Provide a selection of a Category items by defining what what type.
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() });

            ViewBag.CategoryList = CategoryList;
           
            return View();

        }

        [HttpPost]
        public IActionResult Create(Product product) //Method that shows the page
        {
            if (product != null)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return NotFound();

        }

        public IActionResult Edit(int id)
        {
            var productFromDb = _unitOfWork.Product.Get(p => p.Id == id);

            if (productFromDb != null || id > 0)
            {
                return View(productFromDb);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {

            if (product != null)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id >= 0)
            {
                var productFromDb = _unitOfWork.Product.Get(p => p.Id == id);
                return View(productFromDb);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            if (product != null)
            {
                _unitOfWork.Product.Remove(product);
                _unitOfWork.Save();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
