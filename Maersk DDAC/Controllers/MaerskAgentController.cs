using Maersk_DDAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Maersk_DDAC.Controllers
{
    public class MaerskAgentController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: MaerskAgent
        public ActionResult AgentHome()
        {
            return View();
        }

        public ActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCustomer(Customer model)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(new Customer
                {
                    CustomerName = model.CustomerName,
                });
                db.SaveChanges();
                return RedirectToAction("AgentHome");
            }
            return View(model);
        }

        public ActionResult RegisterGoods()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterGoods(Good model)
        {
            if (ModelState.IsValid)
            {
                db.Goods.Add(new Good
                {
                    GoodName = model.GoodName,
                });
                db.SaveChanges();
                return RedirectToAction("AgentHome");
            }
            return View(model);
        }

        public ActionResult BookSchedule()
        {
            var query = (from p in db.Schedules
                         where p.DepartureTime > DateTime.Now
                         select p).ToList();
            var model = new BookingsModel
            {
                Schedule = query
            };
            return View(model);
        }

        public ActionResult Book(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BookingsModel bookings = new BookingsModel
            {
                GoodsList = db.Goods.Select(c => new SelectListItem
                {
                    Value = c.GoodID.ToString(),
                    Text = c.GoodName,
                }),

                SelectedSchedule = db.Schedules.Find(id),
            };
            if (bookings.SelectedSchedule.BayLeft < 1)
            {
                TempData["fullbook"] = "true";
                TempData["msg"] = "<script>alert('Cannot book this schedule');</script>";
                return RedirectToAction("BookSchedule");
            }
            TempData["BookingsModel"] = bookings;
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        [HttpPost]
        public ActionResult Book(BookingsModel book)
        {

            book.GoodsList = db.Goods.Select(c => new SelectListItem
            {
                Value = c.GoodID.ToString(),
                Text = c.GoodName,
            });

            if (db.Customers.Any(u => u.CustomerID == book.CustomerID))
            {
                if (ModelState.IsValid)
                {
                    db.Orders.Add(new Order
                    {
                        Good = db.Goods.FirstOrDefault(r => r.GoodID == book.GoodID),
                        Customer = db.Customers.FirstOrDefault(r => r.CustomerID == book.CustomerID),
                        Schedule = db.Schedules.FirstOrDefault(r => r.ScheduleID == book.SelectedSchedule.ScheduleID),
                        TimeBooked = DateTime.Now
                    });
                    db.SaveChanges();

                    var result = db.Schedules.SingleOrDefault(b => b.ScheduleID == book.SelectedSchedule.ScheduleID);
                    if (result != null)
                    {
                        result.BayLeft = result.BayLeft - 1;
                        db.SaveChanges();
                    }
                    return RedirectToAction("AgentHome");
                }
            }
            ViewBag.Error = "Invalid CustomerID";
            return View(book);

        }

        public ActionResult ViewBooking(string customerID, string to, string from)
        {
            var book = from s in db.Orders
                           select s;
            if (!String.IsNullOrEmpty(customerID))
            {
                book = book.Where(s => s.Customer.CustomerID.ToString().Contains(customerID));                                    
            }
            if (!String.IsNullOrEmpty(to) && !String.IsNullOrEmpty(from))
            {
                DateTime dtFrom = Convert.ToDateTime(from);
                DateTime dtTo = Convert.ToDateTime(to);
                book = book.Where(s => s.TimeBooked > dtFrom && s.TimeBooked < dtTo);
            }
            if (!String.IsNullOrEmpty(to)&& !String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(customerID))
            {
                DateTime dtFrom = Convert.ToDateTime(from);
                DateTime dtTo = Convert.ToDateTime(to);
                book = book.Where(s => s.TimeBooked > dtFrom && s.TimeBooked < dtTo && s.Customer.CustomerID.ToString().Contains(customerID));
            }



            return View(book.ToList());
        }

    }
 
}