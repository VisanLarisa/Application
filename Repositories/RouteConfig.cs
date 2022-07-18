using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Application.Models
{
    public class RouteConfig
    {
        // public static void RegisterRoutes(RouteCollection routes)
        //{
        //   routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        // routes.MapRoute(
        //   name: "Default", // Route name
        //   url: "{controller}/{action}/{id}", // URL with parameters
        //   defaults: new { controller = "Make", action = "Index", id = "" } // Parameter defaults (UrlParameter.Optional)
        // );
        //  routes.MapRoute(
        //     name: "Default",
        //   url: "{controller}/{action}/{id}",
        // defaults: new { controller = "Home", action = "Index", id = "" }
        //);

        //}
/*        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = System.Web.Mvc.UrlParameter.Optional }
            );
        }*/
    }
}
