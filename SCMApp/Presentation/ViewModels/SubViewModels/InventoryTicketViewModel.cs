using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class InventoryTicketViewModel : ViewModelBase, IWindowViewBase
    {
        public InventoryTicketViewModel(IScreenManager screenManager) : base(screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());

            ListStock = new List<Stock>();
        }
        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        public string ImportStockCode 
        { 
            get; 
            set; 
        }

        public string StockCode 
        {
            get;
            set;
        }
        public string StockName
        {
            get;
            set;
        }
        public string StockInventory
        {
            get;
            set;
        }

        public IList<Stock> ListStock { get; set; }
        public Stock SelectedStock
        {
            get;
            set;
        }

        public string FactQuantity { get; set; }
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
