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
        public int OrderCode => Model.id;
        public string OrderTime => DateTimeHelper.DateTimeToStandardString(Model.addedDate);
        public string CustomerName => Model.customer.name;
        public int TotalPrice => Model.paid;
    }
}
