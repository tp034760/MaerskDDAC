using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Maersk_DDAC.Models;

namespace Maersk_DDAC.Controllers
{
    public class DocksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Docks
        public ActionResult Index()
        {
            return View(db.Docks.ToList());
        }

        // GET: Docks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dock dock = db.Docks.Find(id);
            if (dock == null)
            {
                return HttpNotFound();
            }
            return View(dock);
        }

        // GET: Docks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Docks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DockID,DockName,DockLocation")] Dock dock)
        {
            if (ModelState.IsValid)
            {
                db.Docks.Add(dock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dock);
        }

        // GET: Docks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dock dock = db.Docks.Find(id);
            if (dock == null)
            {
                return HttpNotFound();
            }
            return View(dock);
        }

        // POST: Docks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DockID,DockName,DockLocation")] Dock dock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dock);
        }

        // GET: Docks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dock dock = db.Docks.Find(id);
            if (dock == null)
            {
                return HttpNotFound();
            }
            return View(dock);
        }

        // POST: Docks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dock dock = db.Docks.Find(id);
            db.Docks.Remove(dock);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
