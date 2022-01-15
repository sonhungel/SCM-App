using SCMApp.Helper;
using SCMApp.Models;
using SCMApp.Presentation.AddressItem;
using System.Linq;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class PartnerViewModelItem
    {
        public PartnerViewModelItem(Partner partner)
        {
            Model = partner;
        }

        public Partner Model;
        public int Id => Model.id;
        public int? PartnerCode => Model.supplierNumber;
        public string PartnerName => Model.name;
        public string PartnerPhoneNumber => Model.phoneNumber;
        public string PartnerAddress
        {
            get
            {
                var provine = Address.Instance().ProvinceList.SingleOrDefault(x => x.Id == Model.province);
                var district = provine.Districts.SingleOrDefault(x => x.Id == Model.district);
                var ward = district.Wards.SingleOrDefault(x => x.Id == Model.ward);
                return $"{Model.address}_{ward?.Name}_{district?.Name}_{provine?.Name}";
            }
        }
        
        public int TotaMoneylWasBuy => Model.paid;
        public string NumberOfTimeBuy => DateTimeHelper.DateTimeToStandardString(Model.LastTimeBuy);
    }
}
