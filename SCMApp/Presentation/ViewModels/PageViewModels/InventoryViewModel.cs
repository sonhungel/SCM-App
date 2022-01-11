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
    public class InventoryViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IInventoryWebAPI _inventoryWebAPI;
        private readonly IItemWebAPI _itemWebAPI;
        public InventoryViewModel(IInventoryWebAPI inventoryWebAPI, IItemWebAPI itemWebAPI,
            string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _itemWebAPI= itemWebAPI;
            _inventoryWebAPI = inventoryWebAPI;
            InventoryList = new ObservableCollection<InventoryViewModelItem>();

            ClickStockCode = new RelayCommand(p => OpenStockView((int) p));
            OpenInventoryCheckViewCommand = new RelayCommand(p => OpenInvetoryTicket());
            DeleteStockInventoryCommand = new RelayCommand(p => DeleteStockInventory((int)p));
        }

       
        public string NamePage => CommonConstants.InventoryPageViewName;

        public string FunctionName => CommonConstants.InventoryFunctionName;

        private bool _isHaveNoData;

        public bool IsHaveNoData
        {
            get => _isHaveNoData;
            set
            {
                _isHaveNoData = value;
                OnPropertyChanged(nameof(IsHaveNoData));
            }
        }
        public ICommand OpenInventoryCheckViewCommand { get; set; }
        public ICommand ClickStockCode { get; }
        public ICommand DeleteStockInventoryCommand { get; set; }

        public ObservableCollection<InventoryViewModelItem> InventoryList { get; set; }
        public bool IsLoaded { get; set; }

        public void Construct()
        {
            IsLoaded = true;
            InventoryList.Clear();
            using (new WaitCursorScope())
            {
                var inventoryTickets = _inventoryWebAPI.GetAllInventoryTicket(Token);
                foreach (var ticket in inventoryTickets)
                {
                    InventoryList.Add(new InventoryViewModelItem(ticket));
                }
            }
            IsHaveNoData = !InventoryList.Any();
        }

        private void OpenStockView(int stockCode)
        {
            var item = _itemWebAPI.GetItemByItemNumber(stockCode.ToString(), Token);
            ScreenManager.ShowStockDetailView(View,item,false, Token);
        }

        private void OpenInvetoryTicket()
        {
            ScreenManager.ShowInventoryTicket(View, Token);
        }
        private void DeleteStockInventory(int p)
        {
            MessageBoxResult dialogResult = MessageBox.Show(View,"Bạn có muốn xoá đơn kiểm kho này ?",
                "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                _inventoryWebAPI.DeleteInventoryTicket(Token);
            }
        }

    }
}
