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
    public class Admin_Meeting_DetailsController : Controller
    {
        private Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext();

        // GET: Admin_Meeting_Details
        
        public ActionResult Index(Meeting_Details md)
        {
            List<UserAdmin> listUa = db.UserAdmins.ToList();
            return View(listUa);

            
            //return View(db.Meeting_Details.ToList());

            //Running Code
            //var items = db.UserAdmins.ToList();
            //if (items != null)
            //{
            //    ViewBag.data = items;
            //}
            //return View();

            //Trial 1------
            //List<UserAdmin> list_UA = new List<UserAdmin>();
            //List<Meeting_Details> list_Meeting = new List<Meeting_Details>();

            //modelUaMeeting finalItem = new modelUaMeeting();
            //finalItem.listUA = list_UA;
            //finalItem.listMeeting = list_Meeting;

            //return View(finalItem);

            //Trial 2------
            //ViewBag.UserAdmins = new SelectList(db.UserAdmins, "ID", "Name");
            //return View();

            //Trial 3
            //TempData["Data"] = md.Client_Name;
            //return RedirectToAction("Index");
        }
        // GET: Admin_Meeting_Details/Details/5
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

        // GET: Admin_Meeting_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin_Meeting_Details/Create
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

        // GET: Admin_Meeting_Details/Edit/5
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

        // POST: Admin_Meeting_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "M_ID,Client_Name,Date_Time,Note")] Meeting_Details meeting_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meeting_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meeting_Details);
        }

        // GET: Admin_Meeting_Details/Delete/5
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

        // POST: Admin_Meeting_Details/Delete/5
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
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login15","ALogin");
        }
    }
}
