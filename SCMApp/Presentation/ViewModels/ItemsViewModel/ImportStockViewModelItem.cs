using SCMApp.Helper;
using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class ImportStockViewModelItem
    {
        public ImportStockViewModelItem(ImportStock importStock)
        {
            Model = importStock;
        }
        public ImportStock Model;
        public string ImportStockCode => Model.ImportStockCode;
        public string StockName => Model.StockName;

        public string ImportStockTime => DateTimeHelper.DateTimeToStandardString(Model.ImportStockTime);
        public string Supplier => Model.Supplier;
        public int Cost => Model.Cost;
    }
}
