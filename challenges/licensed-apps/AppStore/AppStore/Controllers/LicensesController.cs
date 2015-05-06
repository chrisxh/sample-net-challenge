using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppStore.Models.Licenses;
using AppStore.Repository;

namespace AppStore.Controllers
{
    public class LicensesController : Controller
    {
        private IAppStoreRepository _licenseRepo = new AppStoreRespository();

        public ActionResult Licenses()
        {
            var model = _licenseRepo.GetLicenses();
            return View(model);
        }

        public ActionResult AddLicense()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLicense(License info)
        {
            _licenseRepo.AddLicense(info);
            return RedirectToAction("Licenses");
        }

        public ActionResult Edit(License edit)
        {
            _licenseRepo.EditLicense(edit);
            return RedirectToAction("Licenses");
        }

        public ActionResult GetLicense(int licId)
        {
            var licenseModel = _licenseRepo.GetLicense(licId);
            return View("Edit", licenseModel);
        }
    }
}