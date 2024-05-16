using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fotos
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

<<<<<<< HEAD
            routes.MapRoute(
                name: "Admin",
                url: "admin",
=======
/*            routes.MapRoute(
                name: "SignIn",
                url: "SignIn",
>>>>>>> 850bf8397263b2c5f80af6f77015b321ff303f60
                defaults: new { controller = "SignIn", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
<<<<<<< HEAD
=======
            );*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "SignIn", action = "Index", id = UrlParameter.Optional }
>>>>>>> 850bf8397263b2c5f80af6f77015b321ff303f60
            );
        }
    }
}
