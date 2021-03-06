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
            PageNumber = 1;
            NextPageCommand = new RelayCommand(p => NextViewAction());
            PreviousPageCommand = new RelayCommand(p => PreviousAction());
        }

        public ICommand OpenSellViewCommand { get; set; }

        public ICommand NextPageCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }

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
        public bool IsHasNextPage
        {
            get;set;
        }
        public bool IsHasPreviousPage
        {
            get; set;
        }
        public int PageNumber
        {
            get;set;
        }

        public void Construct()
        {
            IsLoaded = true;
            OrderList.Clear();
            using (new WaitCursorScope())
            {
                var dataInvoice = _invoiceWebAPI.GetAllInvoice(PageNumber-1,Token);
                IsHasNextPage = dataInvoice.hasNext;
                IsHasPreviousPage = dataInvoice.hasPrevious;

                foreach (var invoice in dataInvoice.data)
                {
                    OrderList.Add(new OrderViewModelItem(invoice));
                }
            }
            IsHaveNoData = !OrderList.Any();
            OnPropertyChanged(nameof(OrderNumber));
            OnPropertyChanged(nameof(IsHasNextPage));
            OnPropertyChanged(nameof(IsHasPreviousPage));
            OnPropertyChanged(nameof(PageNumber));
        }

        private void OpenSellView()
        {
            ScreenManager.ShowSellView(View, Token);
        }

        private void NextViewAction()
        {
            PageNumber += 1;
            Construct();
        }
        private void PreviousAction()
        {
            PageNumber -= 1;
            Construct();
        }

    }
}
