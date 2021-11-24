using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(IScreenManager screenManager) : base(screenManager)
        {
            ILoginCommand = new RelayCommand( p => Login());
        }

        public string LoginEmail { get; set; }

        public string LoginPassword { get; set; }

        public ICommand ILoginCommand { get; set; }

        private void Login()
        {
            ScreenManager.ShowMainView(View);
        }
    }
}
