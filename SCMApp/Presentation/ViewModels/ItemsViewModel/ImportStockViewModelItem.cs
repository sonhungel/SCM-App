using SCMApp.Helper;
using SCMApp.Models;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class ImportStockViewModelItem
    {
        public ImportStockViewModelItem(ImportStock importStock)
        {
            Model = importStock;
        }
        public ImportStock Model;
        public int ImportStockCode => Model.id;
        public string StockName => Model.item.name;

        public string ImportStockTime => DateTimeHelper.DateTimeToStandardString(Model.addedDate);
        public string Supplier => Model.supplier.name;
        public string Cost => MoneyHelper.IntToStandardMoneyStringWithTail(Model.cost);
    }
}
