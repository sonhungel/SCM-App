using SCMApp.Constants;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class StockViewModel : ViewModelBase, IPageViewModel
    {
        public StockViewModel(IScreenManager screenManager) : base(screenManager)
        {
            _isHaveNoData = true;
            OpenStockDetailViewCommand = new RelayCommand(p => OpenStockDetailView());
        }

        public ICommand OpenStockDetailViewCommand { get; set; }

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

        public void Construct()
        {
        }
        private void OpenStockDetailView()
        {
            ScreenManager.ShowStockDetailView(View);
        }
    }
}
