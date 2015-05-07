
using System.Web.Http;
using System.Web.Mvc;

namespace AppStoreApi.Areas.Customer
{
    public class CustomerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Customer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
              name: "Customer",
              routeTemplate: "v1/Customer",
              defaults: new { Controller = "Customer" }
          );
           
        }

    }
}