using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebEcommerce
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "EditProduit",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Produit", action = "EditProduit", id = UrlParameter.Optional },
                constraints: new { id = @"\d+" }
            );


            routes.MapRoute(
                name: "DetailsProduit",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Produit", action = "GetProduit", id = UrlParameter.Optional },
                constraints: new {id=@"\d+"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
