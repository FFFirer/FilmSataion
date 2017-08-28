using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FilmStation.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                new { controller = "Film", action = "List", category = (string)null, page = 1 }
                );


            routes.MapRoute(
                null,
                "{page}",
                new { controller = "Film", action = "List", category = (string)null},
                new { page = @"\d+"}
                );

            routes.MapRoute(
                "search1",
                "Search",
                new { controller = "Film", action = "Search", page = 1 }
                );

            routes.MapRoute(
                "search2",
                "Search/{page}",
                new { controller = "Film", action = "Search" },
                new { page = @"\d+" }
                );

            routes.MapRoute(
                "cate1",
                "category/{category}",
                new { controller = "Film", action = "List", page = 1 }
                );

            routes.MapRoute(
                "cate2",
                "category/{category}/{page}",
                new { controller = "Film", action = "List" }
                );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
