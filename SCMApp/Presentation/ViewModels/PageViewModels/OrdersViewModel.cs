using SCMApp.Constants;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
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

            OrderList = new ObservableCollection<OrderViewModelItem>();
        }

        public ICommand OpenSellViewCommand { get; set; }

        public string NamePage => CommonConstants.OrdersPageViewName;

        public string FunctionName => CommonConstants.OrdersFunctionName;

        private bool _isHaveNoData;

        public ObservableCollection<OrderViewModelItem> OrderList { get; set; }
        public int OrderNumber => OrderList.Count();

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

        public void Construct()
        {
            IsLoaded = true;
            OrderList.Clear();
            using (new WaitCursorScope())
            {
                var allInvoice = _invoiceWebAPI.GetAllInvoice(Token);
                foreach (var invoice in allInvoice)
                {
                    OrderList.Add(new OrderViewModelItem(invoice));
                }
            }
            IsHaveNoData = !OrderList.Any();
            OnPropertyChanged(nameof(OrderNumber));
        }

        private void OpenSellView()
        {
            ScreenManager.ShowSellView(View, Token);
        }
    }
}
