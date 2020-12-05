using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pusula
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "BenimUlkem",
                url: "Benim-Ulkem",
                defaults: new { controller = "Home", action = "BenimUlkem" }
            );
            routes.MapRoute(
                name: "UlkelerListesi",
                url: "Ulkeler-Listesi",
                defaults: new { controller = "Home", action = "UlkelerListesi", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Uyelik",
                url: "Uyelik",
                defaults: new { controller = "Home", action = "Uyelik" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
