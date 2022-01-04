using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public  class ImportStockSubViewModel : ViewModelBase, IWindowViewBase
    {
        public ImportStockSubViewModel(string token, IScreenManager screenManager) : base(token, screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());
            MinusQuantityCommand = new RelayCommand(p => MinusQuantity((int)p));
            PlusQuantityCommand = new RelayCommand(p => PlusQuantity((int)p));

            ImportStockListItem = new ObservableCollection<ImportStockSubViewModelItem>()
            {
                new ImportStockSubViewModelItem()
            };
            ListPartner = new List<Partner>();
            ListItem = new List<Item>();
        }

        public IList<Item> ListItem { get; set; }
        public Item SelectedItem 
        { 
            get; 
            set; 
        }

        public ObservableCollection<ImportStockSubViewModelItem> ImportStockListItem { get; set; }
        public IList<Partner> ListPartner { get; set; }
        public Partner SelectedPartner { get; set; }

        public string ImportStockCode
        {
            get;
            set;
        }

        public decimal TotalMoney
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }
        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        public ICommand MinusQuantityCommand { get; }
        public ICommand PlusQuantityCommand { get; }

        private void MinusQuantity(int orderNumber)
        {
            var item = ImportStockListItem.SingleOrDefault(x => x.OrderNumber == orderNumber);
            if (item != null && item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                MessageBoxResult dialogResult = MessageBox.Show("Bạn có muốn xoá mặt hàng này ra hỏi đơn nhập hàng ?", 
                    "Xác nhận hành động xoá", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    ImportStockListItem.Remove(item);
                }
            }
            OnPropertyChanged(nameof(ImportStockListItem));
        }

        private void PlusQuantity(int orderNumber)
        {
            var item = ImportStockListItem.SingleOrDefault(x => x.OrderNumber == orderNumber);
            if (item != null)
            {
                item.Quantity++;
            }
            OnPropertyChanged(nameof(ImportStockListItem));
        }


        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {

        }
    }
}
