using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_1.Models;

namespace Project_1.Controllers
{

    public class AdminAttendence2Controller : Controller
    {
        private Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext();

        // GET: AdminAttendence2
        public ActionResult Index()
        {
            var attendence2 = db.Attendence2.Include(a => a.UserAdmin);
            return View(attendence2.ToList());
        }
        // GET: AdminAttendence2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendence2 attendence2 = db.Attendence2.Find(id);
            if (attendence2 == null)
            {
                return HttpNotFound();
            }
            return View(attendence2);
        }

        // GET: AdminAttendence2/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.UserAdmins, "ID", "Name");
            return View();
        }

        // POST: AdminAttendence2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AID,ID,Name,Email_ID,Date_Time")] Attendence2 attendence2)
        {
            if (ModelState.IsValid)
            {
                db.Attendence2.Add(attendence2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.UserAdmins, "ID", "Name", attendence2.ID);
            return View(attendence2);
        }

        // GET: AdminAttendence2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendence2 attendence2 = db.Attendence2.Find(id);
            if (attendence2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.UserAdmins, "ID", "Name", attendence2.ID);
            return View(attendence2);
        }

        // POST: AdminAttendence2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AID,ID,Name,Email_ID,Date_Time")] Attendence2 attendence2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendence2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.UserAdmins, "ID", "Name", attendence2.ID);
            return View(attendence2);
        }

        // GET: AdminAttendence2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendence2 attendence2 = db.Attendence2.Find(id);
            if (attendence2 == null)
            {
                return HttpNotFound();
            }
            return View(attendence2);
        }

        // POST: AdminAttendence2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendence2 attendence2 = db.Attendence2.Find(id);
            db.Attendence2.Remove(attendence2);
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
