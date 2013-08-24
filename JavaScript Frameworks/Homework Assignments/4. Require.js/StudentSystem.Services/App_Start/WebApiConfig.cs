using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Students.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "StudentsBasicApi",
                routeTemplate: "api/students",
                defaults: new
                {
                    controller = "students",
                    action = "basic"
                }
            );

            config.Routes.MapHttpRoute(
                name: "StudentsDetailedApi",
                routeTemplate: "api/students/detailed",
                defaults: new
                {
                    controller = "students",
                    action = "detailed"
                }
            );

            config.Routes.MapHttpRoute(
                name: "StudentsMarksApi",
                routeTemplate: "api/students/{studentId}/marks",
                defaults: new
                {
                    controller = "students",
                    action = "marks"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
