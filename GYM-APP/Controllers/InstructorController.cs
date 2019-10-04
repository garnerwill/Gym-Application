using GYM_APP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GYM_APP.Controllers
{
    public class InstructorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Instructor
        public ActionResult Index(int id)
        {
            Instructor instructor = db.Instructor.Where(c => c.Id == id).Single();
            return View();
        }

        // GET: Instructor/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructor.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }

            return View(instructor);

        }

        // GET: Instructor/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationId = new SelectList(db.Instructor, "Id", "Email");
            return View();
        }



        // POST: Instructor/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,StreetAddress,City,State,ZipCode,Ratings,Certifications")] Instructor instructor)
        {
            var currentUserId = User.Identity.GetUserId();
            instructor.ApplicationUserId = currentUserId;
            instructor.UserName = User.Identity.GetUserName();
            if (instructor.ApplicationUserId == currentUserId)
            {
                db.Instructor.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = instructor.Id });
            }

            return View(instructor);
        }

        // GET: Instructor/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructor.Where(c => c.Id == id).Single();
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructor/Edit/5
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

        // GET: Instructor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Instructor/Delete/5
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
