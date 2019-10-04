using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GYM_APP.Models;
//using DayPilot.Web.Mvc;
//using DayPilot.Web.Mvc.Enums;
//using DayPilot.Web.Mvc.Events.Calendar;

namespace GYM_APP.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index(int id)
        {
            Customer customer = db.Customer.Where(c => c.Id == id).Single();
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
           
            return View(customer);
            
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationId = new SelectList(db.Gym, "Id", "Email");
            return View();
        }
            
        

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,StreetAddress,City,State,ZipCode,")] Customer customer)
        {
            var currentUserId = User.Identity.GetUserId();
            customer.ApplicationUserId = currentUserId;
            customer.UserRoles = User.Identity.GetUserName();
            if (customer.ApplicationUserId == currentUserId)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = customer.Id });
            }

            return View(customer);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Where(c => c.Id == id).Single();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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

        ////public ActionResult Backend()
        ////{
        ////    return new Dpc().CallBack(this);
        ////}

        ////class Dpc : DayPilotCalendar
        ////{
        ////    protected override void OnInit(InitArgs e)
        ////    {
        ////        var db = new DataClasses1DataContext();
        ////        Events = from ev in db.events select ev;

        ////        DataIdField = "id";
        ////        DataTextField = "text";
        ////        DataStartField = "eventstart";
        ////        DataEndField = "eventend";

        ////        Update();
        //    }
        //}
    }

}
