using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppStore.Models.Apps;
using AppStore.Models.CustomerApps;
using AppStore.Models.LicenseApps;
using AppStore.Repository;

namespace AppStore.Controllers
{
    public class AppController : Controller
    {
        private IAppStoreRepository _appRepo = new AppStoreRespository();

        public ActionResult Applications()
        {
            var model = _appRepo.GetApps();
            return View(model);
        }

        public ActionResult AddApplication()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddApplication(Application info)
        {
            _appRepo.AddApp(info);
            return RedirectToAction("Applications");
        }

        public ActionResult EditApplication(Application edit)
        {
            _appRepo.EditApp(edit);
            return RedirectToAction("Applications");
        }

        public ActionResult GetApp(int appId)
        {
            var appModel = _appRepo.GetApp(appId);
            return View("Edit", appModel);
        }

        public ActionResult GetAppLic(int id)
        {
            var licenses = _appRepo.GetAppLicenses(id);

            return PartialView("_AppLicenses", licenses);
        }

        public ActionResult AddAppLic(int appId)
        {
            var appModel = _appRepo.GetApp(appId);

            return View("AddAppLicenses", appModel);
        }

        public ActionResult GetActiveLicenses()
        {
            var act = _appRepo.GetActiveLicenses();

            return PartialView("_ActiveLicenses",act);
        }

        public ActionResult AddLicensesToApp(FormCollection result)
        {
            string selected = Request.Form["licensedApp"].ToString();

            var model = new LicensedApp();

            model.Id = Convert.ToInt32(Request.Form["Id"]);

            model.LicenseApp = new List<LicensedIds>();

            string[] selectedList = selected.Split(Convert.ToChar(","));

            foreach (var lic in selectedList)
            {
                int value;
                if (int.TryParse(lic, out value))
                {
                    model.LicenseApp.Add(new LicensedIds
                    {
                        LicenseId = Convert.ToInt32(lic)
                    });
                }
                
            }
            
            _appRepo.AddLicensesToApp(model);

            return RedirectToAction("Applications");
        }

        public ActionResult GetActiveApplications()
        {
            var activeApps = _appRepo.GetActiveLicensedApps();

            return PartialView("_ActiveApps", activeApps);
        }

        public ActionResult AddCustomerApp(FormCollection appResult)
        {
            string selected = Request.Form["activeApp"].ToString();

            var model = new CustApps();

            model.Id = Convert.ToInt32(Request.Form["Id"]);

            model.LicensedApp = new List<LicensedIds>();

            string[] selectedList = selected.Split(Convert.ToChar(","));

            foreach (var lic in selectedList)
            {
                int value;
                if (int.TryParse(lic, out value))
                {
                    model.LicensedApp.Add(new LicensedIds
                    {
                        LicenseId = Convert.ToInt32(lic)
                    });
                }
            }

            _appRepo.AddCustomerToApps(model);

            return RedirectToAction("Customers", "Customer");
        }
    }
}