using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_1.Models;
using System.Web.Security;

namespace Project_1.Controllers
{
    public class ULoginController : Controller
    {
        //Trial
        //Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext();

        //Running Code
        //GET: ULogin
        //public ActionResult Login11()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Login11(LoginClass model)
        //{
        //    using (var context = new Proj1_DBEntitiesContext())
        //    {
        //        bool isValid = context.UserAdmins.Any(x => x.Email_ID == model.Email_ID && x.Password == model.Password);
        //        if (isValid)
        //        {
        //            FormsAuthentication.SetAuthCookie(model.Email_ID, false);
        //            return RedirectToAction("Index", "Client_Details");
        //        }
        //        ModelState.AddModelError("", "Invalid ID or Password");
        //        return View();

        //    }
        //}

        //public ActionResult Login11()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login11(LoginClass userModel)
        //{
        //    using (Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext())
        //    {
        //        var userDetails = db.UserAdmins.Where(x => x.Email_ID == userModel.Email_ID && x.Password == userModel.Password).FirstOrDefault();

        //        if (userDetails==null)
        //        {
        //            ViewBag.ErrorMessage = "Login Failed";
        //        }
        //        else
        //        {
        //            Session["emailId"] = userDetails.Email_ID;
        //            return RedirectToAction("Index", "Client_Details");
        //        }
        //        return View();
        //    }
        //}

        //Trial
        public ActionResult Login11()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login11(LoginClass model, Attendence2 attend /*[Bind(Include ="Email_ID")] Attendence attend*/)
        {
            if (ModelState.IsValid)
            {
                using (Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext())
                {
                    var obj = db.UserAdmins.Where(a => a.Email_ID.Equals(model.Email_ID) && a.Password.Equals(model.Password) && a.Role.Equals("User")).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Id"] = obj.ID.ToString();
                        Session["Email_Id"] = obj.Email_ID.ToString();
                        Session["name"] = obj.Name.ToString();

                        db.Attendence2.Add(attend);
                        db.SaveChanges();

                        //UserAdmin ua = new UserAdmin();
                        //int EID = ua.ID;
                        //Attendence2 att = new Attendence2();
                        //att.ID = EID;
                        //att.Name = model.Name;

                        //db.Attendence2.Add(att);
                        //db.SaveChanges();

                        return RedirectToAction("UserDashBoard");

                        //return RedirectToAction("Index", "TrialDashBoard");
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
        public ActionResult UserDashBoard()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login11", "ULogin");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login11", "ULogin");

            //Session.Abandon();
            //return RedirectToAction("Index", "ULogin");

            //FormsAuthentication.SignOut();
            //return RedirectToAction("Login11");
        }
    }
}