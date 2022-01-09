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
        
        public string CustomerCode => Model.customerNumber;
        public string CustomerName => Model.name;
        public string CustomerPhoneNumber => Model.phoneNumber;
        public string CustomerAddress => $"{Model.address}_{Model.ward}_{Model.district}_{Model.province}";

        public string CustomerLastTimeBuy => DateTimeHelper.DateTimeToStandardString(Model.LastTimeBuy);
        public int TotalMoney => Model.paid;
    }
}
