using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppStore.Models.Apps
{
    public class ActiveApplications
    {
        public int LicenseId { get; set; }

        public Application Application { get; set; }
    }
}