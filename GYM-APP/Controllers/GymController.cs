using GYM_APP.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GYM_APP.Controllers
{
    public class GymController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Gym
        public ActionResult Index(int id)
        {
            Gym gym = db.Gym.Where(c => c.Id == id).Single();
            return View();
        }

        // GET: Gym/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym gym = db.Gym.Find(id);
            if (gym == null)
            {
                return HttpNotFound();
            }
            
            return RedirectToAction("Details");

        }

        // GET: Gym/Create
        public ActionResult Create()
         {


            ViewBag.ApplicationId = new SelectList(db.Gym, "Id", "Email");
            return View();
        }

        // POST: Gym/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,UserName,StreetAddress,City,State,ZipCode,")] Gym gym)
        {
            var currentUserId = User.Identity.GetUserId();
            gym.ApplicationUserId = currentUserId;
            gym.UserRoles = User.Identity.GetUserName();
            if (gym.ApplicationUserId == currentUserId)
            {
                db.Gym.Add(gym);
                db.SaveChanges();
                return RedirectToAction("Index","Gym", new { id = gym.Id });
            }
            return View (gym);
        }

        // GET: Gym/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gym gym = db.Gym.Where(c => c.Id == id).Single();
            if (gym == null)
            {
                return HttpNotFound();
            }
            return View(gym);
        }

        // POST: Gym/Edit/5
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

        // GET: Gym/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gym/Delete/5
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
