using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using AppStoreApi.DbContext;
using AppStoreApi.Models;

namespace AppStoreApi.Repository
{
    public interface IRepository
    {
        #region Customer

        int AddCustomer(CustomerInfo info);

        IEnumerable<CustomerInfo> GetCustomers();

        CustomerInfo GetCustomer(int id);

        #endregion

        #region Apps

        int AddApp(AppInfo info);

        IEnumerable<AppInfo> GetApps();

        AppInfo GetApp(int id);

        #endregion

        #region License

        int AddLicense(LicenseInfo info);

        IEnumerable<LicenseInfo> GetLicenses();

        LicenseInfo GetLicense(int id);

        #endregion

        IEnumerable<LicenseInfo> GetAppLicenses(int id);

        IEnumerable<LicenseInfo> GetActiveLicenses();

        void AddLicenseToApp(Models.LicensedApp app);

        IEnumerable<AppInfo> GetCustomerApps(int id);

        IEnumerable<ActiveApplication> GetActiveApps();

        void AddCustApp(CustomerApps custApps);
    }
}
