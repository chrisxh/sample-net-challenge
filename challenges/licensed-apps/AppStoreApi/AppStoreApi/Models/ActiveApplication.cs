using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace AppStoreApi.Models
{
    public class ActiveApplication
    {
        public int LicenseId { get; set; }

        public AppInfo Application { get; set; }
    }
}