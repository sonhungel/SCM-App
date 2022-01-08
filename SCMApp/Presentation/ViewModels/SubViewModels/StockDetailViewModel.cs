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

            ItemTypes = new List<ItemType>()
            {
                new ItemType(0,"Hàng mát"),new ItemType(1,"Bánh kẹo"),new ItemType(2,"Thuốc lá"),new ItemType(3,"Gia dụng"),
                new ItemType(4,"Văn phòng phẩm, lưu niệm, đồ chơi"), new ItemType(5,"Hàng đông lạnh"),
                new ItemType(6,"Mỹ phẩm"),new ItemType(7,"Giấy và bông"),new ItemType(8,"Hóa phẩm"),new ItemType(9,"Đồ uống"),
                new ItemType(10,"Thực phẩm khô"),new ItemType(11,"Dệt may, thời trang")
            };
        }    

        public Item Model { get; set; }

        public string StockName
        {
            get;
            set;
        }
        public string StockCode
        {
            get;
            set;
        }

        public IList<ItemType> ItemTypes { get; set; }
        public ItemType SelectedItemType { get; set; }
        public IList<string> StocksType { get; set; }
        public string SelectedStocksType { get; set; }
        public int StockCost
        {
            get;
            set;
        }
        public int StockRetailPrice
        {
            get;
            set;
        }
        public string SupplierName
        {
            get;
            set;
        }
        public int StockInventoryQuantity
        {
            get;
            set;
        }
        public int StockMaxInventoryQuantity
        {
            get;
            set;
        }
        public int StockMinInventoryQuantity
        {
            get;
            set;
        }
        public string StockDescription
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


        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {

        }
    }
}
