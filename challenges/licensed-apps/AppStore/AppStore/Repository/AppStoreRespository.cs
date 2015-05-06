using System.Collections.Generic;
using System.Configuration;
using AppStore.Models.Apps;
using AppStore.Models.Customer;
using AppStore.Models.Licenses;
using Newtonsoft.Json;
using RestSharp;


namespace AppStore.Repository 
{
    public class AppStoreRespository : IAppStoreRepository
    {
        private readonly static string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
       
        private readonly RestClient _client = new RestClient(BaseUrl);
        
        #region Customer
        
        public void AddCustomer(Customer cust)
        {
            var request = new RestRequest("v1/customer/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(cust);
            _client.Execute(request);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var request = new RestRequest("v1/customer/", Method.GET);
            var response = _client.Execute(request);
            var data = JsonConvert.DeserializeObject<IEnumerable<Customer>>(response.Content);

            return data;
        }

        public Customer GetCustomer(int id)
        {
            var request = new RestRequest("v1/customer/", Method.GET);
            request.AddParameter("id", id);
            var response = _client.Execute(request);
            var data = JsonConvert.DeserializeObject<Customer>(response.Content);

            return data;
        }

        public void EditCustomer(Customer editCust)
        {
            var request = new RestRequest("v1/customer/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(editCust);
            _client.Execute(request);
        }

        #endregion

        #region Apps

        public void AddApp(Application app)
        {
            var request = new RestRequest("v1/application/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(app);
            _client.Execute(request);
        }

        public IEnumerable<Application> GetApps()
        {
            var request = new RestRequest("v1/application/", Method.GET);
            var response = _client.Execute(request);
            var data = JsonConvert.DeserializeObject<IEnumerable<Application>>(response.Content);

            return data;
        }

        public Application GetApp(int id)
        {
            var request = new RestRequest("v1/application/", Method.GET);
            request.AddParameter("id", id);
            var response = _client.Execute(request);
            var data = JsonConvert.DeserializeObject<Application>(response.Content);

            return data;
        }

        public void EditApp(Application editApp)
        {
            var request = new RestRequest("v1/application/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(editApp);
            _client.Execute(request);
        }

       #endregion

        #region License

        public void AddLicense(License lic)
        {
            var request = new RestRequest("v1/license/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(lic);
            _client.Execute(request); 
        }

        public IEnumerable<License> GetLicenses()
        {
            var request = new RestRequest("v1/license/", Method.GET);
            var response = _client.Execute(request);
            var data = JsonConvert.DeserializeObject<IEnumerable<License>>(response.Content);

            return data;
        }

        public License GetLicense(int id)
        {
            var request = new RestRequest("v1/license/", Method.GET);
            request.AddParameter("id", id);
            var response = _client.Execute(request);
            var data = JsonConvert.DeserializeObject<License>(response.Content);

            return data;
        }

        public void EditLicense(License editLic)
        {
            var request = new RestRequest("v1/license/", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(editLic);
            _client.Execute(request);
        }

        #endregion

        public IEnumerable<License> GetAppLicenses(int appId)
        {
            var request = new RestRequest("v1/applicense/", Method.GET);
            request.AddParameter("id", appId);
            var response = _client.Execute(request);
            var data = JsonConvert.DeserializeObject<IEnumerable<License>>(response.Content);

            return data;
        }

        public IEnumerable<License> GetActiveLicenses()
        {
            var request = new RestRequest("v1/applicense/", Method.GET);
            var response = _client.Execute(request);
            var data = JsonConvert.DeserializeObject<IEnumerable<License>>(response.Content);

            return data;
        }
    }
}