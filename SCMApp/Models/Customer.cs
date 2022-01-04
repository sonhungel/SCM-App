using SCMApp.Presentation.AddressItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class Customer
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CustomerBirthDay { get; set; }
        public string Gender { get; set; }
        public Province ProvinceAddress { get; set; }
        public District DistrictAddress { get; set; }
        public Ward WardAddress { get; set; }
        public string StreetAddress { get; set; }
        public string TaxCode { get; set; }

        public DateTime? LastTimeBuy { get; set; }
        public int TotalMoneyWasBought { get; set; }
    }
}
