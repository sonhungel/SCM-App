using SCMApp.Constants;
using SCMApp.Helper;
using SCMApp.Models;

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

        public string StockOriginPrice => MoneyHelper.IntToStandardMoneyStringWithTail(Model.cost);
        public string StockRetailPrice => MoneyHelper.IntToStandardMoneyStringWithTail(Model.salesPrice);

        public int Quantity => Model.availableQuantity;
        public string Remark => Model.remark;
        public string ColorRow
        {
            get
            {
                if (Model.availableQuantity <= Model.minimumQuantity)
                {
                    return CommonConstants.RED;
                }
                else if (Model.supplier.internalState == "DELETED")
                {
                    return CommonConstants.YELLOW;
                }
                return string.Empty;
            }
        }
    }
}
