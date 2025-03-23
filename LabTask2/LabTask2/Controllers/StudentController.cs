using System;
using System.Web.Mvc;

using LabTask2.Models;

namespace LabTask2.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                TempData["StudentName"] = student.Name;
                return RedirectToAction("Welcome");
            }
            return View(student);
        }

        public ActionResult Welcome()
        {
            ViewBag.StudentName = TempData["StudentName"];
            return View();
        }
    }
}
