using SCMApp.Models;
using SCMApp.Presentation.Commands;
using SCMApp.Presentation.ViewModels.Base;
using SCMApp.ViewManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace SCMApp.Presentation.ViewModels.SubViewModels
{
    public class StockDetailViewModel : ViewModelBase, IWindowViewBase
    {
        public StockDetailViewModel(string token, IScreenManager screenManager) : base(token, screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());

            StocksType = new List<string>()
            {
                "Hàng mát", "Bánh kẹo", "Thuốc lá", "Gia dụng", "Văn phòng phẩm, lưu niệm, đồ chơi",
                "Hàng đông lạnh", "Dệt may, thời trang", "Mỹ phẩm", "Hóa phẩm", "Giấy và bông",
                "Thực phẩm khô", "Đồ uống"
            };

            ItemTypes = new ObservableCollection<ItemType>()
            {
                new ItemType(0,"Hàng mát"),new ItemType(1,"Bánh kẹo"),new ItemType(2,"Thuốc lá"),new ItemType(3,"Gia dụng"),
                new ItemType(2,"Home item")
                //new ItemType(4,"Văn phòng phẩm, lưu niệm, đồ chơi"), new ItemType(5,"Hàng đông lạnh"),
                //new ItemType(6,"Mỹ phẩm"),new ItemType(7,"Giấy và bông"),new ItemType(8,"Hóa phẩm"),new ItemType(9,"Đồ uống"),
                //new ItemType(10,"Thực phẩm khô"),new ItemType(11,"Dệt may, thời trang")
            };
            Model = new Item();
        }    

        public Item Model { get; set; }

        public string StockName
        {
            get => Model.name;
            set
            {
                Model.name = value;
                OnPropertyChanged(nameof(StockName));
            }
        }
        public int StockCode
        {
            get => Model.itemNumber;
            set
            {
                Model.itemNumber = value;
                OnPropertyChanged(nameof(StockCode));
            }
        }

        public ObservableCollection<ItemType> ItemTypes { get; set; }
        public ItemType SelectedItemType 
        {
            get => Model.itemType;
            
            set
            {
                Model.itemType = value;
                OnPropertyChangedNoInput();
            }
        }
        public IList<string> StocksType { get; set; }
        public string SelectedStocksType { get; set; }

        public ObservableCollection<Partner> Partners { get; set; }
        public Partner SelectedPartner
        {
            get => Model.supplier;

            set
            {
                Model.supplier = value;
                OnPropertyChangedNoInput();
            }
        }
        public int StockCost
        {
            get => Model.cost;
            set
            {
                Model.cost = value;
                OnPropertyChanged(nameof(StockCost));
            }
        }
        public int StockRetailPrice
        {
            get => Model.salesPrice;
            set
            {
                Model.salesPrice = value;
                OnPropertyChanged(nameof(StockRetailPrice));
            }
        }
        public string SupplierName
        {
            get => Model.name;
            set
            {
                Model.name = value;
                OnPropertyChanged(nameof(SupplierName));
            }
        }
        public int StockInventoryQuantity
        {
            get => Model.quantity;
            set
            {
                Model.quantity = value;
                OnPropertyChanged(nameof(StockInventoryQuantity));
            }
        }

        public int StockMinInventoryQuantity
        {
            get => Model.minimumQuantity;
            set
            {
                Model.minimumQuantity = value;
                OnPropertyChanged(nameof(StockMinInventoryQuantity));
            }
        }
        public string StockDescription
        {
            get => Model.description;
            set
            {
                Model.description = value;
                OnPropertyChanged(nameof(StockDescription));
            }
        }
        public string Note
        {
            get => Model.remark;
            set
            {
                Model.remark = value;
                OnPropertyChanged(nameof(Note));
            }
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
