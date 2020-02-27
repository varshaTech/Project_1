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
    public class ALoginController : Controller
    {
        private Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext();

        // GET: ALogin
        public ActionResult Login15()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login15(LoginClass model)
        {
            if(ModelState.IsValid)
            {
                using (Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext())
                {
                    var obj2 = db.UserAdmins.Where(a => a.Email_ID.Equals(model.Email_ID) && a.Password.Equals(model.Password) && a.Role.Equals("Admin")).FirstOrDefault();
                    if(obj2!=null)
                    {
                        Session["Id"] = obj2.ID.ToString();
                        Session["email_Id"] = obj2.Email_ID.ToString();
                        Session["name"] = obj2.Name.ToString();
                        return RedirectToAction("UserDashBoard2");
                        
                        //ViewBag.hdnflg = Session["Id"];
                    }
                    else
                    {
                        //ModelState.AddModelError("", "Login data is incorrect");
                        ModelState.AddModelError("ErrorMsg", "UserID or Password is incorrect");
                    }
                }
            }
           
            return View(model);
        }
        public ActionResult UserDashBoard2()
        {
            if(Session["Id"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login15","ALogin");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login15","ALogin");
        }
        public ActionResult Index()
        {
            return View(db.UserAdmins.ToList());
        }
        // GET: ALogin/Details/5
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
        // GET: ALogin/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: ALogin/Create
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
        // GET: ALogin/Edit/5
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
        // POST: ALogin/Edit/5
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
       // GET: ALogin/Delete/5
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
        // POST: ALogin/Delete/5
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
