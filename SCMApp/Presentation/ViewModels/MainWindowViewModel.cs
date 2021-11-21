using SCMApp.Constants;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.PageViewModels;
using SCMApp.ViewManager;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IScreenManager screenManager) : base(screenManager)
        {
            _allPageViewModels = new List<IPageViewModel>();
            InitAllPageViewModel(_allPageViewModels);
            CurrentPageViewModel = _allPageViewModels.Find(p => CommonConstants.OverviewPageViewName.Equals(p.NamePage));

            ChangePageCommand = new RelayCommand(p => ChangeViewModel((string)p), p => p is string && !p.Equals(CurrentPageViewModel.NamePage));
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

        private void ChangeViewModel(string pageName)
        {
            // destruct
            //CurrentPageViewModel.destruct
            CurrentPageViewModel = _allPageViewModels.Find(p => pageName.Equals(p.NamePage));
            OnPropertyChanged(nameof(FunctionName));
            CurrentPageViewModel.Construct();
        }

        private void InitAllPageViewModel(List<IPageViewModel> pageViewModels)
        {
            IPageViewModel pageView = new HumanResourceManagementViewModel(ScreenManager);
            pageViewModels.Add(pageView);
            pageView = new ImportStockViewModel(ScreenManager);
            pageViewModels.Add(pageView);
            pageView = new InventoryViewModel(ScreenManager);
            pageViewModels.Add(pageView);
            pageView = new OrdersViewModel(ScreenManager);
            pageViewModels.Add(pageView);
            pageView = new OverviewViewModel(ScreenManager);
            pageViewModels.Add(pageView);
            pageView = new PartnersViewModel(ScreenManager);
            pageViewModels.Add(pageView);
            pageView = new ProfitViewModel(ScreenManager);
            pageViewModels.Add(pageView);
            //pageView = new RevenueViewModel();
            //pageViewModels.Add(pageView);
            pageView = new StockViewModel(ScreenManager);
            pageViewModels.Add(pageView);
        }
    }
}
