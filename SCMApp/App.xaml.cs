using Ninject;
using SCMApp.DependencyInjection;
using SCMApp.Presentation.ViewModels;
using SCMApp.Presentation.Views;
using System;
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
            var window = new MainWindowView();
            window.DataContext = IoC.Get<MainWindowViewModel>();
            MainWindow = window;
            var dataContext = window.DataContext as MainWindowViewModel;
            if (dataContext != null)
            {
                //try
                //{
                //    dataContext.CurrentPageViewModel = dataContext.ProjectListViewModel;
                //}
                //catch (AggregateException ex)
                //{
                //    dataContext.IsHasError = true;
                //    dataContext.ErrorViewModel.ErrorName = ex.InnerException.Message;
                //    dataContext.ErrorViewModel.IsInternetCorrupted = true;
                //    dataContext.CurrentPageViewModel = dataContext.ErrorViewModel;
                //}
            }
            MainWindow.Show();
        }
    }
}
