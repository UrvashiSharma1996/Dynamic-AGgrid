using Dynamic_AGgrid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace Dynamic_AGgrid.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext context;

        public HomeController(StudentDbContext context)//ctor - Para constru
        {
            this.context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var data = context.Students.ToList();
            return new JsonResult(data);
        }


        [HttpPost]

        public ActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                context.Students?.Add(std);
                context.SaveChanges();
                TempData["insert_success"] = "Inserted..";
                return RedirectToAction("Index", "Home");
            }
            return View(std);

        }
        public ActionResult EditEmployee(int id, Student edited)
        {
            Student emp = context.Students.Find(id);

            if (emp == null) { return View(); }

            emp.Name = edited.Name;
            emp.Rollno = edited.Rollno;
            emp.Section = edited.Section;
            emp.Branch = edited.Branch;
            emp.ContactNo = edited.ContactNo;

            //context.Employees.Add(emp);
            //context.Update(emp);
            //context.Attach(emp);
            context.SaveChanges();
            return new JsonResult(edited);
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var model = context.Students.Find(Id);
            if (model != null)
            {
                context.Students.Remove(model);
                context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}