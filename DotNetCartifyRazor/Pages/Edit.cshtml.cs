using DotNetCartifyRazor.Data;
using DotNetCartifyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetCartifyRazor.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        public EditModel(ApplicationDbContext db) 
        { 
            _db = db;
        }

        public void OnGet(int? Id)
        {
            if (Id == null & Id == 0)
            {
                 NotFound();
            }
            Category obj = _db.Categories.Find(Id);
            if (obj == null)
            {
                NotFound();
            }
        }
        public IActionResult OnPost(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
