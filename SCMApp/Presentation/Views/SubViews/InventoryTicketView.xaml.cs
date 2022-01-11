
using System.Windows;

namespace SCMApp.Presentation.Views.SubViews
{
    /// <summary>
    /// Interaction logic for InventoryTicketView.xaml
    /// </summary>
    public partial class InventoryTicketView : Window
    {
        public InventoryTicketView()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            DataContext = null;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
