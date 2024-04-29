using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (id == null || category == null)
            {
                return NotFound();
            }
            
            Category = category;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Category.Name==Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("category.name","Name can not be the same as Order");
               
            }

            _db.Attach(Category).State = EntityState.Modified;

            if (ModelState.IsValid)
            {
                TempData["success"] = "Updated successfuly";
                await _db.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
        
    }
}
