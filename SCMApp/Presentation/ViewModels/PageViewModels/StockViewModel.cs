﻿using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class StockViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IItemWebAPI _itemWebAPI;
        public StockViewModel(IItemWebAPI itemWebAPI,string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _itemWebAPI = itemWebAPI;
            _isHaveNoData = true;
            OpenStockDetailViewCommand = new RelayCommand(p => OpenStockDetailView());
            OpenInsertStockTypeViewCommand = new RelayCommand(p => OpenInsertStockTypeView());
            StockList = new ObservableCollection<StockViewModelItem>() { new StockViewModelItem(new Item())};

            EditStockCommand = new RelayCommand(p => EditStock((int)p));
            DeleteStockCommand = new RelayCommand(p => DeleteStock((int)p));
        }

        public ICommand OpenStockDetailViewCommand { get; set; }
        public ICommand OpenInsertStockTypeViewCommand { get; set; }
        public ICommand EditStockCommand { get; set; }
        public ICommand DeleteStockCommand { get; set; }

        public ObservableCollection<StockViewModelItem> StockList { get; set; }
        public string NamePage => CommonConstants.StockPageViewName;

        public string FunctionName => CommonConstants.StockFunctionName;

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

        public bool IsLoaded { get; set; }

        public void Construct()
        {
            IsLoaded = true;
            IsHaveNoData = !StockList.Any();
        }
        private void OpenStockDetailView()
        {
            ScreenManager.ShowStockDetailView(View, Token);
        }
        private void OpenInsertStockTypeView()
        {
            ScreenManager.ShowInsertStockType(View, Token);
        }

        private void EditStock(int stockCode)
        {
            var updateItem =  _itemWebAPI.GetItemByItemNumber(new GetItemByNumberRequest(123), Token);
            ScreenManager.ShowStockDetailView(View, Token);
        }
        private void DeleteStock(int stockCode)
        {
            MessageBoxResult dialogResult = MessageBox.Show(View,"Bạn có muốn xoá mặt hàng này ?", 
                "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {

            }
        }
    }
}
