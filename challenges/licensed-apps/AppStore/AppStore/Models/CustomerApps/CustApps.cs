using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppStore.Models.LicenseApps;

namespace AppStore.Models.CustomerApps
{
    public class CustApps
    {
        public int Id { get; set; }

        public List<LicensedIds> LicensedApp { get; set; } 
    }
}