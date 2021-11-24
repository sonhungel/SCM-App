using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class CustomerDetailViewModel : ViewModelBase, IWindowViewBase
    {
        public CustomerDetailViewModel(IScreenManager screenManager) : base(screenManager) 
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());
        }

        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        private void CancelAction()
        {

        }

        private void SaveAction()
        {

        }
    }
}
