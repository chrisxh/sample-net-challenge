using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AppStoreApi.Areas.CustomerApps.Controllers
{
    public class CustAppsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CustApps";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
              name: "CustApps",
              routeTemplate: "v1/CustomerApps",
              defaults: new { Controller = "CustApps" }
          );

        }
    }
}