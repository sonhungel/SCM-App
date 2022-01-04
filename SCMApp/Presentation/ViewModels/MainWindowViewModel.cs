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

        public UserProfile MainUser { get; set; }

        public Visibility isManager => Visibility.Visible; //MainUser.Title == "Chủ cửa hàng" ? Visibility.Visible : Visibility.Hidden;

        public string MainUserName => $"Tên: {MainUser?.username}";
        public string MainUserTitle => $"Chức vụ: {MainUser?.Title}";

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
            IPageViewModel pageView = new HumanResourceManagementViewModel(Token,ScreenManager) { View = this.View};
            _allPageViewModels.Add(pageView);
            pageView = new ImportStockViewModel(Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new InventoryViewModel(Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new OrdersViewModel(Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new OverviewViewModel(Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new PartnersViewModel(Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new ProfitViewModel(Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);
            pageView = new StockViewModel(Token, ScreenManager) { View = this.View };
            _allPageViewModels.Add(pageView);

            CurrentPageViewModel = _allPageViewModels.Find(p => CommonConstants.OverviewPageViewName.Equals(p.NamePage));
            ChangePageCommand = new RelayCommand(p => ChangeViewModel((string)p), p => p is string && !p.Equals(CurrentPageViewModel.NamePage));
        }

        private void OpenUserProfileView()
        {
            ScreenManager.ShowUserProfileView(View,MainUser, Token);
        }
    }
}
