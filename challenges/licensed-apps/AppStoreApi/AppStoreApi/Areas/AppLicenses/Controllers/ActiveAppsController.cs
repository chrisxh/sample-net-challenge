using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AppStoreApi.Models;
using AppStoreApi.Repository;

namespace AppStoreApi.Areas.AppLicenses.Controllers
{
    public class ActiveAppsController : ApiController
    {
        private IRepository _activeAppRepo = new Repository.Repository();

        public IEnumerable<ActiveApplication> Get()
        {
            var activeApps = _activeAppRepo.GetActiveApps();

            return activeApps;
        }
    }
}