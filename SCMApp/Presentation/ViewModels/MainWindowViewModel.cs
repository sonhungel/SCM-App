using SCMApp.Constants;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.PageViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
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
            IPageViewModel pageView = new HumanResourceManagementViewModel();
            pageViewModels.Add(pageView);
            pageView = new ImportStockViewModel();
            pageViewModels.Add(pageView);
            pageView = new InventoryViewModel();
            pageViewModels.Add(pageView);
            pageView = new OrdersViewModel();
            pageViewModels.Add(pageView);
            pageView = new OverviewViewModel();
            pageViewModels.Add(pageView);
            pageView = new PartnersViewModel();
            pageViewModels.Add(pageView);
            pageView = new ProfitViewModel();
            pageViewModels.Add(pageView);
            pageView = new RevenueViewModel();
            pageViewModels.Add(pageView);
            pageView = new StockViewModel();
            pageViewModels.Add(pageView);
        }
    }
}
