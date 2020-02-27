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
    public class AdminAllMeetingDetailsController : Controller
    {
        private Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext();

        // GET: AdminAllMeetingDetails
        public ActionResult Index()
        {
            var meeting_Details = db.Meeting_Details.Include(m => m.UserAdmin);
            return View(meeting_Details.ToList());
        }

        // GET: AdminAllMeetingDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting_Details meeting_Details = db.Meeting_Details.Find(id);
            if (meeting_Details == null)
            {
                return HttpNotFound();
            }
            return View(meeting_Details);
        }

        // GET: AdminAllMeetingDetails/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.UserAdmins, "ID", "Name");
            return View();
        }

        // POST: AdminAllMeetingDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "M_ID,Client_Name,Date_Time,Note,ID")] Meeting_Details meeting_Details)
        {
            if (ModelState.IsValid)
            {
                db.Meeting_Details.Add(meeting_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.UserAdmins, "ID", "Name", meeting_Details.ID);
            return View(meeting_Details);
        }

        // GET: AdminAllMeetingDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting_Details meeting_Details = db.Meeting_Details.Find(id);
            if (meeting_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.UserAdmins, "ID", "Name", meeting_Details.ID);
            return View(meeting_Details);
        }

        // POST: AdminAllMeetingDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "M_ID,Client_Name,Date_Time,Note,ID")] Meeting_Details meeting_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meeting_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.UserAdmins, "ID", "Name", meeting_Details.ID);
            return View(meeting_Details);
        }

        // GET: AdminAllMeetingDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting_Details meeting_Details = db.Meeting_Details.Find(id);
            if (meeting_Details == null)
            {
                return HttpNotFound();
            }
            return View(meeting_Details);
        }

        // POST: AdminAllMeetingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meeting_Details meeting_Details = db.Meeting_Details.Find(id);
            db.Meeting_Details.Remove(meeting_Details);
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
