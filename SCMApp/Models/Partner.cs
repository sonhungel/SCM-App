using SCMApp.Presentation.AddressItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class Partner
    {
        public string PartnerCode { get; set; }
        public string PartnerName { get; set; }
        public string PartnerPhoneNumber { get; set; }
        public string PartnerEmail { get; set; }
        public Province ProvinceAddress { get; set; }
        public District DistrictAddress { get; set; }
        public Ward WardAddress { get; set; }
        public string StreetAddress { get; set; }
        public bool IsEnterPrise { get; set; }
        public string TaxCode { get; set; }
        public string Note { get; set; }
        public int TotaMoneylWasBuy { get; set; }
        public DateTime LastTimeBuy { get; set; }
    }
}
