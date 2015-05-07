using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppStoreApi.Models
{
    public class CustomerInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Number { get; set; }

        public bool Active { get; set; }
    }
}