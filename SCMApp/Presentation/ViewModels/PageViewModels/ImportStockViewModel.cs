using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class ImportStockViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IImportStockWebAPI _importStockWebAPI;
        public ImportStockViewModel(IImportStockWebAPI importStockWebAPI, string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _importStockWebAPI = importStockWebAPI;
            _isHaveNoData = true;
            OpenImportStockSubViewCommand = new RelayCommand(p => OpenImportStockSubView());

            ImportStockList = new ObservableCollection<ImportStockViewModelItem>() { new ImportStockViewModelItem(new ImportStock()) };

            DeleteImportStockCommand = new RelayCommand(p => DeleteImportStock((string)p));
        }

        public ICommand OpenImportStockSubViewCommand { get; set; }
        public ICommand DeleteImportStockCommand { get; set; }

        public ObservableCollection<ImportStockViewModelItem> ImportStockList { get; set; }
        public string NamePage => CommonConstants.ImportPageViewName;

        public string FunctionName => CommonConstants.ImportFunctionName;

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

        public bool IsLoaded { get; set ; }

        public void Construct()
        {
            IsLoaded = true;
            IsHaveNoData = !ImportStockList.Any();
        }

        private void OpenImportStockSubView()
        {
            ScreenManager.ShowImportStockView(View, Token);
        }

        private void DeleteImportStock(string importStockCode)
        {
            MessageBoxResult dialogResult = MessageBox.Show(View, "Bạn có muốn xoá đơn nhập hàng này ?", 
                "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
              
            }
        }
    }
}
