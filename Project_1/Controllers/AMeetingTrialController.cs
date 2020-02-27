using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_1.Controllers
{
    public class AMeetingTrialController : Controller
    {
        // GET: AMeetingTrial
        public ActionResult Index()
        {
            Proj1_DBEntitiesContext pd = new Proj1_DBEntitiesContext();
            ViewBag.UserAdmin = new SelectList(pd.UserAdmins, "ID", "Name");
            return View();
        }
    }
}