using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.ViewManager;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class OrdersViewModel : ViewModelBase, IPageViewModel
    {
        public OrdersViewModel(string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _isHaveNoData = true;
            OpenSellViewCommand = new RelayCommand(p => OpenSellView());
            DeleteOrderCommand = new RelayCommand(p => DeleteOrder((string)p));

            OrderList = new ObservableCollection<OrderViewModelItem>()
            {
                new OrderViewModelItem( new Order()
                {
                    OrderCode = "12312",
                    OrderTime = DateTime.Now,
                    CustomerName = "Sonhungel",
                    TotalPrice = 33333,
                    CustomerPaid = 40000
                })
               
            };
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

        private void DeleteOrder(string oderCode)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Bạn có muốn xoá hoá đơn này ?", "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                OnPropertyChanged(nameof(OrderList));
            }
        }
        public void Construct()
        {
        }

        private void OpenSellView()
        {
            ScreenManager.ShowSellView(View, Token);
        }
    }
}
