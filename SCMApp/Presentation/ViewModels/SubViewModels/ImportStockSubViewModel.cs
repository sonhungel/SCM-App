using SCMApp.Presentation.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public  class ImportStockSubViewModel
    {
        public ImportStockSubViewModel()
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
