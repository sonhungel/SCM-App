using SCMApp.Helper;
using SCMApp.Models;
using SCMApp.Presentation.AddressItem;
using System.Linq;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class CustomerViewModelItem
    {
        public CustomerViewModelItem(Customer customer)
        {
            Model = customer;
        }
        public Customer Model;
        
        public int? CustomerCode => Model.customerNumber;
        public string CustomerName => Model.name;
        public string CustomerPhoneNumber => Model.phoneNumber;
        public string CustomerAddress
        {
            get
            {
                var provine = Address.Instance().ProvinceList.SingleOrDefault(x => x.Id == Model.province);
                var district = provine.Districts.SingleOrDefault(x => x.Id == Model.district);
                var ward = district.Wards.SingleOrDefault(x => x.Id == Model.ward);
                return $"{Model.address}_{ward?.Name}_{district?.Name}_{provine?.Name}";
            }
        }

        public string CustomerLastTimeBuy => DateTimeHelper.DateTimeToStandardString(Model.LastTimeBuy);
        public int TotalMoney => Model.paid;
    }
}
