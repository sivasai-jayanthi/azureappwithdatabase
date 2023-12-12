using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolClassLibrary;
using schoolproject.Models;

namespace schoolproject.Controllers
{
    public class schoolController : Controller
    {
		// GET: school
		schoolClassLibrary.schooldbEntities db = new schooldbEntities();
		public ActionResult Index()
		{
			
			List<student> students = db.students.ToList();
			List<studentmodel> studentlist = new List<studentmodel>();
			foreach (var item in students)
			{
				studentmodel model = new studentmodel();
				model.id = item.id;
				model.name = item.name;
				model.address = item.address;
				model.email = item.email;

				studentlist.Add(model);


			}

			return View(studentlist);
		}

		// GET: school/Details/5
		public ActionResult Details(int id)
        {
          student c = db.students.Find(id);
			studentmodel model = new studentmodel();
            model.id = c.id;
            model.name = c.name;
            model.address = c.address;
            model.email = c.email;


			return View(model);
        }

        // GET: school/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: school/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                
				studentmodel model = new studentmodel();
                model.id=Convert.ToInt32(collection["id"]);
                model.name=collection["name"].ToString();
                model.address=collection["address"].ToString();
                model.email=collection["email"].ToString();


                student s = new student();
                s.id = model.id;
                s.name = model.name;
                s.address = model.address;
                s.email = model.email;
                db.students.Add(s);

                db.SaveChanges();
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: school/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: school/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: school/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: school/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
