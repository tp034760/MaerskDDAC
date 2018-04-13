using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maersk_DDAC.Models;

namespace Maersk_DDAC.Controllers
{
    public class MaerskAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult RegisterAgent()
        {
            return View();
        }

        public ActionResult AdminSchedule()
        {
            return View(db.Schedules.ToList());
        }

        public ActionResult AdminManage()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var ShipList = db.Ships.Select(c => new SelectListItem
            {
                Value = c.ShipID.ToString(),
                Text = c.ShipName,
            });

            var DockList = db.Docks.Select(c => new SelectListItem
            {
                Value = c.DockID.ToString(),
                Text = c.DockName,
            });
            var model = new SelectViewModel
            {
                ShipList = ShipList.AsEnumerable(),
                DockList = DockList.AsEnumerable()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AdminManage(SelectViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.Schedules.Any(r =>
                r.DepartureTime <= model.Schedule.DepartureTime && r.ArrivalTime >= model.Schedule.ArrivalTime && r.Ship.ShipID == model.ShipID ||
                r.DepartureTime <= model.Schedule.ArrivalTime && r.ArrivalTime >= model.Schedule.DepartureTime &&r.Ship.ShipID == model.ShipID))
                {
                    TempData["shipbooked"] = "true";
                    TempData["msg"] = "<script>alert('Cannot create schedule because ship is being booked at this time');</script>";
                    return RedirectToAction("AdminHome");
                }



                db.Schedules.Add(new Schedule
                {
                    Ship = db.Ships.FirstOrDefault(r => r.ShipID == model.ShipID),
                    Departure = db.Docks.FirstOrDefault(r => r.DockID == model.DepartureID),
                    Arrival = db.Docks.FirstOrDefault(r => r.DockID == model.ArrivalID),
                    BayLeft = model.Schedule.BayLeft,
                    ArrivalTime = model.Schedule.ArrivalTime,
                    DepartureTime = model.Schedule.DepartureTime
                });
                db.SaveChanges();
                return RedirectToAction("AdminHome");
            }

            return View(model);
        }


    }
}