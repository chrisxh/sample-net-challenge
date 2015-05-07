using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using AppStoreApi.Models;
using AppStoreApi.Repository;

namespace AppStoreApi.Areas.CustomerApps.Controllers
{
    public class CustAppsController : ApiController
    {
        private IRepository _cusAppsRepo = new Repository.Repository();

        public IEnumerable<AppInfo> Get(int id)
        {
            var customerApps = _cusAppsRepo.GetCustomerApps(id);
            
            return customerApps;
        }

        public void Post(Models.CustomerApps custApps)
        {
            _cusAppsRepo.AddCustApp(custApps);

        }
    }
}