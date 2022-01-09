using SCMApp.Presentation.AddressItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class Customer
    {
        public string customerNumber { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public DateTime dateOfBirth { get; set; }
        public bool sex { get; set; }
        public int province { get; set; }
        public int district { get; set; }
        public int ward { get; set; }
        public string address { get; set; }
        public string taxNumber { get; set; }
        public string remark { get; set; }

        public DateTime? LastTimeBuy { get; set; }
        public int paid { get; set; }
    }
}
