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
        public InventoryTicketViewModel(string token, IScreenManager screenManager) : base(token, screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());

            ListItem = new List<Item>();
            Model = new Inventory();
        }
        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }
        public Inventory Model { get; set; }

        public string ImportStockCode 
        { 
            get;
            set; 
        }

        public int StockCode => SelectedItem.id;
        public string StockName => SelectedItem.Name;
        public string StockInventoryQuantity
        {
            get;
            set;
        }

        public IList<Item> ListItem { get; set; }
        public Item SelectedItem
        {
            get => Model.Item;
            set
            {
                Model.Item = value;
                OnPropertyChanged(nameof(StockCode));
                OnPropertyChanged(nameof(StockName));
            }
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
