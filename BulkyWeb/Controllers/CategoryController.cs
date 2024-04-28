using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers;


public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;

    }

    public IActionResult Index()
    {
        List<Category> objCategoryList = _db.Categories.ToList();

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
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index"); //return RedirectToAction("Index",Category); or other controller if needed.

        }
        return View();
    }


    public IActionResult Edit(int? id)
    {
        var categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);

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
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index"); //return RedirectToAction("Index",Category); or other controller if needed.

        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        var categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);

        if (id == null || id == 0 || categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }

    [HttpPost] // Important without it the page wont know what method to use => ERROR
    public IActionResult Delete(Category obj)
    {
        _db.Categories.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index"); //return RedirectToAction("Index",Category); or other controller if needed.
    }


}
