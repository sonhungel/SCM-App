using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.Presentation.ViewModels.ItemsViewModel;
using SCMApp.Presentation.Views;
using SCMApp.ViewManager;
using SCMApp.WebAPIClient.PageViewAPIs;
using SCMApp.WebAPIClient.Request_Response;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class ImportStockSubViewModel : SubViewModelBase, IWindowViewBase
    {
        private readonly IItemWebAPI _itemWebAPI;
        private readonly IImportStockWebAPI _importStockWebAPI;
        public ImportStockSubViewModel(IItemWebAPI itemWebAPI, IImportStockWebAPI importStockWebAPI,
            string token, IScreenManager screenManager) : base(token, screenManager)
        {
            _itemWebAPI = itemWebAPI;
            _importStockWebAPI = importStockWebAPI;
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p =>
            {
                ValidateAllProperty();
                if (!HasErrors)
                {
                    SaveAction();
                }
            });
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
                if (ImportStockListItem.Any(x => x.StockCode == value.itemNumber))
                {
                    return;
                }
                var newItemToAdd = new ImportStockSubViewModelItem(value);
                ImportStockListItem.Add(newItemToAdd);

                OnPropertyChangedNoInput();
                OnPropertyChanged(nameof(TotalMoney));
                OnPropertyChanged(nameof(TotalQuantityOfStock));
                OnPropertyChanged(nameof(IsHaveNoItemToImport));
            }
        }

        public ObservableCollection<ImportStockSubViewModelItem> ImportStockListItem { get; set; }

        public bool IsHaveNoItemToImport => !ImportStockListItem.Any();

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

        public string Note { get; set; }
        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        public ICommand MinusQuantityCommand { get; }
        public ICommand PlusQuantityCommand { get; }

        protected override void ValidateAllProperty()
        {
            CleanUpError(nameof(ImportStockListItem));
            if (ImportStockListItem.Count <= 0)
            {
                AddError(nameof(ImportStockListItem), "Phải chọn mặt hàng cần nhập.");
            }
        }

        public bool IsCreate { get; set; }

        private void MinusQuantity(int stockCode)
        {
            var item = ImportStockListItem.SingleOrDefault(x => x.StockCode == stockCode);
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
            OnPropertyChanged(nameof(IsHaveNoItemToImport));
        }

        private void PlusQuantity(int stockCode)
        {
            var item = ImportStockListItem.SingleOrDefault(x => x.StockCode == stockCode);
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
            using (new WaitCursorScope())
            {
                var createImportStock = new CreateImportStockDTO()
                {
                    supplier =new SupplierId() { id = SelectedItem.supplier.id},
                    item = new ItemId() {id = SelectedItem.id},
                    quantity = TotalQuantityOfStock.Value,
                    cost = TotalMoney,
                    remark = Note,
                };
                var r = _importStockWebAPI.CreateImportStock(createImportStock, Token);
            }
            View.Close();
        }
    }
}
