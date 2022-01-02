using SCMApp.Helper;
using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class CustomerViewModelItem
    {
        public CustomerViewModelItem(Customer customer)
        {
            Model = customer;
        }
        public Customer Model;
        
        public string CustomerCode => Model.CustomerCode;
        public string CustomerName => Model.CustomerName;
        public string CustomerPhoneNumber => Model.CustomerPhoneNumber;
        public string CustomerAddress => $"{Model.StreetAddress}_{Model.WardAddress}_{Model.DistrictAddress}_{Model.ProvinceAddress}";

        public string CustomerLastTimeBuy => DateTimeHelper.DateTimeToStandardString(Model.LastTimeBuy);
        public int TotalMoney => Model.TotalMoneyWasBought;
    }
}
