using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_1.Models;

namespace Project_1.Controllers
{
    public class uaController : Controller
    {
        // GET: ua
        public ActionResult Index()
        {
            Proj1_DBEntitiesContext db = new Proj1_DBEntitiesContext();
            List<UserAdmin> listUa = db.UserAdmins.ToList();
            return View(listUa);
        }
    }
}