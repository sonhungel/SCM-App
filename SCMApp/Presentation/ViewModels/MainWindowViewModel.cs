using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.PageViewModels;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.MainView;
using SCMApp.WebAPIClient.PageViewAPIs;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _allPageViewModels = new List<IPageViewModel>();
            OpenUserProfileCommand = new RelayCommand(p => OpenUserProfileView());
            MainUser = new UserProfile();
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

        public ICommand RefreshCommand { get; set; }

        public UserProfile MainUser { get; set; }

        public Visibility isManager => MainUser.role == "Quản lý" ? Visibility.Visible : Visibility.Collapsed;

        public string MainUserName => $"Tên: {MainUser?.fullName}";
        public string MainUserTitle => $"Chức vụ: {MainUser?.role}";

        private void ChangeViewModel(string pageName)
        {
            CurrentPageViewModel = _allPageViewModels.Find(p => pageName.Equals(p.NamePage));
            OnPropertyChanged(nameof(FunctionName));
            if (!CurrentPageViewModel.IsLoaded)
            {
                CurrentPageViewModel.Construct();
            }
        }

        private void Refresh()
        {
            _allPageViewModels.ForEach(x => x.IsLoaded = false);
            CurrentPageViewModel.Construct();
        }

        public void InitAllPageViewModel()
        {
            IPageViewModel pageView = new HumanResourceManagementViewModel(IoC.Get<IUserWebAPI>(),MainUser, Token,ScreenManager) { View = this.View};
            _allPageViewModels.Add(pageView);
            pageView = new ImportStockViewModel(IoC.Get<IImportStockWebAPI>(),Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new InventoryViewModel(IoC.Get<IInventoryWebAPI>(),IoC.Get<IItemWebAPI>(), Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new OrdersViewModel(IoC.Get<IInvoiceWebAPI>(),Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new OverviewViewModel(IoC.Get<IProfitWebAPI>(), IoC.Get<IUserWebAPI>(), IoC.Get<IInventoryWebAPI>(),
                Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new PartnersViewModel(IoC.Get<ICustomerWebAPI>(), IoC.Get<IPartnerWebAPI>(),Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new ProfitViewModel(IoC.Get<IProfitWebAPI>(),Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new StockViewModel(IoC.Get<IItemWebAPI>(),MainUser,Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);

            if (MainUser.role == "Quản lý")
            {
                ChangeViewModel(CommonConstants.OverviewPageViewName);
            }
            else
            {
                ChangeViewModel(CommonConstants.OrdersPageViewName);
            }    
            ChangePageCommand = new RelayCommand(p => ChangeViewModel((string)p), p => p is string && !p.Equals(CurrentPageViewModel.NamePage));
            RefreshCommand = new RelayCommand(p => Refresh(), p => _allPageViewModels.Any(x => x.IsLoaded == true));
        }

        private void OpenUserProfileView()
        {
            ScreenManager.ShowUserProfileView(View, MainUser, false,false, Token);
        }
    }
}
