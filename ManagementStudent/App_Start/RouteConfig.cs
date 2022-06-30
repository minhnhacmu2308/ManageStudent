﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ManagementStudent
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "đăng ký",
            url: "dangky/{id}",
            defaults: new { controller = "Credit", action = "Add", id = UrlParameter.Optional }
);
            routes.MapRoute(
            name: "phê duyệt",
            url: "pheduyet/{id}",
            defaults: new { controller = "Credit", action = "Accept", id = UrlParameter.Optional }
);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
