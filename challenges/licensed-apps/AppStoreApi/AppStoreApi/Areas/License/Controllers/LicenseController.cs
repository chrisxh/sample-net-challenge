using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AppStoreApi.Models;
using AppStoreApi.Repository;

namespace AppStoreApi.Areas.License.Controllers
{
    public class LicenseController : ApiController
    {
        private IRepository _licenseRepo = new Repository.Repository();

        public IEnumerable<LicenseInfo> Get()
        {
            var licenses = _licenseRepo.GetLicenses();

            return licenses;
        }

        public LicenseInfo Get(int id)
        {
            var license = _licenseRepo.GetLicense(id);
            return license;
        }

        public int Post(LicenseInfo info)
        {
            var licNum = _licenseRepo.AddLicense(info);

            return licNum;
        }
    }
}