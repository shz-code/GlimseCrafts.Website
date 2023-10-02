using GlimseCrafts.Website.Data;
using GlimseCrafts.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlimseCrafts.Website.Controllers
{
    public class CategoryController : Controller
    {
        // Get the application model instance
        private readonly ApplicationDBContest _db;

        // Get the database instance from the dependency injection
        public CategoryController(ApplicationDBContest db)
        {
            _db = db;
        }
        // Show all the categories
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categoryList = await _db.Categories.ToListAsync();
            return View(categoryList);
        }
        /*
         * 
         * @params Id of the catogory to show details
        */
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var category = await _db.Categories.FindAsync(id);
            return View(category);
        }
        /*
         * 
         * @params Id of the catogory to edit
        */
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _db.Categories.FindAsync(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("Id","Name","Description","Created")] Category category)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _db.Update(category);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name","Description","Created")] Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Add(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _db.Categories.FindAsync(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if(category != null)
            {
                _db.Remove(category);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
