using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppStore.Models.Customer;
using AppStore.Repository;

namespace AppStore.Controllers
{
    public class CustomerController : Controller
    {
        private IAppStoreRepository _custRepo = new AppStoreRespository();

        public ActionResult Customers()
        {
            var model = _custRepo.GetCustomers();
            return View(model);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer info)
        {
            _custRepo.AddCustomer(info);
            return RedirectToAction("Customers");
        }

        public ActionResult Edit(Customer edit)
        {
            _custRepo.EditCustomer(edit);
            return RedirectToAction("Customers");
        }

        public ActionResult GetCustomer(int custId)
        {
            var custModel = _custRepo.GetCustomer(custId);
            return View("Edit",custModel);
        }
    }
}