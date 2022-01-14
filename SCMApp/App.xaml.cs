using Ninject;
using SCMApp.Constants;
using SCMApp.DependencyInjection;
using SCMApp.Presentation.ViewModels; 
using SCMApp.Presentation.Views;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

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
            // Load config for log4net
            log4net.Config.XmlConfigurator.Configure();

            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainUnhandledException;
            Dispatcher.UnhandledException += OnDispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += OnTaskSchedulerUnobservedTaskException;
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


        private void OnTaskSchedulerUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            var exception = e.Exception as AggregateException;
            // If internet interrupted
            if (exception.Message.Contains(ExceptionConstants.ConnectExceptionExceptionMessage))
            {
                MessageBox.Show("Không thể kết nối tới server!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            //LoginFail
            if(exception.Message.Contains(ExceptionConstants.LoginFailExceptionMessage))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (exception.Message.Contains(ExceptionConstants.ConcurrentupdateExceptionMessage))
            {
                MessageBox.Show(@"Không thể cập nhật sản phẩm! 
Có một người dùng khác đã tiến hành chỉnh sửa trước, vui lòng làm mới", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            e.SetObserved();
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var exception = e.Exception as AggregateException;
            // If internet interrupted
            if (exception.Message.Contains(ExceptionConstants.ConnectExceptionExceptionMessage))
            {
                MessageBox.Show("Không thể kết nối tới server!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            //LoginFail
            if (exception.InnerException.Message.Contains(ExceptionConstants.LoginFailExceptionMessage))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai!", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (exception.Message.Contains(ExceptionConstants.ConcurrentupdateExceptionMessage))
            {
                MessageBox.Show(@"Không thể cập nhật sản phẩm! 
Có một người dùng khác đã tiến hành chỉnh sửa trước, vui lòng làm mới", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            e.Handled = true;
        }

        private void OnCurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as AggregateException;
            if (exception != null)
            {
                Console.WriteLine(exception.InnerException.Message);
                Console.WriteLine("CO EXCEPTION");
            }
        }
    }
}
