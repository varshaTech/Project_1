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

        //GET: ULogin
        public ActionResult Login11()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login11(LoginClass model)
        {
            using (var context = new Proj1_DBEntitiesContext())
            {
                bool isValid = context.UserAdmins.Any(x => x.Email_ID == model.Email_ID && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Email_ID, false);
                    return RedirectToAction("Index", "Client_Details");
                }
                ModelState.AddModelError("", "Invalid ID or Password");
                return View();

            }
        }

            //if (ModelState.IsValid == true)
            //{
            //    var credentials = db.UserAdmins.Where(x => x.Email_ID == model.Email_ID && x.Password == model.Password).FirstOrDefault();
            //    if (credentials == null)
            //    {
            //        ViewBag.ErrorMessage = "Login Failed";
            //    }
            //    else
            //    {
            //        Session["emailId"] = model.Email_ID;
            //        return RedirectToAction("Index", "Client_Details");
            //    }

            //}
            //    return View();
            //}


            //Running code
            //public ActionResult Login12()
            //{
            //    return View();
            //}
            //[HttpPost]
            //public ActionResult Login12(LoginClass model)
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



            //public ActionResult Login12()
            //{
            //    return View();
            //}

            //[HttpPost]
            //public ActionResult Login12(LoginClass model)
            //{
            //    if (ModelState.IsValid == true)
            //    {
            //        var credentials = db.UserAdmins.Where(x => x.Email_ID == model.Email_ID && x.Password == model.Password).FirstOrDefault();
            //        if (credentials == null)
            //        {
            //            ViewBag.ErrorMessage = "Login Failed";
            //            return View();
            //        }
            //        else
            //        {
            //            Session["emailId"] = model.Email_ID;
            //            return RedirectToAction("Index", "Client_Details");
            //        }
            //    }
            //}

            public ActionResult Logout()
        {
            //Session.Abandon();
            //return RedirectToAction("Index","ULogin");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login11");
        }
    }
} 