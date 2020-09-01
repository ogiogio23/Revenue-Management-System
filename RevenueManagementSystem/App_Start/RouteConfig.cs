using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RevenueManagementSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "TaxRevenue",
              url: "taxrevenue/{id}",
              defaults: new { controller = "Home", action = "TaxRevenue" }
          );


            routes.MapRoute(
              name: "DeleteDeath",
              url: "deletedeath/{id}",
              defaults: new { controller = "Admin", action = "DeleteDeath" }
          );

            routes.MapRoute(
              name: "EditDeath",
              url: "editdeath/{id}",
              defaults: new { controller = "Admin", action = "EditDeath" }
          );

            routes.MapRoute(
              name: "DeleteMarriage",
              url: "deletemarriage/{id}",
              defaults: new { controller = "Admin", action = "DeleteMarriage" }
          );

            routes.MapRoute(
              name: "EditMarriage",
              url: "editmarriage/{id}",
              defaults: new { controller = "Admin", action = "EditMarriage" }
          );

            routes.MapRoute(
             name: "DeleteCitizen",
             url: "deletecitizen/{id}",
             defaults: new { controller = "Admin", action = "DeleteCitizen" }
         );

            routes.MapRoute(
              name: "EditCitizen",
              url: "editcitizen/{id}",
              defaults: new { controller = "Admin", action = "EditCitizen" }
          );




            routes.MapRoute(
            name: "DeleteAlumni",
            url: "deletealumni/{id}",
            defaults: new { controller = "Admin", action = "DeleteAlumni" }
        );

            routes.MapRoute(
              name: "Edit",
              url: "edit/{id}",
              defaults: new { controller = "Admin", action = "Edit"}
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
