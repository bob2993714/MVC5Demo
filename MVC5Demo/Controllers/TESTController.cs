using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class TESTController : Controller
    {
        static List<Person> data = new List<Person>() {
            new Person() { Id = 1, Name = "Mark", Age = 18 },
            new Person() { Id = 2, Name = "Bob", Age = 19 },
            new Person() { Id = 3, Name = "Jack", Age = 20 },
            new Person() { Id = 4, Name = "Kobe", Age = 21 }
        };

        // GET: TEST
        public ActionResult Index()
        {

            return View(data);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            person.Id = data.OrderByDescending(o => o.Id).Select(s => s.Id).FirstOrDefault() + 1;
            if (ModelState.IsValid)
            {
                data.Add(person);

                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult Edit(int id)
        {
            return View(data.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Person person)
        {
            if (ModelState.IsValid)
            {
                var one = data.FirstOrDefault(p => p.Id == id);
                one.Name = person.Name;
                one.Age = person.Age;

                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult Details(int id)
        {

            return View(data.FirstOrDefault(p => p.Id == id));
        }

        public ActionResult Delete(int id)
        {

            return View(data.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            data.Remove(data.FirstOrDefault(e => e.Id == id));

            return RedirectToAction("Index");
        }
    }
}