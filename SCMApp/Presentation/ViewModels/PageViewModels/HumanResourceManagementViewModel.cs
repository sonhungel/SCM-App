using SCMApp.Constants;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.PageViewModels
{
    class HumanResourceManagementViewModel : ViewModelBase, IPageViewModel
    {
        public HumanResourceManagementViewModel(IScreenManager screenManager) : base(screenManager)
        {
            _isHaveNoData = true;
            OpenInsertUserProfileViewCommand = new RelayCommand(p => OpenInsertUserProfileView());
        }

        public ICommand OpenInsertUserProfileViewCommand { get; set; }

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
    }
}
