using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using AppStoreApi.DbContext;
using AppStoreApi.Models;
using LicensedApp = AppStoreApi.Models.LicensedApp;

namespace AppStoreApi.Repository
{
    public class Repository : IRepository,IDisposable
    {
        private ApplicationStoreDBEntities db = new ApplicationStoreDBEntities();

        #region Customer
        
        public int AddCustomer(CustomerInfo info)
        {
            if (info.Id != 0)
            {
                var customer = db.Customers.SingleOrDefault(x => x.Id == info.Id);
                if (customer != null)
                {
                    customer.Name = info.Name;
                    customer.EmailAddress = info.EmailAddress;
                    customer.Number = info.Number;
                    customer.Active = info.Active;
                    customer.UpdatedDate = DateTime.Now;
                    db.SaveChanges();
                }
                    
            }
            else
            {
                var cust = new Customer
                {
                    Name = info.Name,
                    EmailAddress = info.EmailAddress,
                    Number = info.Number,
                    Active = info.Active,
                    DateInserted = DateTime.Now
                };

                db.Customers.Add(cust);

                db.SaveChanges();
            }
            

            return 0;
        }

        public IEnumerable<CustomerInfo> GetCustomers()
        {
            var customers = (from j in db.Customers
                select new CustomerInfo
                {
                    Id =  j.Id,
                    Name = j.Name,
                    EmailAddress = j.EmailAddress,
                    Number = j.Number,
                    Active = j.Active
                });
            
            return customers.ToList();
        }

        public CustomerInfo GetCustomer(int id)
        {
            var cust = (from c in db.Customers.Where(x => x.Id == id)
                select new CustomerInfo
                {
                    Id = c.Id,
                    Name = c.Name,
                    EmailAddress = c.EmailAddress,
                    Number = c.Number,
                    Active = c.Active
                }).FirstOrDefault();
            return cust;
        }

        #endregion

        #region Apps

        public int AddApp(AppInfo info)
        {
            if (info.Id != 0)
            {
                var app = db.Apps.SingleOrDefault(x => x.Id == info.Id);
                if (app != null)
                {
                    app.Title = info.Title;
                    app.Icon = info.Icon;
                    app.Active = info.Active;
                    app.UpdatedDate = DateTime.Now;
                    db.SaveChanges();
                }

            }
            else
            {
                var app = new App
                {
                    Title = info.Title,
                    Icon = info.Icon,
                    Active = info.Active,
                    AddedDate = DateTime.Now
                };

                db.Apps.Add(app);

                db.SaveChanges();
            }


            return 0;
        }

        public IEnumerable<AppInfo> GetApps()
        {
            var apps = (from j in db.Apps
                             select new AppInfo
                             {
                                 Id = j.Id,
                                 Title = j.Title,
                                 Icon = j.Icon,
                                 Active = j.Active
                             });

            return apps.ToList();
        }

        public AppInfo GetApp(int id)
        {
            var app = (from c in db.Apps.Where(x => x.Id == id)
                        select new AppInfo
                        {
                            Id = c.Id,
                            Title = c.Title,
                            Icon = c.Icon,
                            Active = c.Active
                        }).FirstOrDefault();
            return app;
        }

        #endregion

        #region Licenses

        public int AddLicense(LicenseInfo info)
        {
            if (info.Id != 0)
            {
                var lic = db.Licenses.SingleOrDefault(x => x.Id == info.Id);
                if (lic != null)
                {
                    lic.Number = info.Number;
                    lic.ActiveDate = info.ActiveDate;
                    lic.DeActiveDate = info.DeActiveDate;
                    lic.UpdatedDate = DateTime.Now;
                    lic.Active = info.Active;
                    db.SaveChanges();
                }

            }
            else
            {
                var lic = new License
                {
                    Number = info.Number,
                    ActiveDate = info.ActiveDate,
                    DeActiveDate = info.DeActiveDate,
                    Active = info.Active,
                    AddedDate = DateTime.Now
                };

                db.Licenses.Add(lic);

                db.SaveChanges();
            }


            return 0;
        }

