using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.MainView;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    class HumanResourceManagementViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IUserWebAPI _userWebAPI;
        public HumanResourceManagementViewModel(IUserWebAPI userWebAPI, UserProfile user, string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _userWebAPI = userWebAPI;
            MainUser = user;
            OpenInsertUserProfileViewCommand = new RelayCommand(p => OpenInsertUserProfileView());
            HRMList = new ObservableCollection<HumanResourceManagementViewModelItem>();

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
            HRMList.Clear();
            using (new WaitCursorScope())
            {
                var allUser = _userWebAPI.GetAllUserProfile(Token);
                foreach (var user in allUser)
                {
                    if(user.username == MainUser.username)
                    {
                        HRMList.Add(new HumanResourceManagementViewModelItem(user,Visibility.Hidden));
                        continue;
                    }    
                    HRMList.Add(new HumanResourceManagementViewModelItem(user, Visibility.Visible));
                }
            }
            IsHaveNoData = !HRMList.Any();
            OnPropertyChanged(nameof(HRMList));
        }

        private void OpenInsertUserProfileView()
        {
            ScreenManager.ShowInsertUserView(View,Token);
        }

        private void EditUserProfile(string p)
        {
            // get user from list => edit
            var updatedUser = HRMList.SingleOrDefault(x => x.UserName == p).Model;
            ScreenManager.ShowUserProfileView(View, updatedUser, false, Token);
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
