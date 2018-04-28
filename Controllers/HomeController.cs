using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Community_Trust.Controllers
{
    // Allows anonymous access to the actions in this page
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [OutputCache(Duration = 50, Location =System.Web.UI.OutputCacheLocation.Server, VaryByParam ="*")] //this caches this page by duration and location, only case if you have to, if you cache a list the user might see a stale list of users
        //caching can be applied to the whole controller or to individual Actions
        //to disable on an individual Action
        // [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}