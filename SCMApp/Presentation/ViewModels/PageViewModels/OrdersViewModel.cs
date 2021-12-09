using SCMApp.Constants;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    public class OrdersViewModel : ViewModelBase, IPageViewModel
    {
        public OrdersViewModel(IScreenManager screenManager) : base(screenManager)
        {
            _isHaveNoData = true;
            OpenSellViewCommand = new RelayCommand(p => OpenSellView());
        }

        public ICommand OpenSellViewCommand { get; set; }

        public string NamePage => CommonConstants.OrdersPageViewName;

        public string FunctionName => CommonConstants.OrdersFunctionName;

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

        private void OpenSellView()
        {
            ScreenManager.ShowSellView(View);
        }
    }
}
