using SCMApp.Constants;
using SCMApp.Models;
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
    public class StockViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IItemWebAPI _itemWebAPI;
        public StockViewModel(IItemWebAPI itemWebAPI, UserProfile userProfile, string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _itemWebAPI = itemWebAPI;
            _isHaveNoData = true;
            MainUser = userProfile;
            OpenStockDetailViewCommand = new RelayCommand(p => OpenStockDetailView());
            OpenInsertStockTypeViewCommand = new RelayCommand(p => OpenInsertStockTypeView());
            StockList = new ObservableCollection<StockViewModelItem>();

            EditStockCommand = new RelayCommand(p => EditStock((int)p));
            DeleteStockCommand = new RelayCommand(p => DeleteStock((int)p));
        }

        public ICommand OpenStockDetailViewCommand { get; set; }
        public ICommand OpenInsertStockTypeViewCommand { get; set; }
        public ICommand EditStockCommand { get; set; }
        public ICommand DeleteStockCommand { get; set; }

        public UserProfile MainUser { get; set; }

        public Visibility isManager => MainUser.role == "Quản lý" ? Visibility.Visible : Visibility.Collapsed;

        public ObservableCollection<StockViewModelItem> StockList { get; set; }
        public int StockNumber => StockList.Count();
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
            StockList.Clear();
            using (new WaitCursorScope())
            {
                var allitem = _itemWebAPI.GetAllItem(Token);
                foreach (var item in allitem)
                {
                    StockList.Add(new StockViewModelItem(item));
                }
            }
            IsHaveNoData = !StockList.Any();
            OnPropertyChanged(nameof(StockNumber));

        }
        private void OpenStockDetailView()
        {
            ScreenManager.ShowStockDetailView(View,null,true, Token);
        }
        private void OpenInsertStockTypeView()
        {
            ScreenManager.ShowInsertStockType(View, Token);
        }

        private void EditStock(int stockCode)
        {
            var updateItem = StockList.SingleOrDefault(x => x.StockCode == stockCode).Model;
            ScreenManager.ShowStockDetailView(View, updateItem, false, Token);
        }
        private void DeleteStock(int stockCode)
        {
            MessageBoxResult dialogResult = MessageBox.Show(View,"Bạn có muốn xoá mặt hàng này ?", 
                "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                using (new WaitCursorScope())
                {
                    var r = _itemWebAPI.DeleteItem(stockCode.ToString(), Token);
                }
            }
        }
    }
}
