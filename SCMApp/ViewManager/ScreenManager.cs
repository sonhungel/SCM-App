using SCMApp.Presentation.ViewModels.SubViewModels;
using SCMApp.Presentation.Views.SubViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.ViewManager
{
    public class ScreenManager : IScreenManager
    {
        public void ShowUserProfileView()
        {
            var view = new UserProfileView();
            var viewModel = IoC.Get<UserProfileViewModel>();
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
