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
    public class EditProfileController : Controller
    {
        private Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext();

        // GET: EditProfile
        public ActionResult Index()
        {
            return View(db.UserAdmins.ToList());
        }

        // GET: EditProfile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAdmin userAdmin = db.UserAdmins.Find(id);
            if (userAdmin == null)
            {
                return HttpNotFound();
            }
            return View(userAdmin);
        }

        // GET: EditProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Name,Email_ID,Mobile_No,Address,Role,Password")] UserAdmin userAdmin)
        {
            if (ModelState.IsValid)
            {
                db.UserAdmins.Add(userAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAdmin);
        }

        // GET: EditProfile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAdmin userAdmin = db.UserAdmins.Find(id);
            if (userAdmin == null)
            {
                return HttpNotFound();
            }
            return View(userAdmin);
        }

        // POST: EditProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Name,Email_ID,Mobile_No,Address,Role,Password")] UserAdmin userAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAdmin);
        }

        // GET: EditProfile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAdmin userAdmin = db.UserAdmins.Find(id);
            if (userAdmin == null)
            {
                return HttpNotFound();
            }
            return View(userAdmin);
        }

        // POST: EditProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAdmin userAdmin = db.UserAdmins.Find(id);
            db.UserAdmins.Remove(userAdmin);
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
