using System.Linq;
using System.Web.Mvc;
using ClassTask1.EF;

namespace ClassTask1.Controllers
{
    public class CategoryController : Controller
    {
        private ProductManagementEntities1 db = new ProductManagementEntities1();

        // GET: Category
        public ActionResult Index()
        {
            var data = db.Categories.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            TempData["Msg"] = "Category Added";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Categories.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            var existingCategory = db.Categories.Find(category.Id);
            existingCategory.Name = category.Name;
            db.SaveChanges();
            TempData["Msg"] = "Category Updated";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Categories.Find(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            TempData["Msg"] = "Category Deleted";
            return RedirectToAction("Index");
        }
    }
}