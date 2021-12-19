using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class InventoryViewModelItem
    {
        public string StockCode => "12412341";
        public string StockName => "Bánh chuối";
        public int InventoryNumber => 10;
        public int InventoryNumberFact => 12;
        public int QuantityOfFifference => 2;
        public string Note => "Note";
    }
}
