using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AppStoreApi.DbContext;
using AppStoreApi.Models;
using AppStoreApi.Repository;

namespace AppStoreApi.Areas.Customer.Controllers
{
    public class CustomerController : ApiController
    {
        private IRepository _customerRepo = new Repository.Repository();

        // GET: Customer/Customer
        public IEnumerable<CustomerInfo> Get()
        {
            var customers = _customerRepo.GetCustomers();

            return customers;
        }

        public CustomerInfo Get(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            return customer;
        }

        public int Post(CustomerInfo info)
        {
            var custNum = _customerRepo.AddCustomer(info);

            return custNum;
        }
    }
}