using SCMApp.Models;
using SCMApp.Presentation.ViewModels;
using SCMApp.Presentation.ViewModels.SubViewModels;
using SCMApp.Presentation.Views;
using SCMApp.Presentation.Views.SubViews;
using SCMApp.WebAPIClient.PageViewAPIs;
using System;
using System.Windows;

namespace SCMApp.ViewManager
{
    public class ScreenManager : IScreenManager
    {
        public void ShowCustomerDetailView(Window parentWindow, Customer customer,bool isCreate, string token)
        {
            var view = new CustomerDetailView();
            var viewModel = new CustomerDetailViewModel(token, IoC.Get<IScreenManager>());
            if (customer != null)
                viewModel.Model = customer;
            viewModel.IsCreate = isCreate;
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

        public void ShowPartnerDetailView(Window parentWindow, Partner partner, bool isCreate, string token)
        {
            var view = new PartnerDetailView();
            var viewModel = new PartnerDetailViewModel(token, IoC.Get<IScreenManager>());
            if (partner != null)
                viewModel.Model = partner;
            viewModel.IsCreate = isCreate;
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.ShowDialog();
        }

        public void ShowUserProfileView(Window parentWindow, UserProfile user, bool isCreate, string token)
        {
            var view = new UserProfileView();
            var viewModel = new UserProfileViewModel(token, IoC.Get<IScreenManager>());
            if (user != null)
            {
                viewModel.Model = user;
            }
            viewModel.IsCreate = isCreate;
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            viewModel.View = view;
            view.ShowDialog();
        }

        public void ShowStockDetailView(Window parentWindow, Item item, bool isCreate, string token)
        {
            var view = new StockDetailView();
            var viewModel = new StockDetailViewModel(IoC.Get<IItemTypeWebAPI>(), IoC.Get<IPartnerWebAPI>(), IoC.Get<IItemWebAPI>(),
                token, IoC.Get<IScreenManager>());
            if(item != null)
                viewModel.Model = item;
            viewModel.IsCreate = isCreate;
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.ShowDialog();
        }

        public void ShowImportStockView(Window parentWindow, string token)
        {
            var view = new ImportStockSubView();
            var viewModel = new ImportStockSubViewModel(IoC.Get<IItemWebAPI>(), token, IoC.Get<IScreenManager>());
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.ShowDialog();
        }

        public void ShowSellView(Window parentWindow, string token)
        {
            var view = new SellView();
            var viewModel = new SellViewModel(IoC.Get<IItemWebAPI>(), IoC.Get<ICustomerWebAPI>(),
                token, IoC.Get<IScreenManager>());
            viewModel.View = view;
            view.DataContext = viewModel;
            view.Owner = parentWindow;
            view.ShowDialog();
        }

        public void ShowInventoryTicket(Window parentWindow, string token)
        {
            var view = new InventoryTicketView();
            var viewModel = new InventoryTicketViewModel(IoC.Get<IItemWebAPI>(), IoC.Get<IInventoryWebAPI>(),
                token, IoC.Get<IScreenManager>());
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
