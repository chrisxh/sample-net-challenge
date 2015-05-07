using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AppStoreApi.Areas.Apps
{
    public class AppsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Apps";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
              name: "Apps",
              routeTemplate: "v1/Application",
              defaults: new { Controller = "Apps" }
          );
        }
    }
}