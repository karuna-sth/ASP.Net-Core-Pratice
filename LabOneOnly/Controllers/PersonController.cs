using LabOneOnly.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabOneOnly.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            List<Person> peopleList = BusinessService.peopleList;
            return View(peopleList);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Person personInfo)
        {
            List<Person> peopleList = BusinessService.peopleList;
            peopleList.Add(personInfo);
            TempData["Success"] = "Added Sucessfully!!!";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            List<Person> peopleList = BusinessService.peopleList;
            Person person = peopleList.Where(x => x.Id == id).FirstOrDefault();
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Person newPerson)
        {
            List<Person> peopleList = BusinessService.peopleList;
            Person person = peopleList.Where(x => x.Id == newPerson.Id).FirstOrDefault();
            person.Name = newPerson.Name;
            person.Address = newPerson.Address;
            person.Qualification = newPerson.Qualification;
            person.MaritialStatus = newPerson.MaritialStatus;
            TempData["Success"] = "Edited Sucessfully!!!";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            List<Person> peopleList = BusinessService.peopleList;
            Person person = peopleList.Where(x => x.Id == id).FirstOrDefault();
            peopleList.Remove(person);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            List<Person> peopleList = BusinessService.peopleList;
            Person person = peopleList.Where(x => x.Id == id).FirstOrDefault();
            return View(person);
        }
    }
}
