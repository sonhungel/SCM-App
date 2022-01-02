using SCMApp.Models.DTOObject;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.MainView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILoginWebAPI _loginWebAPI;
        public LoginViewModel(ILoginWebAPI loginWebAPI,IScreenManager screenManager) : base(screenManager)
        {
            _loginWebAPI = loginWebAPI;
            ILoginCommand = new RelayCommand( p => Login());
        }
        private string _email;
        private string _password;
        public string LoginEmail 
        {
            get => _email;
            set
            {
                _email = value;
            }
        }

        public string LoginPassword
        {
            get => _password;
            set
            {
                _password = value;
            }
        }

        public ICommand ILoginCommand { get; set; }

        private void Login()
        {
            if (string.IsNullOrEmpty(_email) || string.IsNullOrEmpty(_password))
                return;
            var user = _loginWebAPI.GetUserProfile(new LoginInfo(_email, _password));
            ScreenManager.ShowMainView(View);
        }
    }
}
