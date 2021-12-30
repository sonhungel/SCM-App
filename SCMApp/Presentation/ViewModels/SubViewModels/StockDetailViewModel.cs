﻿using SCMApp.Presentation.Commands;
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
        public ICommand ICancelCommand { get; }
        public ICommand ISaveCommand { get; }

        public IList<string> StocksType { get; set; }
        public string SelectedStocksType { get; set; }

        private void CancelAction()
        {
            View.Close();
        }

        private void SaveAction()
        {

        }
    }
}
