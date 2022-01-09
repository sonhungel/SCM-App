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

        public string StockName => Model.name;
        public int StockCode => Model.itemNumber;

        public int StockOriginPrice => Model.cost;
        public int StockRetailPrice => Model.salesPrice;

        public int Quantity => Model.quantity;
    }
}
