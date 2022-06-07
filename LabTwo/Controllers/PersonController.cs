using LabTwo.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabTwo.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            DataAccessLayer dal = new DataAccessLayer();
            List<Person> peopleList = dal.GetPersonInfo();
            return View(peopleList);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Person personInfo)
        {
            DataAccessLayer dal = new DataAccessLayer();
            bool temp = dal.SavePerson(personInfo);
            if (temp == true)
            {
                TempData["Success"] = "Added Sucessfully!!!";
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            DataAccessLayer dal = new DataAccessLayer();
            Person person = dal.people.Where(x => x.Id == id).FirstOrDefault();
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Person newPerson)
        {
            DataAccessLayer dal = new DataAccessLayer();
            bool temp = dal.EditPersonInfo(newPerson);
            if (temp == true)
            {
                TempData["Success"] = "Edited Successfully! UwU";
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            DataAccessLayer dal = new DataAccessLayer();
            dal.DeleteInfo(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            DataAccessLayer dal = new DataAccessLayer();
            Person personDetail = dal.Details(id);
            return View(personDetail);
        }
    }
}
