using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AppStoreApi.Areas.License
{
    public class LicenseAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "License";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
              name: "License",
              routeTemplate: "v1/License",
              defaults: new { Controller = "License" }
          );
        }
    }
}