using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SCMApp.ViewManager
{
    public interface IScreenManager
    {
        void ShowMainView(Window parentWindow);
        void ShowUserProfileView(Window parentWindow);
        void ShowCustomerDetailView(Window parentWindow);
        void ShowInsertUserView(Window parentWindow);
        void ShowPartnerDetailView(Window parentWindow);
        void ShowStockDetailView(Window parentWindow);
    }
}
