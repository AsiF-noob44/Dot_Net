using System.Linq;
using System.Web.Mvc;
using ClassTask1.EF;

namespace ClassTask1.Controllers
{
    public class ProductController : Controller
    {
        private ProductManagementEntities1 db = new ProductManagementEntities1();

        // GET: Product
        public ActionResult Index()
        {
            var data = db.Products.Include("Category").ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (product.Qty <= 0)
            {
                ModelState.AddModelError("Qty", "Quantity must be greater than 0.");
                ViewBag.Categories = db.Categories.ToList();
                return View(product);
            }

            db.Products.Add(product);
            db.SaveChanges();
            TempData["Msg"] = "Product Added";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = db.Categories.ToList();
            var data = db.Products.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var existingProduct = db.Products.Find(product.Id);

            
            if (product.Qty <= 0)
            {
                ModelState.AddModelError("Qty", "Quantity must be greater than 0.");
                ViewBag.Categories = db.Categories.ToList();
                return View(product);
            }

          
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Qty = product.Qty;
            existingProduct.Cid = product.Cid;

            db.SaveChanges();
            TempData["Msg"] = "Product Updated";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Products.Find(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            TempData["Msg"] = "Product Deleted";
            return RedirectToAction("Index");
        }
    }
}