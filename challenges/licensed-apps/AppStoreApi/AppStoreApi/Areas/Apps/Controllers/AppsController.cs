using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AppStoreApi.Models;
using AppStoreApi.Repository;

namespace AppStoreApi.Areas.Apps.Controllers
{
    public class AppsController : ApiController
    {
        private IRepository _appsRepo = new Repository.Repository();

        public IEnumerable<AppInfo> Get()
        {
            var customers = _appsRepo.GetApps();

            return customers;
        }

        public AppInfo Get(int id)
        {
            var customer = _appsRepo.GetApp(id);
            return customer;
        }

        public int Post(AppInfo info)
        {
            var custNum = _appsRepo.AddApp(info);

            return custNum;
        }
    }
}