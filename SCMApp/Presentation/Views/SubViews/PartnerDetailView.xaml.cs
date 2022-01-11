
using System.Windows;

namespace SCMApp.Presentation.Views.SubViews
{
    /// <summary>
    /// Interaction logic for PartnerDetailView.xaml
    /// </summary>
    public partial class PartnerDetailView : Window
    {
        public PartnerDetailView()
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
