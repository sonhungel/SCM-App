using SCMApp.Models;
using System;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class StockViewModelItem
    {
        public StockViewModelItem(Stock stock)
        {
            Model = stock;
        }
        public Stock Model;

        public string StockName => Model.StockName;
        public string StockCode => Model.StockCode;

        public int StockOriginPrice => Model.StockOriginPrice;
        public int StockRetailPrice => Model.StockRetailPrice;

        public int Quantity => 15;
    }
}
