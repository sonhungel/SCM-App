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
        public string CustomerrEmail { get; set; }
        public string ProvinceAddress { get; set; }
        public string DistrictAddress { get; set; }
        public string WardAddress { get; set; }
        public string StreetAddress { get; set; }
        public bool IsEnterPrise { get; set; }
        public string TaxCode { get; set; }

        public DateTime LastTimeBuy { get; set; }

        public int TotalMoneyWasBought { get; set; }
        public int Debts { get; set; }
    }
}
