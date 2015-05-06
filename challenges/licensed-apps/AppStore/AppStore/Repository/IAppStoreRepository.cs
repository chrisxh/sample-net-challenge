using System.Collections.Generic;
using AppStore.Models.Apps;
using AppStore.Models.Customer;
using AppStore.Models.Licenses;

namespace AppStore.Repository
{
    public interface IAppStoreRepository
    {
        #region Customer

        void AddCustomer(Customer cust);

        IEnumerable<Customer> GetCustomers();

        Customer GetCustomer(int id);

        void EditCustomer(Customer editCust);

        #endregion

        #region Apps

        void AddApp(Application app);

        IEnumerable<Application> GetApps();

        Application GetApp(int id);

        void EditApp(Application editApp);

        #endregion

        #region License

        void AddLicense(License lic);

        IEnumerable<License> GetLicenses();

        License GetLicense(int id);

        void EditLicense(License editLic);

        #endregion

        IEnumerable<License> GetAppLicenses(int appId);
        
        IEnumerable<License> GetActiveLicenses();

    }
}
