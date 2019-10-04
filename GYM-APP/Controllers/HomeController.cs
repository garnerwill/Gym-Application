using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYM_APP.Models;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;

namespace GYM_APP.Controllers

{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        


        public ActionResult Index(string username)
        {
            if (User.IsInRole("Customer"))
            {
                Customer customer = db.Customer.FirstOrDefault(c => c.UserName == username);
                return RedirectToAction("Index", "Customer", new { id = customer.Id });
            }
            if (User.IsInRole("Gym"))
            {
                Gym gym = db.Gym.FirstOrDefault(e => e.UserName == username);
                return RedirectToAction("Index", "Gym", new { id = gym.Id });
            }
            if (User.IsInRole("Instructor"))
            {
                Instructor instructor = db.Instructor.FirstOrDefault(e => e.UserName == username);
                return RedirectToAction("Index", "Instructor", new { id = instructor.Id });
            }
            else
            {
                return View();
            }
        }
            public ActionResult About()
            {
               ViewBag.Message = "Your application description page.";

              return View();

            }
                
            
        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
   
        
    
    }


}