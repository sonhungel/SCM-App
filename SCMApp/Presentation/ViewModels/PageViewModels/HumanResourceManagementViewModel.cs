using SCMApp.Constants;
using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.ViewManager;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    class HumanResourceManagementViewModel : ViewModelBase, IPageViewModel
    {
        public HumanResourceManagementViewModel(IScreenManager screenManager) : base(screenManager)
        {
            _isHaveNoData = true;
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

        public void Construct()
        {
        }

        private void OpenInsertUserProfileView()
        {
            ScreenManager.ShowInsertUserView(View);
        }

        private void EditUserProfile(string p)
        {
            ScreenManager.ShowUserProfileView(View);
        }

        private void DeleteUser(string p)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Bạn có muốn xoá nhân viên này ra khỏi hệ thống ?", "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (dialogResult == MessageBoxResult.Yes)
            {
               
            }
        }
    }
}
