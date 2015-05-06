using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppStore.Models.Apps;
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
    }
}