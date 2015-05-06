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
    public class AppLicenseController : ApiController
    {
        private IRepository _appLicenseRepo = new Repository.Repository();

        public IEnumerable<LicenseInfo> Get()
        {
            var activeLicenses = _appLicenseRepo.GetActiveLicenses();

            return activeLicenses;
        }

        public IEnumerable<LicenseInfo> Get(int id)
        {
            var licenses = _appLicenseRepo.GetAppLicenses(id);

            return licenses;
        }
    }
}