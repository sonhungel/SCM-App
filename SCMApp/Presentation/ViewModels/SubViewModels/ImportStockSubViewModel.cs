using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
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
        private readonly IItemWebAPI _itemWebAPI;
        public ImportStockSubViewModel(IItemWebAPI itemWebAPI,string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _itemWebAPI = itemWebAPI;
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());
            MinusQuantityCommand = new RelayCommand(p => MinusQuantity((int)p));
            PlusQuantityCommand = new RelayCommand(p => PlusQuantity((int)p));

            ImportStockListItem = new ObservableCollection<ImportStockSubViewModelItem>();
            using (new WaitCursorScope())
            {
                ListItem = _itemWebAPI.GetAllItem(token);
            }    
            IsCreate = true;
        }
        //import Model

        public IList<Item> ListItem { get; set; }
        private Item _selectedItem;
        public Item SelectedItem 
        { 
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                if(ImportStockListItem.Any(x => x.StockCode == value.itemNumber))
                {
                    return;
                }    
                if (ImportStockListItem.Any())
                {
                    var newItemToAdd = new ImportStockSubViewModelItem(value, ImportStockListItem.LastOrDefault().OrderNumber+1);
                    ImportStockListItem.Add(newItemToAdd);
                }
                else
                {
                    var newItemToAdd = new ImportStockSubViewModelItem(value, 1);
                    ImportStockListItem.Add(newItemToAdd);
                }    
                OnPropertyChangedNoInput();
                OnPropertyChanged(nameof(TotalMoney));
                OnPropertyChanged(nameof(TotalQuantityOfStock));
            }
        }

        public ObservableCollection<ImportStockSubViewModelItem> ImportStockListItem { get; set; }

        public string ImportStockCode
        {
            get;
            set;
        }

        public int? TotalQuantityOfStock
        {
            get
            {
                int quantity = 0;
                var quantityList = ImportStockListItem.Select(x => x.Quantity).ToList();
                quantityList.ForEach(x =>
                {
                    quantity += x;
                });
                return quantity == 0 ? null : quantity;
            }
        }

        public decimal TotalMoney
        {
            get
            {
                decimal totalMoney = 0;
                var totalMoneyList = ImportStockListItem.Select(x => x.TotalPrice).ToList();
                totalMoneyList.ForEach(x =>
                {
                    totalMoney += x;
                });
                return totalMoney;
            }
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
        public bool IsCreate { get; set; }

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
            OnPropertyChanged(nameof(TotalMoney));
            OnPropertyChanged(nameof(TotalQuantityOfStock));
        }

        private void PlusQuantity(int orderNumber)
        {
            var item = ImportStockListItem.SingleOrDefault(x => x.OrderNumber == orderNumber);
            if (item != null)
            {
                item.Quantity++;
            }
            OnPropertyChanged(nameof(ImportStockListItem));
            OnPropertyChanged(nameof(TotalMoney));
            OnPropertyChanged(nameof(TotalQuantityOfStock));
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
