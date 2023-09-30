using GlimseCrafts.Website.Data;
using GlimseCrafts.Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlimseCrafts.Website.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContest _db;

        public CategoryController(ApplicationDBContest db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.Categories.ToList();
            return View(categoryList);
        }
    }
}
