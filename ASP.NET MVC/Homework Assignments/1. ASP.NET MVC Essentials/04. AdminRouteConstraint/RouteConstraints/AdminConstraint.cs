using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace RouteConstraint.RouteConstraints
{
    public class AdminConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContextBase httpContext, 
            Route route, 
            string parameterName, 
            RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            var isAdmin = values["controller"].ToString().StartsWith("Admin");
            return isAdmin;
        }
    }
}