using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.MainView;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    class HumanResourceManagementViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IUserWebAPI _userWebAPI;
        public HumanResourceManagementViewModel(IUserWebAPI userWebAPI, string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _userWebAPI = userWebAPI;
            OpenInsertUserProfileViewCommand = new RelayCommand(p => OpenInsertUserProfileView());
            HRMList = new ObservableCollection<HumanResourceManagementViewModelItem>()
            {
                new HumanResourceManagementViewModelItem(new UserProfile())
            };

            EditUserCommand = new RelayCommand(p => EditUserProfile((string)p));
            DeleteUserCommand = new RelayCommand(p => DeleteUser((string)p));
        }


        public ICommand OpenInsertUserProfileViewCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        public ICommand EditUserCommand { get; set; }

        public ObservableCollection<HumanResourceManagementViewModelItem> HRMList { get; set; }

        public string NamePage => CommonConstants.HRMPageViewName;

        public string FunctionName => CommonConstants.HRMFunctionName;

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

        public UserProfile MainUser { get; set; }
        public bool IsLoaded { get ; set ; }

        public void Construct()
        {
            IsLoaded = true;
            //_userWebAPI.GetAllUserProfile();
            IsHaveNoData = !HRMList.Any();
        }

        private void OpenInsertUserProfileView()
        {
            ScreenManager.ShowInsertUserView(View,Token);
        }

        private void EditUserProfile(string p)
        {
            // get user from list => edit
            ScreenManager.ShowUserProfileView(View, null, Token);
        }

        private void DeleteUser(string p)
        {
            MessageBoxResult dialogResult = MessageBox.Show(View,"Bạn có muốn xoá nhân viên này ra khỏi hệ thống ?", 
                "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
                //_userWebAPI.DeleteUser();
            }
        }
    }
}
