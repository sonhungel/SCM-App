using SCMApp.Models;
using System.Windows;

namespace SCMApp.ViewManager
{
    public interface IScreenManager
    {
        void ShowMainView(Window parentWindow, UserProfile user, string token);
        void ShowUserProfileView(Window parentWindow, UserProfile user, string token);
        void ShowCustomerDetailView(Window parentWindow, string token);
        void ShowInsertUserView(Window parentWindow, string token);
        void ShowPartnerDetailView(Window parentWindow, string token);
        void ShowStockDetailView(Window parentWindow, string token);
        void ShowImportStockView(Window parentWindow, string token);
        void ShowSellView(Window parentWindow, string token);
        void ShowInventoryTicket(Window parentWindow, string token);
        void ShowInsertStockType(Window parentWindow, string token);
    }
}
