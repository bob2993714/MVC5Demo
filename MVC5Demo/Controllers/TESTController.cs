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
        // GET: TEST
        public ActionResult Index()
        {
            var data = new List<Person>()
            {
                new Person() { Id = 1, Name = "Mark", Age = 18 },
                new Person() { Id = 2, Name = "Bob", Age = 19 },
                new Person() { Id = 3, Name = "Jack", Age = 20 },
                new Person() { Id = 4, Name = "Kobe", Age = 21 }
            };

            return View(data);
        }
    }
}