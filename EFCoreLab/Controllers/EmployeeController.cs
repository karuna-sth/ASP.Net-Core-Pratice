using EFCoreLab.Entity;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreLab.Controllers
{
    public class EmployeeController : Controller
    {
        public EntityDAL _context;
        public EmployeeController(EntityDAL context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            TempData["Success"] = "Created New Successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View(_context.Employee);
        }
        public IActionResult Edit(int id)
        {
            return View(_context.Employee.Where (a => a.EmployeeId == id).FirstOrDefault());
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            _context.Employee.Update(emp);
            _context.SaveChanges();
            TempData["Success"] = "Edited And Updated Successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Employee emp = _context.Employee.Where(a => a.EmployeeId == id).FirstOrDefault();
            _context.Employee.Remove(emp);
            _context.SaveChanges();
            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Employee emp = _context.Employee.Where(a => a.EmployeeId == id).FirstOrDefault();
            return View(emp);
        }
    }
}
