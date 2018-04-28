using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Community_Trust
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //the newest way to do custom routes
            routes.MapMvcAttributeRoutes();


            //a custom route, the old way to do it
           /* routes.MapRoute(
                "SubmissionsByGrantCategory",
                "submission/{action}/{id}",
                //parameters will only be called by the id keyword
                new { controller = "Submission", action = "SubmissionsByGrantCategory", id = UrlParameter.Optional },
                new { amount = @"500|1000|5000}", quarter = @"1|2|3|4" }
                );
                */

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //parameters will only be called by the id keyword
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
