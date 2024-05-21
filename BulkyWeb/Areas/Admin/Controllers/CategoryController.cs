using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Ultility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles =SD.Role_Admin)]
public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }

    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();

        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category obj)
    {


        if (obj.Name == obj.DisplayOrder.ToString()) ModelState.AddModelError("name", "Name and Order can not be the same.");

        ModelState.Remove("Id");
        if (obj != null && ModelState.IsValid) //ModelState.IsValid controlls if Category validation is valid.
        {
            _unitOfWork.Category.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index"); //return RedirectToAction("Index",Category); or other controller if needed.

        }
        return View();
    }


    public IActionResult Edit(int? id)
    {
        var categoryFromDb = _unitOfWork.Category.Get(x => x.Id == id);

        if (id == null || id == 0 || categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }

    [HttpPost] // Important without it the page wont know what method to use => ERROR
    public IActionResult Edit(Category obj)
    {

        if (obj.Name == obj.DisplayOrder.ToString()) ModelState.AddModelError("name", "Name and Order can not be the same.");

        if (obj != null && ModelState.IsValid) //ModelState.IsValid controlls if Category validation is valid.
        {
            _unitOfWork.Category.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index"); //return RedirectToAction("Index",Category); or other controller if needed.

        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        var categoryFromDb = _unitOfWork.Category.Get(c => c.Id == id);

        if (id == null || id == 0 || categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }

    [HttpPost] // Important without it the page wont know what method to use => ERROR
    public IActionResult Delete(Category obj)
    {
        _unitOfWork.Category.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index"); //return RedirectToAction("Index",Category); or other controller if needed.
    }


}
