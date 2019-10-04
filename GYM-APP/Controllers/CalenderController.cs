using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
using GYM_APP.Models;

namespace GYM_APP.Controllers
{
    public class Calender: Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Backend()
        {
            return new Dpc().CallBack(this);
        }

        class Dpc : DayPilotCalendar
        {
            private ApplicationDbContext db = new ApplicationDbContext();

            protected override void OnInit(InitArgs e)
            {
                Update(CallBackUpdateType.Full);
            }

            //protected override void OnEventResize(EventResizeArgs e)
            //{
            //    var toBeResized = (from ev in db.Calender where ev.Id == Convert.ToInt32(e.Id) select ev).First();
            //    toBeResized.Eventstart = e.NewStart;
            //    toBeResized.Eventend = e.NewEnd;
            //    db.SubmitChanges();
            //    Update();
            //}

            //protected override void OnEventMove(EventMoveArgs e)
            //{
            //    var toBeResized = (from ev in db.Calender where ev.Id == Convert.ToInt32(e.Id) select ev).First();
            //    toBeResized.Eventstart = e.NewStart;
            //    toBeResized.Eventend = e.NewEnd;
            //    db.SubmitChanges();
            //    Update();
            //}

            protected override void OnTimeRangeSelected(TimeRangeSelectedArgs e)
            {
            //    var toBeCreated = new Calender
            //    {

            //        var toBeCreated = new Event {eventstart = e.Start, eventend = e.End, text = (string) e.Data["name"]};
            //    db.Calender.InsertOnSubmit(toBeCreated);
            //    db.SubmitChanges();
            //    Update();
            //}
            //    db.Calender.InsertOnSubmit(toBeCreated);
            //    db.SubmitChanges();
            //    Update();
            //}

            //protected override void OnFinish()
            //{
            //    if (UpdateType == CallBackUpdateType.None)
            //    {
            //        return;
            //    }

            //    Events = from ev in db.Calender select ev;

            //    DataIdField = "id";
            //    DataTextField = "text";
            //    DataStartField = "eventstart";
            //    DataEndField = "eventend";
            }
        }
    }
}
