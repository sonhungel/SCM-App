using Ninject;
using SCMApp.DependencyInjection;
using SCMApp.Presentation.ViewModels; 
using SCMApp.Presentation.Views; 
using System.Windows;

namespace SCMApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Initialize DI / IoC
            IoC.Initialize(
                new StandardKernel(new NinjectSettings { LoadExtensions = true }),
                new ClientBindingModule());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var window = new LoginView();
            var viewModel = IoC.Get<LoginViewModel>();
            viewModel.View = window;
            window.DataContext = viewModel;
            MainWindow = window;

            MainWindow.Show();
        }
    }
}
