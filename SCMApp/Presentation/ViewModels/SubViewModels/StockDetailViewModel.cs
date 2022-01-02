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
        public StockDetailViewModel(IScreenManager screenManager) : base(screenManager)
        {
            ICancelCommand = new RelayCommand(p => CancelAction());
            ISaveCommand = new RelayCommand(p => SaveAction());

            StocksType = new List<string>()
            {
                "Hàng mát", "Bánh kẹo", "Thuốc lá", "Gia dụng", "Văn phòng phẩm, lưu niệm, đồ chơi",
                "Hàng đông lạnh", "Dệt may, thời trang", "Mỹ phẩm", "Hóa phẩm", "Giấy và bông",
                "Thực phẩm khô", "Đồ uống"
            };
        }    

        public Stock Model { get; set; }

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
        public string ProducerName
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
