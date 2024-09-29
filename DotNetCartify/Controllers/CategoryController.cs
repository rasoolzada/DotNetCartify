using Microsoft.AspNetCore.Mvc;
using Bulky.DataAccess;
using Bulky.Models;
namespace Bulky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataAccess.Data.ApplicationDbContext _db;
        public CategoryController(DataAccess.Data.ApplicationDbContext db) {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategory = _db.Categories.ToList();
            return View(objCategory);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name","Name must not exactly match with Display Order");
            //}
            if (ModelState.IsValid) {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        ///Edit
        public IActionResult Edit(int? Id)
        {
            if (Id == null & Id==0)
            {
                return NotFound();
            }
            Category obj = _db.Categories.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        ///Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null & Id == 0)
            {
                return NotFound();
            }
            Category obj = _db.Categories.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(Category obj)
        {

                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
