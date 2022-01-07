using SCMApp.Models;
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
        public void ShowCustomerDetailView(Window parentWindow, string token)
        {
            var view = new CustomerDetailView();
            var viewModel = new CustomerDetailViewModel(token, IoC.Get<IScreenManager>());
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.ShowDialog();
        }

        public void ShowInsertUserView(Window parentWindow, string token)
        {
            var view = new InsertUserProfileView();
            var viewModel = new InsertUserProfileViewModel(token, IoC.Get<IScreenManager>());
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.ShowDialog();
        }

        public void ShowMainView(Window parentWindow, UserProfile user, string token)
        {
            var view = new MainWindowView();
            var viewModel = new MainWindowViewModel(token,IoC.Get<IScreenManager>());
            viewModel.View = view;
            viewModel.MainUser = user;
            viewModel.InitAllPageViewModel();
            view.DataContext = viewModel;
            view.Show();
            parentWindow.Close();
            parentWindow.DataContext = null;
            parentWindow = null;
            GC.Collect();
        }

        public void ShowPartnerDetailView(Window parentWindow, string token)
        {
            var view = new PartnerDetailView();
            var viewModel = new PartnerDetailViewModel(token, IoC.Get<IScreenManager>());
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.ShowDialog();
        }

        public void ShowUserProfileView(Window parentWindow, UserProfile user, string token)
        {
            var view = new UserProfileView();
            var viewModel = new UserProfileViewModel(token, IoC.Get<IScreenManager>());
            if (user != null)
            {
                viewModel.Model = user;
            }
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            viewModel.View = view;
            view.ShowDialog();
        }

        public void ShowStockDetailView(Window parentWindow, string token)
        {
            var view = new StockDetailView();
            var viewModel = new StockDetailViewModel(token, IoC.Get<IScreenManager>());
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.ShowDialog();
        }

        public void ShowImportStockView(Window parentWindow, string token)
        {
            var view = new ImportStockSubView();
            var viewModel = new ImportStockSubViewModel(token, IoC.Get<IScreenManager>());
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.ShowDialog();
        }

        public void ShowSellView(Window parentWindow, string token)
        {
            var view = new SellView();
            var viewModel = new SellViewModel(token, IoC.Get<IScreenManager>());
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.ShowDialog();
        }

        public void ShowInventoryTicket(Window parentWindow, string token)
        {
            var view = new InventoryTicketView();
            var viewModel = new InventoryTicketViewModel(token, IoC.Get<IScreenManager>());
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.ShowDialog();
        }

        public void ShowInsertStockType(Window parentWindow, string token)
        {
            var view = new InsertStockTypeView();
            var viewModel = new InsertStockTypeViewModel(token, IoC.Get<IScreenManager>());
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.ShowDialog();
        }
    }
}
