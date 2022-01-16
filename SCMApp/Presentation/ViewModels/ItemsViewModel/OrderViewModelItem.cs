using SCMApp.Helper;
using SCMApp.Models;

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
        public string TotalPrice => MoneyHelper.IntToStandardMoneyStringWithTail(Model.paid);
    }
}
