using SCMApp.Presentation.AddressItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class Partner: BusinessObjectBase
    {
        public string supplierNumber { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public Province province { get; set; }
        public District district { get; set; }
        public Ward ward { get; set; }
        public string address { get; set; }
        public bool type { get; set; }
        public string taxNumber { get; set; }
        public string remark { get; set; }
        public int paid { get; set; }
        public DateTime LastTimeBuy { get; set; }
    }
}
