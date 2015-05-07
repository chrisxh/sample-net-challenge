using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppStoreApi.Models
{
    public class LicensedApp
    {
        public int Id { get; set; }

        public List<LicensedIds> LicenseApp { get; set; } 
    }
}