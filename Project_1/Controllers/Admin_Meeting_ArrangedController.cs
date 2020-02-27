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
    public class Admin_Meeting_ArrangedController : Controller
    {
        private Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext();

        // GET: Admin_Meeting_Arranged
        public ActionResult Index()
        {
            var meeting_Details = db.Meeting_Details.Include(m => m.UserAdmin);
            return View(meeting_Details.ToList());
        }

        // GET: Admin_Meeting_Arranged/Details/5
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

        // GET: Admin_Meeting_Arranged/Create
        public ActionResult Create()
        {
            //[to display both username & admin in dropdown list]
            //ViewBag.ID = new SelectList(db.UserAdmins, "ID", "Name");


            //to display only users in dropdown list
            ViewBag.ID = new SelectList
             (db.UserAdmins.Where(uu => uu.Role.Equals("User")).ToList(), "ID", "Name");


            //List<UserAdmin> ua = db.UserAdmins.Where(us => us.Role.Equals("User")).ToList();
            //ViewBag.ID = new SelectList(ua, "ID", "Name");





            //for client name in dropdwon
            var item = db.Client_Details.ToList();
            if (item != null)
            {
                ViewBag.data = item;
            }
            return View();
        }

        // POST: Admin_Meeting_Arranged/Create
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

        // GET: Admin_Meeting_Arranged/Edit/5
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

        // POST: Admin_Meeting_Arranged/Edit/5
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

        // GET: Admin_Meeting_Arranged/Delete/5
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

        // POST: Admin_Meeting_Arranged/Delete/5
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
