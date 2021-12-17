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
        public OrderViewModelItem(ICommand deleteOrderCommand, Order order)
        {
            DeleteOrderCommand = deleteOrderCommand;
            Model = order;
        }

        Order Model { get; set; } 
        public string OrderCode => Model.OrderCode;
        public string OrderTime => DateTimeHelper.DateTimeToStandardString(Model.OrderTime);
        public string CustomerName => Model.CustomerName;
        public decimal TotalPrice => Model.TotalPrice;
        public decimal DiscountPrice => Model.DiscountPrice;
        public decimal ActualPrice => Model.ActualPrice;
        public decimal CustomerPaid => Model.CustomerPaid;
        public ICommand DeleteOrderCommand { get; set; }
    }
}
