using SCMApp.Helper;
using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class OrderViewModelItem
    {
        public OrderViewModelItem(Order order)
        {
            Model = order;
        }

        Order Model { get; set; } 
        public string OrderCode => Model.OrderCode;
        public string OrderTime => DateTimeHelper.DateTimeToStandardString(Model.OrderTime);
        public string CustomerName => Model.CustomerName;
        public decimal TotalPrice => Model.TotalPrice;
        public decimal CustomerPaid => Model.CustomerPaid;
    }
}
