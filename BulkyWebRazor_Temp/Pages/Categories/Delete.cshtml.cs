using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Categories.FirstOrDefault(u=>u.Id==id);
        }

        public IActionResult OnPost()
        {
            if (Category != null)
            {
                _db.Categories.Remove(Category);
                TempData["success"] = "Deleted successfuly";
                _db.SaveChanges();

                return RedirectToPage("Index");
            }
            return NotFound();

        }
        
    }
}
