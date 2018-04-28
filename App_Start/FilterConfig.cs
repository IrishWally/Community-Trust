using System.Web;
using System.Web.Mvc;

namespace Community_Trust
{
    //Global Filters
   
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute()); //my app endpoints are no longer available on a http channel
        }
    }
}
