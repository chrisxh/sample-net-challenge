using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppStoreApi.Models
{
    public class LicenseInfo
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public bool Active { get; set; }

        public DateTime ActiveDate { get; set; }

        public DateTime DeActiveDate { get; set; }
    }
}