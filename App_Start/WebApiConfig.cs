using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace Community_Trust
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //set up your api to use Camel Case when the api consumes the JSON 
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;


            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

             //Controllers with actions
                //to handle routes like /api/Submissions/1/route
             config.Routes.MapHttpRoute(
                 name:"ControllerAndAction",
                 routeTemplate: "api/{controller}/{action}/{id}"  // add to end /{id}
                                                                  // defaults: new {id = RouteParameter.Optional}
                 );
        }
    }
}
