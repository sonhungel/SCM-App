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

        public string PartnerCode => Model.PartnerCode;
        public string PartnerName => Model.PartnerName;
        public string PartnerPhoneNumber => Model.PartnerPhoneNumber;
        public string PartnerAddress => $"{Model.StreetAddress}_{Model.WardAddress}_{Model.DistrictAddress}_{Model.ProvinceAddress}";
        public int DebtsNeedPaid => Model.DebtsNeedPaid;
        public int TotaMoneylWasBuy => Model.TotaMoneylWasBuy;
        public string NumberOfTimeBuy => DateTimeHelper.DateTimeToStandardString(Model.LastTimeBuy);
    }
}
