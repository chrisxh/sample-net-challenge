using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace AppStoreApi.Areas.AppLicenses
{
    public class AppLicenseAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AppLicense";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
              name: "AppLicense",
              routeTemplate: "v1/AppLicense",
              defaults: new { Controller = "AppLicense" }
          );
        }
    }
}