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
    
    public class Client_DetailsController : Controller
    {
        private Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext();

        // GET: Client_Details
        public ActionResult Index()
        {
            return View(db.Client_Details.ToList());

            //var userId = (int)Session["userId"];
            //return View(voi.Where(t => t.ID == userId).ToList());

            //if block is trial
            //if(Session["emailId"]==null)
            //{
            //    return RedirectToAction("Login11", "ULogin");
            //}
        }

        // GET: Client_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Details client_Details = db.Client_Details.Find(id);
            if (client_Details == null)
            {
                return HttpNotFound();
            }
            return View(client_Details);
        }

        // GET: Client_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_ID,Firm_Name,Contact_Person_Name,Email_ID,Mobile_No")] Client_Details client_Details)
        {
            if (ModelState.IsValid)
            {
                db.Client_Details.Add(client_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client_Details);
        }

        // GET: Client_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Details client_Details = db.Client_Details.Find(id);
            if (client_Details == null)
            {
                return HttpNotFound();
            }
            return View(client_Details);
        }

        // POST: Client_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_ID,Firm_Name,Contact_Person_Name,Email_ID,Mobile_No")] Client_Details client_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client_Details);
        }

        // GET: Client_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Details client_Details = db.Client_Details.Find(id);
            if (client_Details == null)
            {
                return HttpNotFound();
            }
            return View(client_Details);
        }

        // POST: Client_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client_Details client_Details = db.Client_Details.Find(id);
            db.Client_Details.Remove(client_Details);
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
