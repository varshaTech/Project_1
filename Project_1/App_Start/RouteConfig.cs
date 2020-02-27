﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ULogin", action = "Login11", id = UrlParameter.Optional }
               //defaults: new { controller = "ALogin", action = "Login15", id = UrlParameter.Optional }
               //defaults: new { controller = "TrialHiddenController", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}
