using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;

namespace SCMApp.Presentation.Views
{
    public class WaitingSpinner : IDisposable
    {
        public WaitingSpinner(Window parentWindow)
        {
            
            Thread viewerThread = new Thread(delegate ()
            {
                LoadingSpinnerView = new LoadingView();
                LoadingSpinnerView.Topmost = true;
                LoadingSpinnerView.Show();
                System.Windows.Threading.Dispatcher.Run();
            });

            viewerThread.SetApartmentState(ApartmentState.STA); // needs to be STA or throws exception
            viewerThread.Start();
            viewerThread.Join();
        }
        private LoadingView LoadingSpinnerView;
        public void Dispose()
        {
            LoadingSpinnerView.Close();
        }
    }
}
