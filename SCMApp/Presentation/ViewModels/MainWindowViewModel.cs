using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.PageViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _allPageViewModels = new List<IPageViewModel>();
            InitAllPageViewModel(_allPageViewModels);

            ChangePageCommand = new RelayCommand(p => ChangeViewModel((IPageViewModel)p), p => p is IPageViewModel);
        }

        private IPageViewModel _currentPageViewModel;

        private List<IPageViewModel> _allPageViewModels;

        public IPageViewModel CurrentPageViewModel 
        {
            get => _currentPageViewModel;
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged(nameof(CurrentPageViewModel));
                }
            }
        }

        public ICommand ChangePageCommand { get; set; }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            // new view => constuct
            // old view => destruct to clear list
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
