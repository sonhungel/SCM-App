using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.PageViewModels;
using SCMApp.ViewManager;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IScreenManager screenManager) : base(screenManager)
        {
            _allPageViewModels = new List<IPageViewModel>();
            OpenUserProfileCommand = new RelayCommand(p => OpenUserProfileView());
        }

        private IPageViewModel _currentPageViewModel;

        private List<IPageViewModel> _allPageViewModels;

        public IPageViewModel CurrentPageViewModel 
        {
            get => _currentPageViewModel;
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged(nameof(CurrentPageViewModel));
            }
        }

        public string FunctionName => CurrentPageViewModel?.FunctionName;

        public ICommand ChangePageCommand { get; set; }
        public ICommand OpenUserProfileCommand { get; set; }

        public UserProfile MainUser { get; set; }

        private void ChangeViewModel(string pageName)
        {
            // destruct
            //CurrentPageViewModel.destruct
            CurrentPageViewModel = _allPageViewModels.Find(p => pageName.Equals(p.NamePage));
            OnPropertyChanged(nameof(FunctionName));
            CurrentPageViewModel.Construct();
        }

        public void InitAllPageViewModel()
        {
            IPageViewModel pageView = new HumanResourceManagementViewModel(ScreenManager) { View = this.View};
            _allPageViewModels.Add(pageView);
            pageView = new ImportStockViewModel(ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new InventoryViewModel(ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new OrdersViewModel(ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new OverviewViewModel(ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new PartnersViewModel(ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new ProfitViewModel(ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            //pageView = new RevenueViewModel();
            //pageViewModels.Add(pageView);
            pageView = new StockViewModel(ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);

            CurrentPageViewModel = _allPageViewModels.Find(p => CommonConstants.OverviewPageViewName.Equals(p.NamePage));
            ChangePageCommand = new RelayCommand(p => ChangeViewModel((string)p), p => p is string && !p.Equals(CurrentPageViewModel.NamePage));
        }

        private void OpenUserProfileView()
        {
            ScreenManager.ShowUserProfileView(View);
        }
    }
}