        public IEnumerable<LicenseInfo> GetLicenses()
        {
            var lics = (from j in db.Licenses
                        select new LicenseInfo
                        {
                            Id = j.Id,
                            Number = j.Number,
                            ActiveDate = j.ActiveDate,
                            DeActiveDate = j.DeActiveDate,
                            Active = j.Active
                        });

            return lics.ToList();
        }

        public LicenseInfo GetLicense(int id)
        {
            var lic = (from c in db.Licenses.Where(x => x.Id == id)
                       select new LicenseInfo
                       {
                           Id = c.Id,
                           Number = c.Number,
                           ActiveDate = c.ActiveDate,
                           DeActiveDate = c.DeActiveDate,
                           Active = c.Active
                       }).FirstOrDefault();
            return lic;
        }

        #endregion

        public IEnumerable<LicenseInfo> GetAppLicenses(int id)
        {
            var appLicense = (from a in db.Licenses
                from b in a.LicensedApps
                where b.AppId == id
                select new LicenseInfo
                {
                    Id = a.Id,
                    Number = a.Number,
                    ActiveDate = a.ActiveDate,
                    DeActiveDate = a.DeActiveDate,
                    Active = a.Active
                }).ToList();

            return appLicense;
        }

        public IEnumerable<LicenseInfo> GetActiveLicenses()
        {
            var activeLic = (from c in db.Licenses
                where c.Active 
                select new LicenseInfo
                {
                    Id = c.Id,
                    Number = c.Number,
                    ActiveDate = c.ActiveDate,
                    DeActiveDate = c.DeActiveDate,
                    Active = c.Active
                }).ToList();
            return activeLic;
        }

        public void AddLicenseToApp(LicensedApp app)
        {
            foreach (var x in app.LicenseApp)
            {
                var addLicenseToApp = new DbContext.LicensedApp
                {
                    AppId = app.Id,
                    LicenseId = x.LicenseId
                };

                db.LicensedApps.Add(addLicenseToApp);
                db.SaveChanges();

            }
        }

        public IEnumerable<AppInfo> GetCustomerApps(int id)
        {
            var apps = (from c in db.CustomerLicenses where c.CustomerId == id select c.LicenseId).ToList();
            var licensedApps = (from lc in db.LicensedApps
                where apps.Contains(lc.LicenseId)
                from jc in db.Apps
                where lc.AppId == jc.Id
                select new AppInfo
                {
                    Id = jc.Id,
                    Title = jc.Title,
                    Icon = jc.Icon,
                    Active = jc.Active
                }).ToList();
            

            return licensedApps;
        }

        public IEnumerable<ActiveApplication> GetActiveApps()
        {
            var activeapp = (from ac in db.Apps
                             from j in ac.LicensedApps
                             where j.AppId == ac.Id && j.License.TakenDate == null && ac.Active
                select new ActiveApplication
                {
                    LicenseId = j.LicenseId,
                    Application = new AppInfo
                    {
                        Id = ac.Id,
                        Title = ac.Title,
                        Icon = ac.Icon,
                        Active = ac.Active
                    }

                }).ToList();

            return activeapp;
        }

        public void AddCustApp(CustomerApps custApps)
        {
            foreach (var x in custApps.LicensedApp)
            {
                var addLicenseToApp = new DbContext.CustomerLicens
                {
                    CustomerId = custApps.Id,
                    LicenseId = x.LicenseId
                };

                db.CustomerLicenses.Add(addLicenseToApp);
                db.SaveChanges();

                var updateLicense = (from l in db.Licenses where l.Id == x.LicenseId select l).FirstOrDefault();
                if (updateLicense != null)
                {
                    updateLicense.TakenDate = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}