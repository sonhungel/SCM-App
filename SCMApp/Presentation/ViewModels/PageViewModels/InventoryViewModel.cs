using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class InventoryViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IInventoryWebAPI _inventoryWebAPI;
        public InventoryViewModel(IInventoryWebAPI inventoryWebAPI,string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _inventoryWebAPI = inventoryWebAPI;
            InventoryList = new ObservableCollection<InventoryViewModelItem>() { new InventoryViewModelItem() };

            ClickStockCode = new RelayCommand(p => OpenStockView((string) p));
            OpenInventoryCheckViewCommand = new RelayCommand(p => OpenInvetoryTicket());
            DeleteStockInventoryCommand = new RelayCommand(p => DeleteStockInventory((string)p));
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
            // get all inventoryticket
            IsHaveNoData = !InventoryList.Any();
        }

        private void OpenStockView(string stockCode)
        {
            ScreenManager.ShowStockDetailView(View,null, Token);
        }

        private void OpenInvetoryTicket()
        {
            // get inventoryCode from api
            ScreenManager.ShowInventoryTicket(View, Token);
        }
        private void DeleteStockInventory(string p)
        {
            MessageBoxResult dialogResult = MessageBox.Show(View,"Bạn có muốn xoá đơn kiểm kho này ?",
                "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                _inventoryWebAPI.DeleteInventoryTicket();
            }
        }

    }
}
