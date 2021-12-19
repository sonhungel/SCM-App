using SCMApp.Constants;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.ViewManager;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class InventoryViewModel : ViewModelBase, IPageViewModel
    {
        public InventoryViewModel(IScreenManager screenManager) : base(screenManager)
        {
            _isHaveNoData = true;
            InventoryList = new ObservableCollection<InventoryViewModelItem>() { new InventoryViewModelItem() };

            ClickStockCode = new RelayCommand(p => OpenStockView((string) p));
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

        public ObservableCollection<InventoryViewModelItem> InventoryList { get; set; }

        public void Construct()
        {
        }

        private void OpenStockView(string stockCode)
        {
            ScreenManager.ShowStockDetailView(View);
        }
    }
}
