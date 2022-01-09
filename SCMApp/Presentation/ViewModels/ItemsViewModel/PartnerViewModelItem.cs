using SCMApp.Helper;
using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class PartnerViewModelItem
    {
        public PartnerViewModelItem(Partner partner)
        {
            Model = partner;
        }

        public Partner Model;

        public string PartnerCode => Model.supplierNumber;
        public string PartnerName => Model.name;
        public string PartnerPhoneNumber => Model.phoneNumber;
        public string PartnerAddress => $"{Model.address}_{Model.ward}_{Model.district}_{Model.province}";
        public int TotaMoneylWasBuy => Model.paid;
        public string NumberOfTimeBuy => DateTimeHelper.DateTimeToStandardString(Model.LastTimeBuy);
    }
}
