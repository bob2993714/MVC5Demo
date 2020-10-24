﻿using MVC5Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class DepartmentController : Controller
    {
        ContosoUniversityEntities db = new ContosoUniversityEntities();

        // GET: Department
        public ActionResult Index()
        {
            return View(db.Department.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Department.Add(department);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName");

            return View(department);
        }

        public ActionResult Edit(int? id)
        {
            if( !id.HasValue)
            {
                return HttpNotFound();
            }
            var item = db.Department.Find(id);
            if( item == null )
            {
                return HttpNotFound();
            }

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName", item.InstructorID);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                var item = db.Department.Find(id);
                item.Name = department.Name;
                item.Budget = department.Budget;
                item.StartDate = department.StartDate;
                item.InstructorID = department.InstructorID;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            var dept = db.Department.Find(id);

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName", dept.InstructorID);

            return View(department);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var item = db.Department.Find(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }
            var item = db.Department.Find(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Department.Find(id);
            db.Department.Remove(department);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}