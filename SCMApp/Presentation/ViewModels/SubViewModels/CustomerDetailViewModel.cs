using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;
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

        private Customer Model;
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerPhoneNumber { get;set; }
        public string CustomerEmail { get; set; }
        public DateTime CustomerBirthDay { get; set; }
        public string TaxCode { get; set; }
        public bool IndividualCustomer { get; set; }
        public bool EnterpriseCustomer { get; set; }
        public List<string> Gender { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {

        }
    }
}
