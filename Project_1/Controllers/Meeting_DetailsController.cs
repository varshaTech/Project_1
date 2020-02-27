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
    //[Authorize]
    public class Meeting_DetailsController : Controller
    {
        private Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext();

        // GET: Meeting_Details
        public ActionResult Index()
        {
            ViewBag.Client_Name = new SelectList(db.Client_Details, "C_ID", "Firm_Name");
            return View(db.Meeting_Details.ToList());
        }
        public ActionResult Client_New()
        {
            var items = db.Client_Details.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }
            return View();
        }

        // GET: Meeting_Details/Details/5
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

        // GET: Meeting_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeetingDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Client_New([Bind(Include = "M_ID,Client_Name,Date_Time,Note,ID")] Meeting_Details meeting_Details)
        {
            if (ModelState.IsValid)
            {
                db.Meeting_Details.Add(meeting_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meeting_Details);
        }


        // POST: Meeting_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "M_ID,Client_Name,Date_Time,Note")] Meeting_Details meeting_Details)
        {
            if (ModelState.IsValid)
            {
                db.Meeting_Details.Add(meeting_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meeting_Details);
        }

        // GET: Meeting_Details/Edit/5
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
            return View(meeting_Details);
        }

        // POST: Meeting_Details/Edit/5
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
            return View(meeting_Details);
        }

        // GET: Meeting_Details/Delete/5
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

        // POST: Meeting_Details/Delete/5
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




