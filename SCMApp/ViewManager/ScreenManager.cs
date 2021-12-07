using SCMApp.Presentation.ViewModels;
using SCMApp.Presentation.ViewModels.SubViewModels;
using SCMApp.Presentation.Views;
using SCMApp.Presentation.Views.SubViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SCMApp.ViewManager
{
    public class ScreenManager : IScreenManager
    {
        public void ShowCustomerDetailView(Window parentWindow)
        {
            var view = new CustomerDetailView();
            var viewModel = IoC.Get<CustomerDetailViewModel>();
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.Show();
        }

        public void ShowInsertUserView(Window parentWindow)
        {
            var view = new InsertUserProfileView();
            var viewModel = IoC.Get<InsertUserProfileViewModel>();
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.Show();
        }

        public void ShowMainView(Window parentWindow)
        {
            var view = new MainWindowView();
            var viewModel = IoC.Get<MainWindowViewModel>();
            viewModel.View = view;
            viewModel.InitAllPageViewModel();
            view.DataContext = viewModel;
            view.Show();
            parentWindow.Close();
            parentWindow.DataContext = null;
            parentWindow = null;
            GC.Collect();
        }

        public void ShowPartnerDetailView(Window parentWindow)
        {
            var view = new PartnerDetailView();
            var viewModel = IoC.Get<PartnerDetailViewModel>();
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.Show();
        }

        public void ShowUserProfileView(Window parentWindow)
        {
            var view = new UserProfileView();
            var viewModel = IoC.Get<UserProfileViewModel>();
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.Show();
        }

        public void ShowStockDetailView(Window parentWindow)
        {
            var view = new StockDetailView();
            var viewModel = IoC.Get<StockDetailViewModel>();
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.Show();
        }
    }
}
