using SCMApp.Models;
using System;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class StockViewModelItem
    {
        public StockViewModelItem(Item item)
        {
            Model = item;
        }
        public Item Model;

        public string StockName => Model.Name;
        public int StockCode => Model.id;

        public int StockOriginPrice => Model.Cost;
        public int StockRetailPrice => Model.RetailPrice;

        public int Quantity => Model.Quantity;
    }
}
