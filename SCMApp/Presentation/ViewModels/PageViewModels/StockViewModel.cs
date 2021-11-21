using SCMApp.Constants;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class StockViewModel : ViewModelBase, IPageViewModel
    {
        public StockViewModel(IScreenManager screenManager) : base(screenManager)
        {
            _isHaveNoData = true;
        }
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
    }
}
