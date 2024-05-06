using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index() //Method that make a list of items and shows on the Index page
        {
            List<Product> productsList = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();

            return View(productsList);
        }

        public IActionResult CreateOrUpdate(int? id) //Method that shows the page
        {
            //Creating ProductVM so we can pass several parameters from different classes.
            ProductVM productVM = new ProductVM
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.Product.Get(p => p.Id == id);
                return View(productVM);
            }
        }

        [HttpPost] //Method that shows the page
        public IActionResult CreateOrUpdate(ProductVM productVM, IFormFile? file) //IFormFile needs to be if using one page for Create and Update.
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\product");

                if (!string.IsNullOrEmpty(productVM.Product.ImageURL))
                {
                    var oldImgPath = Path.Combine(wwwRootPath, productVM.Product.ImageURL.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImgPath))
                    {
                        System.IO.File.Delete(oldImgPath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                productVM.Product.ImageURL = @"\images\product\" + fileName;


                if (productVM.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                }
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() });
                _unitOfWork.Product.Update(productVM.Product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }


        }

        //public IActionResult Edit(int id)
        //{
        //    var productFromDb = _unitOfWork.Product.Get(p => p.Id == id);

        //    if (productFromDb != null || id > 0)
        //    {
        //        return View(productFromDb);
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //public IActionResult Edit(Product product)
        //{

        //    if (product != null)
        //    {
        //        _unitOfWork.Product.Update(product);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Category updated successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

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
