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
    public class ImportStockViewModel : ViewModelBase, IPageViewModel
    {
        public ImportStockViewModel(IScreenManager screenManager) : base(screenManager)
        {
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

        public void Construct()
        {
        }

        private void OpenImportStockSubView()
        {
            ScreenManager.ShowImportStockView(View);
        }

        private void DeleteImportStock(string importStockCode)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Bạn có muốn xoá đơn nhập hàng này ?", "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
              
            }
        }
    }
}
