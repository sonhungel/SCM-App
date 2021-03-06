using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.MainView;
using SCMApp.WebAPIClient.Request_Response;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IUserWebAPI _userWebAPI;
        public LoginViewModel(IUserWebAPI userWebAPI,IScreenManager screenManager) : base(string.Empty,screenManager)
        {
            _userWebAPI = userWebAPI;
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
            {
                MessageBox.Show(View,"Bạn chưa nhập Tên đăng nhập hoặc Mật Khẩu?", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            using (new WaitCursorScope())
            {
                var token = _userWebAPI.GetToken(new LoginRequest(_email, _password));
                var user = _userWebAPI.GetUserProfileBaseOnToken(_email, token.token);
                ScreenManager.ShowMainView(View, user, token.token);
            }
        }
    }
}
