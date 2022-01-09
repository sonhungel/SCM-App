using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class OrdersViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IInvoiceWebAPI _invoiceWebAPI;
        public OrdersViewModel(IInvoiceWebAPI invoiceWebAPI,string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _invoiceWebAPI = invoiceWebAPI;
            _isHaveNoData = true;
            OpenSellViewCommand = new RelayCommand(p => OpenSellView());
            DeleteOrderCommand = new RelayCommand(p => DeleteOrder((string)p));

            OrderList = new ObservableCollection<OrderViewModelItem>();
        }

        public ICommand OpenSellViewCommand { get; set; }

        public string NamePage => CommonConstants.OrdersPageViewName;

        public string FunctionName => CommonConstants.OrdersFunctionName;

        private bool _isHaveNoData;

        public ObservableCollection<OrderViewModelItem> OrderList { get; set; }

        public ICommand DeleteOrderCommand { get; set; }
        public bool IsHaveNoData 
        {
            get => _isHaveNoData;
            set
            {
                _isHaveNoData = value;
                OnPropertyChanged(nameof(IsHaveNoData));
            }
        }

        public bool IsLoaded { get; set; }

        private void DeleteOrder(string oderCode)
        {
            MessageBoxResult dialogResult = MessageBox.Show(View,"Bạn có muốn xoá hoá đơn này ?", 
                "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                // Detele
                OnPropertyChanged(nameof(OrderList));
            }
        }
        public void Construct()
        {
            IsLoaded = true;
            using (new WaitCursorScope())
            {
                var allInvoice = _invoiceWebAPI.GetAllInvoice(Token);
                foreach (var invoice in allInvoice)
                {
                    OrderList.Add(new OrderViewModelItem(invoice));
                }
            }
            IsHaveNoData = !OrderList.Any();
        }

        private void OpenSellView()
        {
            ScreenManager.ShowSellView(View, Token);
        }
    }
}
