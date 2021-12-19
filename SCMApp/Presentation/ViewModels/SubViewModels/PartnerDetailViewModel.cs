using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class PartnerDetailViewModel : ViewModelBase, IWindowViewBase
    {
        public PartnerDetailViewModel(IScreenManager screenManager) : base(screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());
        }

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {

        }
    }
}
